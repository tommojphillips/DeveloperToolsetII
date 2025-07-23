using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HutongGames.PlayMaker;
using MSCLoader;
using UnityEngine;

namespace DeveloperToolsetII
{
	public static class Inspector
	{
		internal static void OnGUI()
		{
			try
			{
				if (Inspector.GUIVisible)
				{
					Inspector.HierarchyWindow();
					if (Inspector.inspectObject != null)
					{
						Inspector.InspectorWindow(Inspector.inspectObject, Inspector.inspectObject.root.IsPrefab());
					}
					if (Inspector.GlobalVarVisible)
					{
						Inspector.VariableWindow();
					}
				}
			}
			catch (Exception ex)
			{
				ModConsole.Log(ex.ToString());
			}
		}
		internal static void Search(string keyword)
		{
			Inspector.hierarchyExpanded.Clear();
			Inspector.transformList = Resources.FindObjectsOfTypeAll<Transform>().ToList<Transform>();
			foreach (Transform transform in from t in Inspector.transformList
			where !Inspector.FSMDictionary.ContainsKey(t)
			select t)
			{
				Inspector.FSMDictionary.Add(transform, transform.GetComponent<PlayMakerFSM>());
			}
			if (Inspector.allowPath && keyword.Contains("/"))
			{
				List<Transform> list = (from x in Inspector.transformList
				where string.Compare(x.GetPath(), keyword, Inspector.ignoreCase) == 0
				select x).ToList<Transform>();
				Inspector.transformList = new List<Transform>();
				foreach (Transform transform2 in list)
				{
					Inspector.transformList.Add(transform2.root);
					foreach (Transform key in from x in transform2.parent.GetComponentsInParent<Transform>(true)
					where !Inspector.hierarchyExpanded.ContainsKey(x)
					select x)
					{
						Inspector.hierarchyExpanded.Add(key, true);
					}
				}
				Inspector.transformList = Inspector.transformList.Distinct<Transform>().ToList<Transform>();
				return;
			}
			if (string.IsNullOrEmpty(keyword))
			{
				Inspector.transformList = (from x in Inspector.transformList
				where x.parent == null && x.name != null && x.name != string.Empty
				select x).ToList<Transform>();
			}
			else
			{
				Inspector.transformList = (from x in Inspector.transformList
				where x.name.Contains(keyword, StringComparison.OrdinalIgnoreCase)
				select x).ToList<Transform>();
				if (!Inspector.ignoreCase)
				{
					Inspector.transformList = (from x in Inspector.transformList
					where x.name.Contains(keyword)
					select x).ToList<Transform>();
				}
				if (Inspector.onlyRoot)
				{
					Inspector.transformList = (from x in Inspector.transformList
					where x.root == x
					select x).ToList<Transform>();
				}
			}
			if (!Inspector.showPrefabs && !Inspector.onlyPrefabs)
			{
				Inspector.transformList = (from x in Inspector.transformList
				where !x.IsPrefab()
				select x).ToList<Transform>();
			}
			if (Inspector.onlyPrefabs)
			{
				Inspector.transformList = (from x in Inspector.transformList
				where x.root.IsPrefab()
				select x).ToList<Transform>();
			}
			Inspector.transformList.Sort(new Comparison<Transform>(Inspector.SortAscending));
		}
		private static void HierarchyWindow()
		{
			GUILayout.BeginArea(new Rect(2f, 2f, (float)Inspector.hierarchyWidth, (float)Inspector.hierarchyHeight));
			GUILayout.BeginVertical("box", new GUILayoutOption[0]);
			Inspector.hierarchyScrollPosition = GUILayout.BeginScrollView(Inspector.hierarchyScrollPosition, false, true, new GUILayoutOption[0]);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("<b>Scene:</b> " + Application.loadedLevelName, new GUILayoutOption[0]);
			if (GUILayout.Button("Reset Collider Visualization", new GUILayoutOption[0]))
			{
				ColliderVisualization.Reset();
			}
			if (GUILayout.Button((Inspector.GlobalVarVisible ? "<color=#33cc33>" : "") + "Global Playmaker Variables " + (Inspector.GlobalVarVisible ? "<-</color>" : "->"), new GUILayoutOption[]
			{
				GUILayout.Width(200f)
			}))
			{
				Inspector.GlobalVarVisible = !Inspector.GlobalVarVisible;
			}
			GUILayout.EndHorizontal();
			Inspector.searchString = GUILayout.TextField(Inspector.searchString, new GUILayoutOption[0]);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button("Search", new GUILayoutOption[0]))
			{
				Inspector.Search(Inspector.searchString);
			}
			if (GUILayout.Button("Clear Hierarchy", new GUILayoutOption[0]))
			{
				Inspector.transformList.Clear();
			}
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			Inspector.ignoreCase = GUILayout.Toggle(Inspector.ignoreCase, "Ignore Case", new GUILayoutOption[0]);
			Inspector.showPrefabs = GUILayout.Toggle(Inspector.showPrefabs, "Show Prefabs", new GUILayoutOption[0]);
			Inspector.onlyPrefabs = (Inspector.showPrefabs && GUILayout.Toggle(Inspector.onlyPrefabs, "Only Prefabs", new GUILayoutOption[0]));
			Inspector.onlyRoot = GUILayout.Toggle(Inspector.onlyRoot, "Only Root", new GUILayoutOption[0]);
			Inspector.allowPath = GUILayout.Toggle(Inspector.allowPath, "Allow Path Search", new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			if (Inspector.transformList.Count > 0)
			{
				foreach (Transform transform in Inspector.transformList)
				{
					Inspector.DisplayInHierarchy(transform);
				}
			}
			GUILayout.EndScrollView();
			GUILayout.EndVertical();
			GUILayout.EndArea();
		}
		private static void DisplayInHierarchy(Transform transform)
		{
			if (!transform)
			{
				return;
			}
			if (!Inspector.hierarchyExpanded.ContainsKey(transform))
			{
				Inspector.hierarchyExpanded.Add(transform, false);
			}
			GUILayout.BeginHorizontal("box", new GUILayoutOption[0]);
			GUILayout.Label(string.Concat(new string[]
			{
				"<color=#006600>",
				transform.root.IsPrefab() ? ("[PREFAB" + ((transform.root != transform) ? "-CHILD" : "") + "]") : "",
				"</color> <color=#cc9900>",
				(transform.parent != null) ? string.Format("[{0}]", transform.GetSiblingIndex()) : "",
				"</color> ",
				transform.gameObject.activeInHierarchy ? (transform.name ?? "") : ("<color=grey>" + transform.name + "</color>")
			}), new GUILayoutOption[0]);
			if (Inspector.FSMDictionary.ContainsKey(transform) && Inspector.FSMDictionary[transform])
			{
				GUILayout.Label("<color=#cc0000>[FSM]</color>", new GUILayoutOption[]
				{
					GUILayout.Width(40f)
				});
			}
			if (Inspector.inspectObject == transform && GUILayout.Button("<color=#33cc33>Inspect</color>", new GUILayoutOption[]
			{
				GUILayout.Width(55f)
			}))
			{
				Inspector.inspectObject = null;
			}
			else if (Inspector.inspectObject != transform && GUILayout.Button("Inspect", new GUILayoutOption[]
			{
				GUILayout.Width(55f)
			}))
			{
				Inspector.Inspect(transform, false, false);
			}
			if (transform.childCount > 0 && GUILayout.Button(string.Format("({0}) {1}", transform.childCount, Inspector.hierarchyExpanded[transform] ? "<" : ">"), new GUILayoutOption[]
			{
				GUILayout.Width(50f)
			}))
			{
				Inspector.hierarchyExpanded[transform] = !Inspector.hierarchyExpanded[transform];
			}
			else if (transform.childCount == 0)
			{
				GUILayout.Button("(0)  |", new GUILayoutOption[]
				{
					GUILayout.Width(50f)
				});
			}
			GUILayout.EndHorizontal();
			if (Inspector.hierarchyExpanded[transform] && transform.childCount > 0)
			{
				Inspector.BeginBox();
				foreach (object obj in transform)
				{
					Inspector.DisplayInHierarchy((Transform)obj);
				}
				Inspector.EndBox();
			}
		}
		private static void InspectorWindow(Transform transform, bool isPrefab = false)
		{
			GUILayout.BeginArea(new Rect((float)(Screen.width - Inspector.inspectorWidth), 2f, (float)(Inspector.inspectorWidth - 2), (float)Inspector.inspectorHeight));
			Inspector.inspectorScrollPosition = GUILayout.BeginScrollView(Inspector.inspectorScrollPosition, false, true, new GUILayoutOption[0]);
			if (GUILayout.Button("Close", new GUILayoutOption[0]))
			{
				Inspector.inspectObject = null;
			}
			if (Inspector.transformHistory.Count > 1 && GUILayout.Button("Previous", new GUILayoutOption[0]))
			{
				Inspector.Inspect(transform, false, true);
			}
			if (transform)
			{
				if (transform.parent != null && GUILayout.Button("Parent", new GUILayoutOption[0]))
				{
					Inspector.Inspect(transform.parent, false, false);
					GUILayout.EndScrollView();
					GUILayout.EndArea();
					return;
				}
				GUILayout.BeginHorizontal("box", new GUILayoutOption[0]);
				GUILayout.Label(string.Concat(new string[]
				{
					"<b><size=20>",
					transform.gameObject.isStatic ? "<color=#cc0000>[STATIC]</color> " : "",
					"<color=#006600>",
					isPrefab ? ("[PREFAB" + ((transform.root != transform) ? "-CHILD" : "") + "] ") : "",
					"</color>",
					transform.name,
					"</size></b>"
				}), new GUILayoutOption[0]);
				GUILayout.EndHorizontal();
				GUILayout.BeginVertical("box", new GUILayoutOption[0]);
				if (transform.parent != null)
				{
					GUILayout.Label(transform.GetPath(), new GUILayoutOption[0]);
				}
				if (GUILayout.Button("Show In Hierarchy", new GUILayoutOption[0]))
				{
					Inspector.transformList = new List<Transform>
					{
						transform.root
					};
					foreach (Transform transform2 in from t in Resources.FindObjectsOfTypeAll<Transform>()
					where !Inspector.FSMDictionary.ContainsKey(t)
					select t)
					{
						Inspector.FSMDictionary.Add(transform2, transform2.GetComponent<PlayMakerFSM>());
					}
					Inspector.hierarchyExpanded.Clear();
					foreach (Transform key in transform.parent.GetComponentsInParent<Transform>(true))
					{
						Inspector.hierarchyExpanded.Add(key, true);
					}
				}
				if (GUILayout.Button("Copy " + ((transform.parent != null) ? "Path" : "Name"), new GUILayoutOption[0]))
				{
					("\"" + transform.GetPath() + "\"").CopyToClipboard();
				}
				GUILayout.EndVertical();
				if (!isPrefab)
				{
					GUILayout.BeginHorizontal("box", new GUILayoutOption[0]);
					transform.gameObject.SetActive(GUILayout.Toggle(transform.gameObject.activeSelf, "Is Active", new GUILayoutOption[0]));
					GUILayout.EndHorizontal();
				}
				GUILayout.BeginHorizontal("box", new GUILayoutOption[0]);
				GUILayout.Label(string.Format("<b>Layer:</b> {0} [{1}]", LayerMask.LayerToName(transform.gameObject.layer), transform.gameObject.layer), new GUILayoutOption[0]);
				GUILayout.Label("<b>Tag:</b> " + transform.gameObject.tag, new GUILayoutOption[0]);
				GUILayout.EndHorizontal();
				GUILayout.BeginVertical("box", new GUILayoutOption[0]);
				GUILayout.BeginHorizontal("box", new GUILayoutOption[0]);
				ComponentDisplay.variablesPublic = GUILayout.Toggle(ComponentDisplay.variablesPublic, "Show public variables", new GUILayoutOption[0]);
				ComponentDisplay.variablesNonPublic = GUILayout.Toggle(ComponentDisplay.variablesNonPublic, "Show non-public variables", new GUILayoutOption[0]);
				GUILayout.EndHorizontal();
				Collider[] componentsInChildren = transform.GetComponentsInChildren<Collider>();
				if (componentsInChildren.Length != 0)
				{
					GUILayout.BeginVertical("box", new GUILayoutOption[0]);
					GUILayout.Label("<b>Collider Visualization</b>", new GUILayoutOption[0]);
					GUILayout.BeginHorizontal(new GUILayoutOption[0]);
					ColliderVisualization.DisplayVisualizerGameObjectButton(transform);
					ColliderVisualization.DisplayVisualizerHierarchyButton(transform, componentsInChildren);
					GUILayout.EndHorizontal();
					GUILayout.EndVertical();
				}
				ComponentDisplay.DisplayComponents(transform.GetComponents<Component>());
				GUILayout.EndVertical();
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}
		internal static void Inspect(Transform transform, bool resetToggles = false, bool previous = false)
		{
			if (previous)
			{
				if (Inspector.transformHistory.Count == 1)
				{
					return;
				}
				Inspector.transformHistory.RemoveAt(Inspector.transformHistory.Count - 1);
				Inspector.inspectObject = Inspector.transformHistory.Last<Transform>();
			}
			else
			{
				if (!Inspector.transformHistory.Contains(transform))
				{
					Inspector.transformHistory.Add(transform);
				}
				Inspector.inspectObject = transform;
			}
			ComponentDisplay.transformLocalValues = new Vector3[]
			{
				transform.localPosition,
				transform.localEulerAngles
			};
			ComponentDisplay.transformGlobalValues = new Vector3[]
			{
				transform.position,
				transform.eulerAngles
			};
			ComponentDisplay.transformScaleValues = transform.localScale;
			if (resetToggles)
			{
				ComponentDisplay.fsmToggles.Clear();
			}
		}
		private static void VariableWindow()
		{
			GUILayout.BeginArea(new Rect((float)(Inspector.hierarchyWidth + 5), 2f, (float)Inspector.variableWidth, (float)Inspector.variableHeight));
			GUILayout.BeginVertical("box", new GUILayoutOption[0]);
			Inspector.variableScrollPosition = GUILayout.BeginScrollView(Inspector.variableScrollPosition, false, true, new GUILayoutOption[0]);
			FsmVariables variables = PlayMakerGlobals.Instance.Variables;
			Inspector.DisplayVariableButton("Float Variables (FsmFloat)", 0);
			if (Inspector.variableList[0])
			{
				variables.FloatVariables.DisplayFsmFloats();
			}
			Inspector.DisplayVariableButton("Integer Variables (FsmInt)", 1);
			if (Inspector.variableList[1])
			{
				variables.IntVariables.DisplayFsmInts();
			}
			Inspector.DisplayVariableButton("Boolean Variables (FsmBool)", 2);
			if (Inspector.variableList[2])
			{
				variables.BoolVariables.DisplayFsmBools();
			}
			Inspector.DisplayVariableButton("String Variables (FsmString)", 3);
			if (Inspector.variableList[3])
			{
				variables.StringVariables.DisplayFsmStrings();
			}
			Inspector.DisplayVariableButton("Vector2 Variables (FsmVector2)", 4);
			if (Inspector.variableList[4])
			{
				variables.Vector2Variables.DisplayFsmVector2s();
			}
			Inspector.DisplayVariableButton("Vector3 Variables (FsmVector3)", 5);
			if (Inspector.variableList[5])
			{
				variables.Vector3Variables.DisplayFsmVector3s();
			}
			Inspector.DisplayVariableButton("Rect Variables (FsmRect)", 6);
			if (Inspector.variableList[6])
			{
				variables.RectVariables.DisplayFsmRects();
			}
			Inspector.DisplayVariableButton("Quaternion Variables (FsmQuaternion)", 7);
			if (Inspector.variableList[7])
			{
				variables.QuaternionVariables.DisplayFsmQuaternions();
			}
			Inspector.DisplayVariableButton("Color Variables (FsmColor)", 8);
			if (Inspector.variableList[8])
			{
				variables.ColorVariables.DisplayFsmColors();
			}
			Inspector.DisplayVariableButton("GameObject Variables (FsmGameObject)", 9);
			if (Inspector.variableList[9])
			{
				variables.GameObjectVariables.DisplayFsmGameObjects();
			}
			Inspector.DisplayVariableButton("Material Variables (FsmMaterial)", 10);
			if (Inspector.variableList[10])
			{
				variables.MaterialVariables.DisplayFsmMaterials();
			}
			Inspector.DisplayVariableButton("Texture Variables (FsmTexture)", 11);
			if (Inspector.variableList[11])
			{
				variables.TextureVariables.DisplayFsmTextures();
			}
			Inspector.DisplayVariableButton("Object Variables (FsmObject)", 12);
			if (Inspector.variableList[12])
			{
				variables.ObjectVariables.DisplayFsmObjects();
			}
			GUILayout.EndScrollView();
			GUILayout.EndVertical();
			GUILayout.EndArea();
		}
		private static void DisplayVariableButton(string typeName, int type)
		{
			string text = Inspector.variableList[type] ? "Hide" : "Show";
			if (GUILayout.Button(string.Concat(new string[]
			{
				text,
				" - <b>",
				typeName,
				"</b> - ",
				text
			}), new GUILayoutOption[0]))
			{
				Inspector.variableList[type] = !Inspector.variableList[type];
			}
		}
		public static void BeginBox()
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Space(20f);
			GUILayout.BeginVertical("box", new GUILayoutOption[0]);
		}
		public static void EndBox()
		{
			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
		}
		public static string GetPath(this Transform transform)
		{
			if (!transform.parent)
			{
				return transform.name ?? "";
			}
			return transform.parent.GetPath() + "/" + transform.name;
		}
		private static bool IsPrefab(this Transform tempTrans)
		{
			return !tempTrans.gameObject.activeInHierarchy && tempTrans.gameObject.activeSelf && tempTrans.root == tempTrans;
		}
		private static int SortAscending(Transform x, Transform y)
		{
			return string.Compare(x.name, y.name);
		}
		private static bool Contains(this string target, string value, StringComparison comparison)
		{
			return target.IndexOf(value, comparison) >= 0;
		}
		public static void CopyToClipboard(this string text)
		{
			typeof(GUIUtility).GetProperty("systemCopyBuffer", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, text, null);
		}
		public static bool GUIVisible;
		public static bool GlobalVarVisible = false;
		public static int hierarchyWidth = 600;
		public static int hierarchyHeight = 600;
		public static int inspectorWidth = 400;
		public static int inspectorHeight = 400;
		public static int variableWidth = 400;
		public static int variableHeight = 400;
		private static Transform inspectObject;
		private static string searchString = "";
		private static List<Transform> transformList = new List<Transform>();
		private static List<Transform> transformHistory = new List<Transform>();
		private static Vector2 hierarchyScrollPosition;
		private static Vector2 inspectorScrollPosition;
		private static Vector2 variableScrollPosition;
		private static Dictionary<Transform, bool> hierarchyExpanded = new Dictionary<Transform, bool>();
		private static Dictionary<Transform, bool> FSMDictionary = new Dictionary<Transform, bool>();
		private static bool ignoreCase = false;
		private static bool showPrefabs = true;
		private static bool onlyPrefabs = false;
		private static bool onlyRoot = false;
		private static bool allowPath = true;
		private static bool[] variableList = new bool[13];
	}
}
