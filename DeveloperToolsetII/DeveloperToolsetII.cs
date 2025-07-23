using System;
using System.Collections.Generic;
using DeveloperToolsetII.Properties;
using HutongGames.PlayMaker;
using MSCLoader;
using UnityEngine;

namespace DeveloperToolsetII {
	public class DeveloperToolsetII : Mod {		
		public override string ID => "DeveloperToolsetII";

		public override string Name => "DEVELOPER TOOLSET II";

		public override string Author => "FREDRIK, ZAMP, TOMMOJPHILLIPS";

		public override string Version => "1.7";

		public override string Description => "A MOD TOOL DESIGNED TO GIVE YOU A DETAILED OVERVIEW OF ALL OBJECTS, COMPONENTS AND VARIABLES THE GAME USES.";

		public override byte[] Icon => Properties.Resources.Icon;

        public static SettingsKeybind
            kb_show_gui, 
			kb_raycast_pick,
			kb_copy_obj,
			kb_paste_obj,
            kb_noclip_toggle,
			kb_noclip_fast,
			kb_noclip_slow,
			kb_noclip_front,
			kb_noclip_back,
            kb_noclip_left,
			kb_noclip_right,
			kb_noclip_up,
			kb_noclip_down;

        public static SettingsCheckBox
			menuMouse, 
			componentCollapse,
			variablesPublic,
			variablesPrivate,
			raycastOpen,
			xRayColliders;

        public static SettingsSliderInt
            listCountLimit,
			hierarchyWidth,
			hierarchyHeight,
			inspectorWidth,
			inspectorHeight,
			variableWidth,
			variableHeight,
			noclipRegular,
			noclipFast,
			noclipSlow;
        
		private bool noclip;
        private Collider[] player_colliders;
        private Transform player;
        private Transform player_camera;
        private Transform copy_object;
        private float copy_label_timer;

        public override void ModSetup() {
			SetupFunction(Setup.ModSettings, ModSettings);
			SetupFunction(Setup.ModSettingsLoaded, ModSettingsLoaded);
			SetupFunction(Setup.OnLoad, OnLevelLoaded);
			SetupFunction(Setup.OnMenuLoad, OnLevelLoaded);
			SetupFunction(Setup.Update, UniversalUpdate);
			SetupFunction(Setup.OnGUI, UniversalOnGUI);
		}

		public void ModSettings() {
			kb_show_gui = Keybind.Add("showGUI", "SHOW GUI", KeyCode.Z, KeyCode.LeftControl);
			kb_raycast_pick = Keybind.Add("raycastPick", "PICK OBJECT", (KeyCode)103, KeyCode.LeftControl);
			kb_copy_obj = Keybind.Add("copy", "COPY OBJECT", (KeyCode)99, KeyCode.LeftControl);
            kb_paste_obj = Keybind.Add("paste", "PASTE OBJECT", (KeyCode)118, KeyCode.LeftControl);
			kb_noclip_toggle = Keybind.Add("noclipToggleKey", "NOCLIP TOGGLE", (KeyCode)110, KeyCode.LeftControl);
            kb_noclip_fast = Keybind.Add("noclipFastKey", "NOCLIP FAST", (KeyCode)304);
            kb_noclip_slow = Keybind.Add("noclipSlowKey", "NOCLIP SLOW", (KeyCode)308);
            kb_noclip_front = Keybind.Add("noclipForwardKey", "NOCLIP FORWARD", (KeyCode)119);
            kb_noclip_back = Keybind.Add("noclipBackwardKey", "NOCLIP BACKWARD", (KeyCode)115);
            kb_noclip_left = Keybind.Add("noclipLeftKey", "NOCLIP LEFT", (KeyCode)97);
            kb_noclip_right = Keybind.Add("noclipRightKey", "NOCLIP RIGHT", (KeyCode)100);
            kb_noclip_up = Keybind.Add("noclipUpwardKey", "NOCLIP UPWARD", (KeyCode)122);
            kb_noclip_down = Keybind.Add("noclipDownwardKey", "NOCLIP DOWNWARD", (KeyCode)120);

			Settings.AddHeader("GENERAL SETTINGS");
            menuMouse = Settings.AddCheckBox("menuMouse", "SHOW MOUSE CURSOR ON OPEN", true);
			componentCollapse = Settings.AddCheckBox("componentCollapse", "COLLAPSED COMPONENTS", true, ResetCollapse);
			variablesPublic = Settings.AddCheckBox("variablesPublic", "SHOW PUBLIC VARIABLES", true, VariableVisibility);
			variablesPrivate = Settings.AddCheckBox("variablesPrivate", "SHOW PRIVATE VARIABLES", false, VariableVisibility);
			listCountLimit = Settings.AddSlider("listCountLimit", "LIST COUNT LIMIT", 1, 100, 20, VariableVisibility);
			raycastOpen = Settings.AddCheckBox("raycastOpen", "OPEN GUI ON PICK", true);
			xRayColliders = Settings.AddCheckBox("xRayColliders", "X-RAY COLLIDER VISUALIZATION", true, XRayColliders);
			
			Settings.AddHeader("WINDOW SIZE SETTINGS");
			hierarchyWidth = Settings.AddSlider("hierarchyWidth", "HIERARCHY WIDTH", 200, Screen.width, 600, ChangeDimensions);
			hierarchyHeight = Settings.AddSlider("hierarchyHeight", "HIERARCHY HEIGHT", 200, Screen.height, Screen.height - 5, ChangeDimensions);
			inspectorWidth = Settings.AddSlider("inspectorWidth", "INSPECTOR WIDTH", 200, Screen.width, 400, ChangeDimensions);
			inspectorHeight = Settings.AddSlider("inspectorHeight", "INSPECTOR HEIGHT", 200, Screen.height, Screen.height - 5, ChangeDimensions);
			variableWidth = Settings.AddSlider("variableWidth", "VARIABLE WIDTH", 200, Screen.width, 400, ChangeDimensions);
			variableHeight = Settings.AddSlider("variableHeight", "VARIABLE HEIGHT", 200, Screen.height, (int)((float)(Screen.height - 5) * 0.75f), ChangeDimensions);
           
			Settings.AddHeader("NOCLIP SETTINGS");
			noclipSlow = Settings.AddSlider("noclipSlow", "SLOW SPEED", 1, 10, 10);
			noclipRegular = Settings.AddSlider("noclipRegular", "REGULAR SPEED", 10, 100, 25);
			noclipFast = Settings.AddSlider("noclipFast", "FAST SPEED", 100, 1000, 100);
		}

