using System;
using System.Collections;
using UnityEngine;

namespace DeveloperToolsetII {
	public class SphereColliderVisualizer : MonoBehaviour {

		public SphereCollider collider;
		private MeshRenderer renderer;

		private void Start() {
			name = collider.name + "Visualizer";
			transform.parent = ColliderVisualization.visualizerParent;
			renderer = GetComponent<MeshRenderer>();
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
				transform.position = collider.transform.TransformPoint(collider.center);
				transform.rotation = collider.transform.rotation;
				transform.localScale = collider.bounds.size;
				renderer.sharedMaterial = (collider.isTrigger ? ColliderVisualization.triggerMaterial : ColliderVisualization.colliderMaterial);
				yield return ColliderVisualization.wait;
			}
		}
	}
}
