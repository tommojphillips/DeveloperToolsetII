using System;
using System.Collections.Generic;
using System.Linq;
using DeveloperToolsetII.Properties;
using UnityEngine;

namespace DeveloperToolsetII
{
	internal class ColliderVisualization
	{
		internal static void Setup()
		{
			if (ColliderVisualization.colliderPrefabs.Length != 0)
			{
				GameObject[] array = ColliderVisualization.colliderPrefabs;
				for (int i = 0; i < array.Length; i++)
				{
					UnityEngine.Object.Destroy(array[i]);
				}
			}
			ColliderVisualization.visualizerParent = new GameObject("ColliderVisualization").transform;
			AssetBundle assetBundle = AssetBundle.CreateFromMemoryImmediate(Properties.Resources.developertoolsetii);
			ColliderVisualization.colliderPrefabs = new GameObject[]
			{
				assetBundle.LoadAsset<GameObject>("BoxColliderVisualizer.prefab"),
				assetBundle.LoadAsset<GameObject>("SphereColliderVisualizer.prefab"),
				assetBundle.LoadAsset<GameObject>("CapsuleColliderVisualizer.prefab"),
				assetBundle.LoadAsset<GameObject>("MeshColliderVisualizer.prefab")
			};
			ColliderVisualization.colliderMaterialRegular = assetBundle.LoadAsset<Material>("ColliderVisualization.mat");
			ColliderVisualization.triggerMaterialRegular = assetBundle.LoadAsset<Material>("TriggerVisualization.mat");
			ColliderVisualization.colliderMaterialXRay = assetBundle.LoadAsset<Material>("ColliderVisualizationXRay.mat");
			ColliderVisualization.triggerMaterialXRay = assetBundle.LoadAsset<Material>("TriggerVisualizationXRay.mat");
			ColliderVisualization.colliderMaterial = (DeveloperToolsetII.xRayColliders.GetValue() ? ColliderVisualization.colliderMaterialXRay : ColliderVisualization.colliderMaterialRegular);
			ColliderVisualization.triggerMaterial = (DeveloperToolsetII.xRayColliders.GetValue() ? ColliderVisualization.triggerMaterialXRay : ColliderVisualization.triggerMaterialRegular);
			assetBundle.Unload(false);
		}
		public static void Reset()
		{
            UnityEngine.Object.Destroy(ColliderVisualization.visualizerParent.gameObject);
			ColliderVisualization.visualizerParent = new GameObject("ColliderVisualization").transform;
			ColliderVisualization.colliderDictionary = new Dictionary<Collider, GameObject>();
		}
		private static void SetupCollider(Collider collider)
		{
			if (collider is BoxCollider)
			{
				ColliderVisualization.SetupCollider(collider as BoxCollider);
				return;
			}
			if (collider is SphereCollider)
			{
				ColliderVisualization.SetupCollider(collider as SphereCollider);
				return;
			}
			if (!(collider is MeshCollider))
			{
				return;
			}
			ColliderVisualization.SetupCollider(collider as MeshCollider);
		}
		private static void SetupCollider(BoxCollider collider)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(ColliderVisualization.colliderPrefabs[0]);
			gameObject.AddComponent<BoxColliderVisualizer>().collider = collider;
			ColliderVisualization.colliderDictionary.Add(collider, gameObject);
		}
		private static void SetupCollider(SphereCollider collider)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(ColliderVisualization.colliderPrefabs[1]);
			gameObject.AddComponent<SphereColliderVisualizer>().collider = collider;
			ColliderVisualization.colliderDictionary.Add(collider, gameObject);
		}
		private static void SetupCollider(MeshCollider collider)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(ColliderVisualization.colliderPrefabs[3]);
			gameObject.AddComponent<MeshColliderVisualizer>().collider = collider;
			ColliderVisualization.colliderDictionary.Add(collider, gameObject);
		}
		internal static void DisplayVisualizerButton(Collider collider)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			try
			{
				bool flag = ColliderVisualization.colliderDictionary.ContainsKey(collider);
				if (flag && ColliderVisualization.colliderDictionary[collider].activeSelf && GUILayout.Button("<color=#33cc33>Visualize Collider</color>", new GUILayoutOption[0]))
				{
					ColliderVisualization.colliderDictionary[collider].SetActive(false);
				}
				else if ((!flag || (flag && !ColliderVisualization.colliderDictionary[collider].activeSelf)) && GUILayout.Button("Visualize Collider", new GUILayoutOption[0]))
				{
					if (!flag)
					{
						ColliderVisualization.SetupCollider(collider);
					}
					else
					{
						ColliderVisualization.colliderDictionary[collider].SetActive(true);
					}
				}
			}
			catch
			{
			}
			GUILayout.EndHorizontal();
		}
		internal static void DisplayVisualizerHierarchyButton(Transform transform, Collider[] colliders)
		{
			try
			{
				if (transform.childCount > 0)
				{
					colliders = (from x in colliders
					where x.transform != transform
					select x).ToArray<Collider>();
					bool flag = colliders.Any((Collider collider) => ColliderVisualization.colliderDictionary.ContainsKey(collider) && ColliderVisualization.colliderDictionary[collider].activeSelf);
					if (colliders.Length != 0)
					{
						if (flag && GUILayout.Button("<color=#33cc33>Visualize Child Collider(s)</color>", new GUILayoutOption[0]))
						{
							foreach (Collider key in colliders)
							{
								if (ColliderVisualization.colliderDictionary.ContainsKey(key))
								{
									ColliderVisualization.colliderDictionary[key].SetActive(false);
								}
							}
						}
						else if (!flag && GUILayout.Button("Visualize Child Collider(s)", new GUILayoutOption[0]))
						{
							foreach (Collider collider2 in colliders)
							{
								if (!ColliderVisualization.colliderDictionary.ContainsKey(collider2))
								{
									ColliderVisualization.SetupCollider(collider2);
								}
								else
								{
									ColliderVisualization.colliderDictionary[collider2].SetActive(true);
								}
							}
						}
					}
				}
			}
			catch
			{
			}
		}
		internal static void DisplayVisualizerGameObjectButton(Transform transform)
		{
			try
			{
				Collider[] components = transform.GetComponents<Collider>();
				bool flag = components.Any((Collider collider) => ColliderVisualization.colliderDictionary.ContainsKey(collider) && ColliderVisualization.colliderDictionary[collider].activeSelf);
				if (components.Length != 0)
				{
					if (flag && GUILayout.Button("<color=#33cc33>Visualize GameObject Collider(s)</color>", new GUILayoutOption[0]))
					{
						foreach (Collider key in components)
						{
							if (ColliderVisualization.colliderDictionary.ContainsKey(key))
							{
								ColliderVisualization.colliderDictionary[key].SetActive(false);
							}
						}
					}
					else if (!flag && GUILayout.Button("Visualize GameObject Collider(s)", new GUILayoutOption[0]))
					{
						foreach (Collider collider2 in components)
						{
							if (!ColliderVisualization.colliderDictionary.ContainsKey(collider2))
							{
								ColliderVisualization.SetupCollider(collider2);
							}
							else
							{
								ColliderVisualization.colliderDictionary[collider2].SetActive(true);
							}
						}
					}
				}
			}
			catch
			{
			}
		}
		internal static Vector3 GetHierarchyScale(Collider collider)
		{
			Vector3 one = Vector3.one;
			Transform transform = collider.transform;
			while (transform != null)
			{
				one.x *= transform.localScale.x;
				one.y *= transform.localScale.y;
				one.z *= transform.localScale.z;
				transform = transform.parent;
			}
			return one;
		}
		public static Transform visualizerParent;
		public static GameObject[] colliderPrefabs = new GameObject[0];
		public static Dictionary<Collider, GameObject> colliderDictionary = new Dictionary<Collider, GameObject>();
		public static Dictionary<Collider, Mesh> convexDictionary = new Dictionary<Collider, Mesh>();
		public static Material colliderMaterial;
		public static Material triggerMaterial;
		public static Material colliderMaterialRegular;
		public static Material triggerMaterialRegular;
		public static Material colliderMaterialXRay;
		public static Material triggerMaterialXRay;
		public static WaitForSeconds wait = new WaitForSeconds(0.5f);
	}
}
