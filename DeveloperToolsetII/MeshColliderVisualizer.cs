using System;
using System.Collections;
using UnityEngine;

namespace DeveloperToolsetII {
	public class MeshColliderVisualizer : MonoBehaviour	{

		public MeshCollider collider;
		private MeshRenderer renderer;
		private MeshFilter visualizerFilter;

		private void Start() {
			name = collider.name + "Visualizer";
			transform.parent = ColliderVisualization.visualizerParent;
			renderer = GetComponent<MeshRenderer>();
			visualizerFilter = GetComponent<MeshFilter>();
			visualizerFilter.sharedMesh = collider.sharedMesh;
			renderer.sharedMaterial = (collider.isTrigger ? ColliderVisualization.triggerMaterial : ColliderVisualization.colliderMaterial);
		}

		private void OnEnable() {
			StartCoroutine(update_collider());
		}

		private IEnumerator update_collider() {

			while (collider == null || renderer == null) {
				yield return null;
			}

			for (;;) {
				gameObject.SetActive(collider.gameObject.activeSelf && collider.gameObject.activeInHierarchy);
				transform.position = collider.transform.position;
				transform.rotation = collider.transform.rotation;
				transform.localScale = ColliderVisualization.GetHierarchyScale(collider);
				renderer.sharedMaterial = (collider.isTrigger ? ColliderVisualization.triggerMaterial : ColliderVisualization.colliderMaterial);
				visualizerFilter.sharedMesh = collider.sharedMesh;
				yield return ColliderVisualization.wait;
			}
		}
	}
}
