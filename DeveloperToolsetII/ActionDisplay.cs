using System;
using System.Linq;
using System.Reflection;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace DeveloperToolsetII
{
	public static class ActionDisplay
	{
		public static void DisplayActions(FsmStateAction[] actions)
		{
			int num = 0;
			foreach (FsmStateAction fsmStateAction in actions)
			{
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				if (fsmStateAction.Enabled)
				{
					GUILayout.Label(string.Format("  <b>{0}:</b> {1}", num, fsmStateAction.GetType().ToString().Split(new char[]
					{
						'.'
					}).Last<string>()), new GUILayoutOption[0]);
				}
				else
				{
					GUILayout.Label(string.Format("  <b>{0}:</b> <color=grey>{1}</color>", num, fsmStateAction.GetType().ToString().Split(new char[]
					{
						'.'
					}).Last<string>()), new GUILayoutOption[0]);
				}
				fsmStateAction.Enabled = GUILayout.Toggle(fsmStateAction.Enabled, "", new GUILayoutOption[0]);
				GUILayout.EndHorizontal();
				Inspector.BeginBox();
				if (fsmStateAction is ActivateGameObject)
				{
					(fsmStateAction as ActivateGameObject).DisplayAction(num);
				}
				if (fsmStateAction is SetStringValue)
				{
					(fsmStateAction as SetStringValue).DisplayAction(num);
				}
				else if (fsmStateAction is SetBoolValue)
				{
					(fsmStateAction as SetBoolValue).DisplayAction(num);
				}
				else if (fsmStateAction is MousePickEvent)
				{
					(fsmStateAction as MousePickEvent).DisplayAction(num);
				}
				else if (fsmStateAction is SendRandomEvent)
				{
					(fsmStateAction as SendRandomEvent).DisplayAction(num);
				}
				else
				{
					fsmStateAction.DisplayAction(num);
				}
				num++;
				Inspector.EndBox();
			}
		}
		private static void DisplayLabels(string[] fields)
		{
			for (int i = 0; i < fields.Length; i++)
			{
				GUILayout.Label(fields[i], new GUILayoutOption[0]);
			}
		}
		private static void DisplayAction(this SetStringValue action, int index)
		{
			ActionDisplay.DisplayLabels(new string[]
			{
				string.Concat(new string[]
				{
					"<b>stringVariable:</b> \"",
					action.stringVariable.Value,
					"\" (",
					action.stringVariable.Name,
					")"
				}),
				string.Concat(new string[]
				{
					"<b>stringValue:</b> \"",
					action.stringValue.Value,
					"\" (",
					action.stringValue.Name,
					")"
				}),
				string.Format("<b>everyFrame:</b> {0}", action.everyFrame)
			});
		}
		private static void DisplayAction(this SetBoolValue action, int index)
		{
			ActionDisplay.DisplayLabels(new string[]
			{
				string.Format("<b>boolVariable:</b> {0} ({1})", action.boolVariable.Value, action.boolVariable.Name),
				string.Format("<b>boolValue:</b> {0} ({1})", action.boolValue.Value, action.boolValue.Name),
				string.Format("<b>everyFrame:</b> {0}", action.everyFrame)
			});
		}
		private static void DisplayAction(this MousePickEvent action, int index)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("<b>GameObject:</b>", new GUILayoutOption[]
			{
				GUILayout.Width(80f)
			});
			if (GUILayout.Button(((action.GameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? action.GameObject.GameObject.Value.name : action.Owner.name) ?? "", new GUILayoutOption[0]))
			{
				Inspector.Inspect((action.GameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? action.GameObject.GameObject.Value.transform : action.Owner.transform, false, false);
			}
			GUILayout.EndHorizontal();
			string text = "";
			foreach (FsmInt fsmInt in action.layerMask)
			{
				text += string.Format("\n   {0} ({1})", LayerMask.LayerToName(fsmInt.Value), fsmInt.Value);
			}
			ActionDisplay.DisplayLabels(new string[]
			{
				string.Format("<b>rayDistance:</b> {0} ({1})", action.rayDistance.Value, action.rayDistance.Name),
				"<b>mouseOver:</b> " + ((action.mouseOver != null) ? action.mouseOver.Name : "null"),
				"<b>mouseDown:</b> " + ((action.mouseDown != null) ? action.mouseDown.Name : "null"),
				"<b>mouseUp:</b> " + ((action.mouseUp != null) ? action.mouseUp.Name : "null"),
				"<b>mouseOff:</b> " + ((action.mouseOff != null) ? action.mouseOff.Name : "null"),
				"<b>layerMask:</b> " + text,
				string.Format("<b>invertMask:</b> {0} ({1})", action.invertMask, action.invertMask.Name),
				string.Format("<b>everyFrame:</b> {0}", action.everyFrame)
			});
		}
		private static void DisplayAction(this ActivateGameObject action, int index)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("<b>gameObject:</b>", new GUILayoutOption[]
			{
				GUILayout.Width(80f)
			});
			if (((action.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? action.gameObject.GameObject.Value : action.Owner) != null)
			{
				ComponentDisplay.DisplayReferenceButton((action.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? action.gameObject.GameObject.Value : action.Owner, ((action.gameObject.OwnerOption != OwnerDefaultOption.UseOwner) ? action.gameObject.GameObject.Value.name : action.Owner.name) ?? "");
			}
			GUILayout.EndHorizontal();
			ActionDisplay.DisplayLabels(new string[]
			{
				string.Format("<b>activate:</b> {0} ({1})", action.activate.Value, action.activate.Name),
				string.Format("<b>recursive:</b> {0} ({1})", action.recursive.Value, action.recursive.Name),
				string.Format("<b>resetOnExit:</b> {0}", action.resetOnExit),
				string.Format("<b>everyFrame:</b> {0}", action.everyFrame)
			});
		}
		private static void DisplayAction(this SendRandomEvent action, int index)
		{
			GUILayout.Label("<b>Events:</b>", new GUILayoutOption[0]);
			Inspector.BeginBox();
			for (int i = 0; i < action.events.Length; i++)
			{
				Inspector.BeginBox();
				GUILayout.Label("    <b>Event:</b> " + action.events[i].Name, new GUILayoutOption[0]);
				action.weights[i].Value = ComponentDisplay.DisplayTextBox(action.weights[i].Value, "    <b>Weight:</b>");
				Inspector.EndBox();
			}
			Inspector.EndBox();
			action.delay.Value = ComponentDisplay.DisplayTextBox(action.delay.Value, "<b>Delay:</b>");
		}
		private static void DisplayAction(this FsmStateAction action, int index)
		{
			foreach (FieldInfo fieldInfo in action.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public))
			{
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				try
				{
					object value = fieldInfo.GetValue(action);
					string text = value.ToString();
					text = text.Substring(text.LastIndexOf(".", StringComparison.Ordinal) + 1);
					if (value is FsmProperty)
					{
						GUILayout.BeginVertical(new GUILayoutOption[0]);
						FsmProperty fsmProperty = value as FsmProperty;
						GUILayout.Label(string.Format("<b>Target: {0}</b>", fsmProperty.TargetObject), new GUILayoutOption[0]);
						GUILayout.Label("<b>" + fieldInfo.Name + ": </b>" + fsmProperty.PropertyName, new GUILayoutOption[0]);
						if (fsmProperty.PropertyType != null)
						{
							if (fsmProperty.PropertyType.IsAssignableFrom(typeof(bool)) && !fsmProperty.BoolParameter.IsNone)
							{
								GUILayout.Label(string.Format("<b>New Value:</b> {0} ({1})", fsmProperty.BoolParameter.Value, fsmProperty.BoolParameter.Name), new GUILayoutOption[0]);
							}
							else if (fsmProperty.PropertyType.IsAssignableFrom(typeof(int)) && !fsmProperty.IntParameter.IsNone)
							{
								GUILayout.Label(string.Format("<b>New Value:</b> {0} ({1})", fsmProperty.IntParameter.Value, fsmProperty.IntParameter.Name), new GUILayoutOption[0]);
							}
							else if (fsmProperty.PropertyType.IsAssignableFrom(typeof(float)) && !fsmProperty.FloatParameter.IsNone)
							{
								GUILayout.Label(string.Format("<b>New Value:</b> {0}f ({1})", fsmProperty.FloatParameter.Value, fsmProperty.FloatParameter.Name), new GUILayoutOption[0]);
							}
							else if (fsmProperty.PropertyType.IsAssignableFrom(typeof(string)) && !fsmProperty.StringParameter.IsNone)
							{
								GUILayout.Label(string.Concat(new string[]
								{
									"<b>New Value:</b> \"",
									fsmProperty.StringParameter.Value,
									"\" (",
									fsmProperty.StringParameter.Name,
									")"
								}), new GUILayoutOption[0]);
							}
							else if (fsmProperty.PropertyType.IsAssignableFrom(typeof(Vector2)) && !fsmProperty.Vector2Parameter.IsNone)
							{
								GUILayout.Label(string.Format("<b>New Value:</b> {0} ({1})", fsmProperty.Vector2Parameter.Value, fsmProperty.Vector2Parameter.Name), new GUILayoutOption[0]);
							}
							else if (fsmProperty.PropertyType.IsAssignableFrom(typeof(Vector3)) && !fsmProperty.Vector3Parameter.IsNone)
							{
								GUILayout.Label(string.Format("<b>New Value:</b> {0} ({1})", fsmProperty.Vector3Parameter.Value, fsmProperty.Vector3Parameter.Name), new GUILayoutOption[0]);
							}
							else if (fsmProperty.PropertyType.IsAssignableFrom(typeof(Rect)) && !fsmProperty.RectParamater.IsNone)
							{
								GUILayout.Label(string.Format("<b>New Value:</b> {0} ({1})", fsmProperty.RectParamater.Value, fsmProperty.RectParamater.Name), new GUILayoutOption[0]);
							}
							else if (fsmProperty.PropertyType.IsAssignableFrom(typeof(Quaternion)) && !fsmProperty.QuaternionParameter.IsNone)
							{
								GUILayout.Label(string.Format("<b>New Value:</b> {0} ({1})", fsmProperty.QuaternionParameter.Value, fsmProperty.QuaternionParameter.Name), new GUILayoutOption[0]);
							}
							else if (fsmProperty.PropertyType.IsAssignableFrom(typeof(Texture)) && !fsmProperty.TextureParameter.IsNone)
							{
								GUILayout.Label(string.Format("<b>New Value:</b> {0} ({1})", fsmProperty.TextureParameter.Value, fsmProperty.TextureParameter.Name), new GUILayoutOption[0]);
							}
							else if (fsmProperty.PropertyType.IsAssignableFrom(typeof(Color)) && !fsmProperty.ColorParameter.IsNone)
							{
								GUILayout.Label(string.Format("<b>New Value:</b> {0} ({1})", fsmProperty.ColorParameter.Value, fsmProperty.ColorParameter.Name), new GUILayoutOption[0]);
							}
							else if (fsmProperty.PropertyType.IsAssignableFrom(typeof(GameObject)) && !fsmProperty.GameObjectParameter.IsNone)
							{
								GUILayout.BeginHorizontal(new GUILayoutOption[0]);
								GUILayout.Label("<b>New Value:</b>", new GUILayoutOption[0]);
								FsmGameObject gameObjectParameter = fsmProperty.GameObjectParameter;
								GameObject gameObject = (gameObjectParameter != null) ? gameObjectParameter.Value : null;
								FsmGameObject gameObjectParameter2 = fsmProperty.GameObjectParameter;
								string str;
								if (gameObjectParameter2 == null)
								{
									str = null;
								}
								else
								{
									GameObject value2 = gameObjectParameter2.Value;
									str = ((value2 != null) ? value2.name : null);
								}
								string str2 = " (";
								FsmGameObject gameObjectParameter3 = fsmProperty.GameObjectParameter;
								ComponentDisplay.DisplayReferenceButton(gameObject, str + str2 + ((gameObjectParameter3 != null) ? gameObjectParameter3.Name : null) + ")");
								GUILayout.EndHorizontal();
							}
							else if (fsmProperty.PropertyType.IsAssignableFrom(typeof(Material)) && !fsmProperty.MaterialParameter.IsNone)
							{
								GUILayout.Label(string.Format("<b>New Value:</b> {0} ({1})", fsmProperty.MaterialParameter.Value, fsmProperty.MaterialParameter.Name), new GUILayoutOption[0]);
								fsmProperty.MaterialParameter.Value.DisplayMaterial("");
							}
							else if (fsmProperty.PropertyType.IsSubclassOf(typeof(UnityEngine.Object)) && !fsmProperty.ObjectParameter.IsNone)
							{
								FsmObject objectParameter = fsmProperty.ObjectParameter;
								if (((objectParameter != null) ? objectParameter.Value : null) is Component)
								{
									ComponentDisplay.DisplayReferenceButton(fsmProperty.ObjectParameter.Value as Component, fsmProperty.ObjectParameter.Name);
								}
								else
								{
									GUILayout.Label(string.Format("<b>{0}:</b> {1}", fsmProperty.ObjectParameter.Name, fsmProperty.ObjectParameter.Value), new GUILayoutOption[0]);
								}
							}
						}
						GUILayout.EndVertical();
					}
					else if (value is FsmEvent)
					{
						GUILayout.Label("<b>" + fieldInfo.Name + ":</b> " + (value as FsmEvent).Name, new GUILayoutOption[0]);
					}
					else if (value is FsmString)
					{
						FsmString fsmString = value as FsmString;
						GUILayout.Label(string.Concat(new string[]
						{
							"<b>",
							fieldInfo.Name,
							":</b> ",
							fsmString.Value,
							" (",
							fsmString.Name,
							")"
						}), new GUILayoutOption[0]);
					}
					else if (value is FsmEventTarget)
					{
						FsmEventTarget fsmEventTarget = value as FsmEventTarget;
						GUILayout.Label(string.Format("<b>{0}:</b> {1} ({2})", fieldInfo.Name, fsmEventTarget.gameObject.GameObject.Value, fsmEventTarget.fsmName), new GUILayoutOption[0]);
					}
					else if (value is FsmBool)
					{
						FsmBool fsmBool = value as FsmBool;
						GUILayout.Label(string.Format("<b>{0}:</b> {1} ({2})", fieldInfo.Name, fsmBool.Value, fsmBool.Name), new GUILayoutOption[0]);
					}
					else if (value is FsmFloat)
					{
						FsmFloat fsmFloat = value as FsmFloat;
						GUILayout.Label(string.Format("<b>{0}:</b> {1}f ({2})", fieldInfo.Name, fsmFloat.Value, fsmFloat.Name), new GUILayoutOption[0]);
					}
					else if (value is FsmInt)
					{
						FsmInt fsmInt = value as FsmInt;
						GUILayout.Label(string.Format("<b>{0}:</b> {1} ({2})", fieldInfo.Name, fsmInt.Value, fsmInt.Name), new GUILayoutOption[0]);
					}
					else if (value is FsmOwnerDefault)
					{
						FsmOwnerDefault fsmOwnerDefault = value as FsmOwnerDefault;
						GUILayout.Label("<b>" + fieldInfo.Name + ":</b> (GameObject)", new GUILayoutOption[0]);
						if (((fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner) ? fsmOwnerDefault.GameObject.Value : action.Owner) != null)
						{
							ComponentDisplay.DisplayReferenceButton((fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner) ? fsmOwnerDefault.GameObject.Value : action.Owner, "");
						}
					}
					else if (value is FsmMaterial)
					{
						GUILayout.BeginVertical(new GUILayoutOption[0]);
						FsmMaterial fsmMaterial = value as FsmMaterial;
						GUILayout.Label(string.Format("<b>{0}:</b> {1} ({2})", fieldInfo.Name, fsmMaterial.Value, fsmMaterial.Name), new GUILayoutOption[0]);
						fsmMaterial.Value.DisplayMaterial("");
						GUILayout.EndVertical();
					}
					else if (value is NamedVariable)
					{
						NamedVariable namedVariable = value as NamedVariable;
						GUILayout.Label(string.Format("<b>{0}:</b> {1} ({2})", fieldInfo.Name, namedVariable, namedVariable.Name), new GUILayoutOption[0]);
					}
					else
					{
						GUILayout.Label("<b>" + fieldInfo.Name + ":</b> " + text, new GUILayoutOption[0]);
					}
				}
				catch (Exception)
				{
					GUILayout.Label("<b>" + fieldInfo.Name + ":</b> null", new GUILayoutOption[0]);
				}
				GUILayout.EndHorizontal();
			}
		}
	}
}
