using System;
using System.Linq;
using HutongGames.PlayMaker;
using UnityEngine;

namespace DeveloperToolsetII
{
	public static class VariableDisplay
	{
		public static void DisplayVariables(FsmVariables fsmVariables)
		{
			Inspector.BeginBox();
			if (fsmVariables.FloatVariables.Count<FsmFloat>() > 0)
			{
				GUILayout.Label("<b>Float Variables (FsmFloat):</b>", new GUILayoutOption[0]);
				fsmVariables.FloatVariables.DisplayFsmFloats();
			}
			if (fsmVariables.IntVariables.Count<FsmInt>() > 0)
			{
				GUILayout.Label("<b>Integer Variables (FsmInt):</b>", new GUILayoutOption[0]);
				fsmVariables.IntVariables.DisplayFsmInts();
			}
			if (fsmVariables.BoolVariables.Count<FsmBool>() > 0)
			{
				GUILayout.Label("<b>Boolean Variables (FsmBool):</b>", new GUILayoutOption[0]);
				fsmVariables.BoolVariables.DisplayFsmBools();
			}
			if (fsmVariables.StringVariables.Count<FsmString>() > 0)
			{
				GUILayout.Label("<b>String Variables (FsmString):</b>", new GUILayoutOption[0]);
				fsmVariables.StringVariables.DisplayFsmStrings();
			}
			if (fsmVariables.Vector2Variables.Count<FsmVector2>() > 0)
			{
				GUILayout.Label("<b>Vector2 Variables (FsmVector2):</b>", new GUILayoutOption[0]);
				fsmVariables.Vector2Variables.DisplayFsmVector2s();
			}
			if (fsmVariables.Vector3Variables.Count<FsmVector3>() > 0)
			{
				GUILayout.Label("<b>Vector3 Variables (FsmVector3):</b>", new GUILayoutOption[0]);
				fsmVariables.Vector3Variables.DisplayFsmVector3s();
			}
			if (fsmVariables.RectVariables.Count<FsmRect>() > 0)
			{
				GUILayout.Label("<b>Rect Variables (FsmRect):</b>", new GUILayoutOption[0]);
				fsmVariables.RectVariables.DisplayFsmRects();
			}
			if (fsmVariables.QuaternionVariables.Count<FsmQuaternion>() > 0)
			{
				GUILayout.Label("<b>Quaternion Variables (FsmQuaternion):</b>", new GUILayoutOption[0]);
				fsmVariables.QuaternionVariables.DisplayFsmQuaternions();
			}
			if (fsmVariables.ColorVariables.Count<FsmColor>() > 0)
			{
				GUILayout.Label("<b>Color Variables (FsmColor):</b>", new GUILayoutOption[0]);
				fsmVariables.ColorVariables.DisplayFsmColors();
			}
			if (fsmVariables.GameObjectVariables.Count<FsmGameObject>() > 0)
			{
				GUILayout.Label("<b>GameObject Variables (FsmGameObject):</b>", new GUILayoutOption[0]);
				fsmVariables.GameObjectVariables.DisplayFsmGameObjects();
			}
			if (fsmVariables.MaterialVariables.Count<FsmMaterial>() > 0)
			{
				GUILayout.Label("<b>Material Variables (FsmMaterial):</b>", new GUILayoutOption[0]);
				fsmVariables.MaterialVariables.DisplayFsmMaterials();
			}
			if (fsmVariables.TextureVariables.Count<FsmTexture>() > 0)
			{
				GUILayout.Label("<b>Texture Variables (FsmTexture):</b>", new GUILayoutOption[0]);
				fsmVariables.TextureVariables.DisplayFsmTextures();
			}
			if (fsmVariables.ObjectVariables.Count<FsmObject>() > 0)
			{
				GUILayout.Label("<b>Object Variables (FsmObject):</b>", new GUILayoutOption[0]);
				fsmVariables.ObjectVariables.DisplayFsmObjects();
			}
			Inspector.EndBox();
		}
		internal static void DisplayFsmFloats(this FsmFloat[] variables)
		{
			Inspector.BeginBox();
			foreach (FsmFloat fsmFloat in variables)
			{
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				GUILayout.Label("<b>" + fsmFloat.Name + ":</b>", new GUILayoutOption[0]);
				fsmFloat.Value = float.Parse(GUILayout.TextField(fsmFloat.Value.ToString(), new GUILayoutOption[]
				{
					GUILayout.MinWidth(100f)
				}));
				GUILayout.EndHorizontal();
			}
			Inspector.EndBox();
		}
		internal static void DisplayFsmInts(this FsmInt[] variables)
		{
			Inspector.BeginBox();
			foreach (FsmInt fsmInt in variables)
			{
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				GUILayout.Label("<b>" + fsmInt.Name + ":</b>", new GUILayoutOption[0]);
				fsmInt.Value = Convert.ToInt32(GUILayout.TextField(fsmInt.Value.ToString(), new GUILayoutOption[]
				{
					GUILayout.MinWidth(100f)
				}));
				GUILayout.EndHorizontal();
			}
			Inspector.EndBox();
		}
		internal static void DisplayFsmBools(this FsmBool[] variables)
		{
			Inspector.BeginBox();
			foreach (FsmBool fsmBool in variables)
			{
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				GUILayout.Label("<b>" + fsmBool.Name + ":</b>", new GUILayoutOption[0]);
				fsmBool.Value = GUILayout.Toggle(fsmBool.Value, "", new GUILayoutOption[0]);
				GUILayout.EndHorizontal();
			}
			GUILayout.Space(7.5f);
			Inspector.EndBox();
		}
		internal static void DisplayFsmStrings(this FsmString[] variables)
		{
			Inspector.BeginBox();
			foreach (FsmString fsmString in variables)
			{
				GUILayout.Label("<b>" + fsmString.Name + ":</b>", new GUILayoutOption[0]);
				if (fsmString.Value != null)
				{
					fsmString.Value = GUILayout.TextArea(fsmString.Value, new GUILayoutOption[]
					{
						GUILayout.MinWidth(100f)
					});
				}
				else
				{
					GUILayout.Label("VALUE:NULL", new GUILayoutOption[]
					{
						GUILayout.Width(90f)
					});
				}
			}
			Inspector.EndBox();
		}
		internal static void DisplayFsmVector2s(this FsmVector2[] variables)
		{
			Inspector.BeginBox();
			foreach (FsmVector2 fsmVector in variables)
			{
				Vector2 value = fsmVector.Value;
				fsmVector.Value = fsmVector.Value.DisplayVector2(fsmVector.Name, "");
			}
			Inspector.EndBox();
		}
		internal static void DisplayFsmVector3s(this FsmVector3[] variables)
		{
			Inspector.BeginBox();
			foreach (FsmVector3 fsmVector in variables)
			{
				Vector3 value = fsmVector.Value;
				fsmVector.Value = fsmVector.Value.DisplayVector3(fsmVector.Name, "");
			}
			Inspector.EndBox();
		}
		internal static void DisplayFsmRects(this FsmRect[] variables)
		{
			Inspector.BeginBox();
			foreach (FsmRect fsmRect in variables)
			{
				GUILayout.Label(string.Format("<b>{0}:</b> {1}", fsmRect.Name, fsmRect.Value), new GUILayoutOption[0]);
			}
			Inspector.EndBox();
		}
		internal static void DisplayFsmQuaternions(this FsmQuaternion[] variables)
		{
			Inspector.BeginBox();
			foreach (FsmQuaternion fsmQuaternion in variables)
			{
				GUILayout.Label(string.Format("<b>{0}:</b> {1}", fsmQuaternion.Name, fsmQuaternion.Value), new GUILayoutOption[0]);
			}
			Inspector.EndBox();
		}
		internal static void DisplayFsmColors(this FsmColor[] variables)
		{
			Inspector.BeginBox();
			foreach (FsmColor fsmColor in variables)
			{
				Color value = fsmColor.Value;
				fsmColor.Value = ComponentDisplay.DisplayColor(fsmColor.Value, fsmColor.Name);
			}
			Inspector.EndBox();
		}
		internal static void DisplayFsmGameObjects(this FsmGameObject[] variables)
		{
			Inspector.BeginBox();
			foreach (FsmGameObject fsmGameObject in variables)
			{
				if (fsmGameObject.Value != null)
				{
					ComponentDisplay.DisplayReferenceButton(fsmGameObject.Value, fsmGameObject.Name);
				}
				else
				{
					GUILayout.Label(string.Format("<b>{0}:</b> {1}", fsmGameObject.Name, fsmGameObject.Value), new GUILayoutOption[0]);
				}
			}
			Inspector.EndBox();
		}
		internal static void DisplayFsmMaterials(this FsmMaterial[] variables)
		{
			Inspector.BeginBox();
			foreach (FsmMaterial fsmMaterial in variables)
			{
				GUILayout.Label("<b>" + fsmMaterial.Name + ":</b>", new GUILayoutOption[0]);
				if (fsmMaterial.Value != null)
				{
					fsmMaterial.Value.DisplayMaterial("");
				}
			}
			Inspector.EndBox();
		}
		internal static void DisplayFsmTextures(this FsmTexture[] variables)
		{
			Inspector.BeginBox();
			foreach (FsmTexture fsmTexture in variables)
			{
				GUILayout.Label(string.Format("<b>{0}:</b> {1}", fsmTexture.Name, fsmTexture.Value), new GUILayoutOption[0]);
			}
			Inspector.EndBox();
		}
		internal static void DisplayFsmObjects(this FsmObject[] variables)
		{
			Inspector.BeginBox();
			foreach (FsmObject fsmObject in variables)
			{
				if (fsmObject.Value != null && fsmObject.Value is Component)
				{
					ComponentDisplay.DisplayReferenceButton(fsmObject.Value as Component, fsmObject.Name);
				}
				else
				{
					GUILayout.Label(string.Format("<b>{0}:</b> {1}", fsmObject.Name, fsmObject.Value), new GUILayoutOption[0]);
				}
			}
			Inspector.EndBox();
		}
	}
}