		public void ModSettingsLoaded() {
			ChangeDimensions();
			VariableVisibility();
		}

		public void OnLevelLoaded() {
            Inspector.Search("");
            ColliderVisualization.Setup();
        }

		public void UniversalUpdate() {
			if (kb_show_gui.GetKeybindDown()) {
				ToggleGUI(!Inspector.GUIVisible);
			}
			RaycastHit raycast_hit;
			if ((kb_raycast_pick.GetKeybind() || kb_copy_obj.GetKeybindDown() || kb_paste_obj.GetKeybindDown()) && Camera.main != null && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raycast_hit) && raycast_hit.collider) {
				if (kb_raycast_pick.GetKeybindDown()) {
					if (raycastOpen.GetValue()) {
						ToggleGUI(true);
					}
					Inspector.Inspect(raycast_hit.collider.transform, false, false);
				}
				if (kb_copy_obj.GetKeybindDown()) {
					copy_object = raycast_hit.collider.transform;
					copy_label_timer = 2f;
				}
			}
			if (kb_paste_obj.GetKeybindDown() && copy_object != null) {
				UnityEngine.Object.Instantiate<GameObject>(copy_object.gameObject).transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2f;
			}
			if (kb_noclip_toggle.GetKeybindDown()) {
				ToggleNoclip();
			}
			if (noclip) {
				Noclip();
			}
		}

		public void UniversalOnGUI() {
			Inspector.OnGUI();
			if (copy_label_timer > 0f) {
				copy_label_timer -= Time.deltaTime;
				GUILayout.BeginArea(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2), 400f, 200f));
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				GUILayout.Label("<b><size=20>" + copy_object.name + " copied!</size></b>", new GUILayoutOption[0]);
				GUILayout.EndHorizontal();
				GUILayout.EndArea();
			}
		}
		private void ToggleGUI(bool show) {
			Inspector.GUIVisible = show;
			if (menuMouse.GetValue() && Application.loadedLevelName == "GAME") {
				FsmVariables.GlobalVariables.FindFsmBool("PlayerInMenu").Value = Inspector.GUIVisible;
			}
		}
		private void ToggleNoclip() {
			noclip = !noclip;
			if (GameObject.Find("PLAYER") == null) {
				noclip = false;
				return;
			}
			player = GameObject.Find("PLAYER").transform;
			player_camera = GameObject.Find("FPSCamera").transform;
			player_colliders = player.GetComponents<Collider>();
			Collider[] array = player_colliders;
			for (int i = 0; i < array.Length; i++) {
				array[i].enabled = !noclip;
			}
		}
		private void Noclip() {
			float num = noclipRegular.GetValue();
			if (kb_noclip_fast.GetKeybind()) {
				num = noclipFast.GetValue();
			}
			if (kb_noclip_slow.GetKeybind()) {
				num = noclipSlow.GetValue();
			}
			num *= Time.deltaTime;
			if (kb_noclip_front.GetKeybind()) {
				player.Translate(player_camera.forward * num, 0);
			}
			if (kb_noclip_back.GetKeybind()) {
				player.Translate(player_camera.forward * -num, 0);
			}
			if (kb_noclip_left.GetKeybind()) {
				player.Translate(Vector3.left * num, Space.Self);
			}
			if (kb_noclip_right.GetKeybind()) {
				player.Translate(Vector3.right * num, Space.Self);
			}
			if (kb_noclip_up.GetKeybind()) {
				player.Translate(Vector3.up * num, Space.Self);
			}
			if (kb_noclip_down.GetKeybind()) {
				player.Translate(Vector3.down * num, Space.Self);
			}
		}
		private void ChangeDimensions() {
			Inspector.hierarchyWidth = hierarchyWidth.GetValue();
			Inspector.hierarchyHeight = hierarchyHeight.GetValue();
			Inspector.inspectorWidth = inspectorWidth.GetValue();
			Inspector.inspectorHeight = inspectorHeight.GetValue();
			Inspector.variableWidth = variableWidth.GetValue();
			Inspector.variableHeight = variableHeight.GetValue();
		}
		private void VariableVisibility() {
			ComponentDisplay.variablesPublic = variablesPublic.GetValue();
			ComponentDisplay.variablesNonPublic = variablesPrivate.GetValue();
			ComponentDisplay.listCountLimit = listCountLimit.GetValue();
		}
		private void ResetCollapse() {
			ComponentDisplay.componentToggle = new Dictionary<Component, bool>();
		}
		private void XRayColliders() {
			bool value = xRayColliders.GetValue();
            ColliderVisualization.colliderMaterial = (value ? ColliderVisualization.colliderMaterialXRay : ColliderVisualization.colliderMaterialRegular);
			ColliderVisualization.triggerMaterial = (value ? ColliderVisualization.triggerMaterialXRay : ColliderVisualization.triggerMaterialRegular);
		}
	}
}
