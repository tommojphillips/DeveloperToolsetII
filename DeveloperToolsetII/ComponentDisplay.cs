using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HutongGames.PlayMaker;
using UnityEngine;
using UnityEngine.UI;

namespace DeveloperToolsetII
{
	public static class ComponentDisplay
	{
		public static void DisplayComponents(Component[] components)
		{
			foreach (Component component in components)
			{
				if (!ComponentDisplay.componentToggle.ContainsKey(component))
				{
					ComponentDisplay.componentToggle.Add(component, component is Transform || !DeveloperToolsetII.componentCollapse.GetValue());
				}
				string text = ComponentDisplay.componentToggle[component] ? "Hide" : "Show";
				if (GUILayout.Button(string.Concat(new string[]
				{
					text,
					" -- <b>",
					component.GetType().ToString().Split(new char[]
					{
						'.'
					}).Last<string>(),
					"</b> -- ",
					text
				}), new GUILayoutOption[]
				{
					GUILayout.MaxWidth((float)Inspector.inspectorWidth)
				}))
				{
					ComponentDisplay.ComponentToggle(component);
				}
				GUILayout.BeginVertical("box", new GUILayoutOption[0]);
				if (ComponentDisplay.componentToggle[component])
				{
					if (!(component is Transform))
					{
						if (!(component is PlayMakerFSM))
						{
							if (!(component is Rigidbody))
							{
								if (!(component is BoxCollider))
								{
									if (!(component is MeshCollider))
									{
										if (!(component is SphereCollider))
										{
											if (!(component is CapsuleCollider))
											{
												if (!(component is CharacterController))
												{
													if (!(component is FixedJoint))
													{
														if (!(component is HingeJoint))
														{
															if (!(component is SpringJoint))
															{
																if (!(component is ConfigurableJoint))
																{
																	if (!(component is Light))
																	{
																		if (!(component is Camera))
																		{
																			if (!(component is TextMesh))
																			{
																				if (!(component is Animation))
																				{
																					if (!(component is MeshFilter))
																					{
																						if (!(component is MeshRenderer))
																						{
																							if (!(component is SkinnedMeshRenderer))
																							{
																								if (!(component is AudioSource))
																								{
																									if (!(component is ParticleAnimator))
																									{
																										if (!(component is ParticleRenderer))
																										{
																											if (!(component is EllipsoidParticleEmitter))
																											{
																												if (!(component is Projector))
																												{
																													if (!(component is ReflectionProbe))
																													{
																														if (!(component is PlayMakerArrayListProxy))
																														{
																															if (!(component is AudioLowPassFilter))
																															{
																																if (!(component is AudioHighPassFilter))
																																{
																																	if (!(component is AudioDistortionFilter))
																																	{
																																		if (!(component is AudioEchoFilter))
																																		{
																																			if (!(component is AudioReverbFilter))
																																			{
																																				if (!(component is AudioChorusFilter))
																																				{
																																					if (!(component is Text))
																																					{
																																						if (!(component is ContentSizeFitter))
																																						{
																																							if (!(component is VerticalLayoutGroup))
																																							{
																																								if (!(component is ScrollRect))
																																								{
																																									if (!(component is LayoutElement))
																																									{
																																										ComponentDisplay.GenericComponentInfo(component);
																																									}
																																									else
																																									{
																																										ComponentDisplay.UILayoutElementInfo(component as LayoutElement);
																																									}
																																								}
																																								else
																																								{
																																									ComponentDisplay.UIScrollRectInfo(component as ScrollRect);
																																								}
																																							}
																																							else
																																							{
																																								ComponentDisplay.UIVerticalLayoutGroupInfo(component as VerticalLayoutGroup);
																																							}
																																						}
																																						else
																																						{
																																							ComponentDisplay.UIContentSizeFitterInfo(component as ContentSizeFitter);
																																						}
																																					}
																																					else
																																					{
																																						ComponentDisplay.UITextInfo(component as Text);
																																					}
																																				}
																																				else
																																				{
																																					ComponentDisplay.AudioChorusFilterInfo(component as AudioChorusFilter);
																																				}
																																			}
																																			else
																																			{
																																				ComponentDisplay.AudioReverbFilterInfo(component as AudioReverbFilter);
																																			}
																																		}
																																		else
																																		{
																																			ComponentDisplay.AudioEchoFilterInfo(component as AudioEchoFilter);
																																		}
																																	}
																																	else
																																	{
																																		ComponentDisplay.AudioDistortionFilterInfo(component as AudioDistortionFilter);
																																	}
																																}
																																else
																																{
																																	ComponentDisplay.AudioHighPassFilterInfo(component as AudioHighPassFilter);
																																}
																															}
																															else
																															{
																																ComponentDisplay.AudioLowPassFilterInfo(component as AudioLowPassFilter);
																															}
																														}
																														else
																														{
																															ComponentDisplay.PlayMakerArrayListProxyInfo(component as PlayMakerArrayListProxy);
																														}
																													}
																													else
																													{
																														ComponentDisplay.ReflectionProbeInfo(component as ReflectionProbe);
																													}
																												}
																												else
																												{
																													ComponentDisplay.ProjectorInfo(component as Projector);
																												}
																											}
																											else
																											{
																												ComponentDisplay.EllipsoidParticleEmitterInfo(component as EllipsoidParticleEmitter);
																											}
																										}
																										else
																										{
																											ComponentDisplay.ParticleRendererInfo(component as ParticleRenderer);
																										}
																									}
																									else
																									{
																										ComponentDisplay.ParticleAnimatorInfo(component as ParticleAnimator);
																									}
																								}
																								else
																								{
																									ComponentDisplay.AudioSourceInfo(component as AudioSource);
																								}
																							}
																							else
																							{
																								ComponentDisplay.SkinnedMeshRendererInfo(component as SkinnedMeshRenderer);
																							}
																						}
																						else
																						{
																							ComponentDisplay.MeshRendererInfo(component as MeshRenderer);
																						}
																					}
																					else
																					{
																						ComponentDisplay.MeshFilterInfo(component as MeshFilter);
																					}
																				}
																				else
																				{
																					ComponentDisplay.AnimationInfo(component as Animation);
																				}
																			}
																			else
																			{
																				ComponentDisplay.TextMeshInfo(component as TextMesh);
																			}
																		}
																		else
																		{
																			ComponentDisplay.CameraInfo(component as Camera);
																		}
																	}
																	else
																	{
																		ComponentDisplay.LightInfo(component as Light);
																	}
																}
																else
																{
																	ComponentDisplay.ConfigurableJointInfo(component as ConfigurableJoint);
																}
															}
															else
															{
																ComponentDisplay.SpringJointInfo(component as SpringJoint);
															}
														}
														else
														{
															ComponentDisplay.HingeJointInfo(component as HingeJoint);
														}
													}
													else
													{
														ComponentDisplay.FixedJointInfo(component as FixedJoint);
													}
												}
												else
												{
													ComponentDisplay.CharacterControllerInfo(component as CharacterController);
												}
											}
											else
											{
												ComponentDisplay.CapsuleColliderInfo(component as CapsuleCollider);
											}
										}
										else
										{
											ComponentDisplay.SphereColliderInfo(component as SphereCollider);
										}
									}
									else
									{
										ComponentDisplay.MeshColliderInfo(component as MeshCollider);
									}
								}
								else
								{
									ComponentDisplay.BoxColliderInfo(component as BoxCollider);
								}
							}
							else
							{
								ComponentDisplay.RigidbodyInfo(component as Rigidbody);
							}
						}
						else
						{
							ComponentDisplay.PlayMakerFSMInfo(component as PlayMakerFSM);
						}
					}
					else
					{
						ComponentDisplay.TransformInfo(component as Transform);
					}
				}
				GUILayout.EndVertical();
			}
		}
		private static void TransformInfo(Transform comp)
		{
			ComponentDisplay.showLocalPosition = ComponentDisplay.DisplayToggle(ComponentDisplay.showLocalPosition, "Show local transform information");
			GUILayout.Space(5f);
			ComponentDisplay.transformIncrement = ComponentDisplay.DisplayTextBox(ComponentDisplay.transformIncrement, "Transform Increment");
			Vector3 vector;
			if (ComponentDisplay.showLocalPosition)
			{
				ComponentDisplay.transformLocalValues[0] = ComponentDisplay.transformLocalValues[0].DisplayVector3("Local Position", string.Format("\n({0}, {1}, {2})", comp.localPosition.x, comp.localPosition.y, comp.localPosition.z));
				if (ComponentDisplay.DisplayTransformIncrementButton(comp.localPosition, out vector))
				{
					comp.localPosition = vector;
				}
				ComponentDisplay.transformLocalValues[1] = ComponentDisplay.transformLocalValues[1].DisplayVector3("Local Rotation, Euler Angles", string.Format("\n({0}, {1}, {2})", comp.localEulerAngles.x, comp.localEulerAngles.y, comp.localEulerAngles.z));
				if (ComponentDisplay.DisplayTransformIncrementButton(comp.localEulerAngles, out vector))
				{
					comp.localEulerAngles = vector;
				}
				GUILayout.Label(string.Format("<b>Local Rotation, Quaternion (X, Y, Z, W):</b>\n({0}, {1}, {2}, {3})", new object[]
				{
					comp.localRotation.x,
					comp.localRotation.y,
					comp.localRotation.z,
					comp.localRotation.w
				}), new GUILayoutOption[]
				{
					GUILayout.MaxWidth((float)Inspector.inspectorWidth)
				});
			}
			else
			{
				ComponentDisplay.transformGlobalValues[0] = ComponentDisplay.transformGlobalValues[0].DisplayVector3("Position", string.Format("\n({0}, {1}, {2})", comp.position.x, comp.position.y, comp.position.z));
				if (ComponentDisplay.DisplayTransformIncrementButton(comp.position, out vector))
				{
					comp.position = vector;
				}
				ComponentDisplay.transformGlobalValues[1] = ComponentDisplay.transformGlobalValues[1].DisplayVector3("Rotation, Euler Angles", string.Format("\n({0}, {1}, {2})", comp.eulerAngles.x, comp.eulerAngles.y, comp.eulerAngles.z));
				if (ComponentDisplay.DisplayTransformIncrementButton(comp.eulerAngles, out vector))
				{
					comp.eulerAngles = vector;
				}
				GUILayout.Label(string.Format("<b>Rotation, Quaternion (X, Y, Z, W):</b>\n({0}, {1}, {2}, {3})", new object[]
				{
					comp.rotation.x,
					comp.rotation.y,
					comp.rotation.z,
					comp.rotation.w
				}), new GUILayoutOption[0]);
			}
			ComponentDisplay.transformScaleValues = ComponentDisplay.transformScaleValues.DisplayVector3("Local Scale", string.Format("\n({0}, {1}, {2})", comp.localScale.x, comp.localScale.y, comp.localScale.z));
			if (ComponentDisplay.DisplayTransformIncrementButton(comp.localScale, out vector))
			{
				comp.localScale = vector;
			}
			comp.gameObject.isStatic = false;
			GUILayout.Space(10f);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Space(10f);
			if (GUILayout.Button("<b>Apply transform values</b>", new GUILayoutOption[0]))
			{
				if (ComponentDisplay.showLocalPosition)
				{
					comp.localPosition = ComponentDisplay.transformLocalValues[0];
					comp.localEulerAngles = ComponentDisplay.transformLocalValues[1];
				}
				else
				{
					comp.position = ComponentDisplay.transformGlobalValues[0];
					comp.eulerAngles = ComponentDisplay.transformGlobalValues[1];
				}
				comp.localScale = ComponentDisplay.transformScaleValues;
			}
			if (GUILayout.Button("<b>Reset transform values</b>", new GUILayoutOption[0]))
			{
				ComponentDisplay.transformLocalValues = new Vector3[]
				{
					comp.localPosition,
					comp.localEulerAngles
				};
				ComponentDisplay.transformGlobalValues = new Vector3[]
				{
					comp.position,
					comp.eulerAngles
				};
				ComponentDisplay.transformScaleValues = comp.localScale;
			}
			GUILayout.Space(10f);
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Space(10f);
			if (GUILayout.Button("<b>Copy transform to clipboard</b>", new GUILayoutOption[0]))
			{
				(ComponentDisplay.showLocalPosition ? (string.Format("localPosition = new Vector3 ({0}f, {1}f, {2}f);", comp.localPosition.x, comp.localPosition.y, comp.localPosition.z) + string.Format("\nlocalEulerAngles = new Vector3 ({0}f, {1}f, {2}f);", comp.localEulerAngles.x, comp.localEulerAngles.y, comp.localEulerAngles.z) + string.Format("\nlocalScale = new Vector3 ({0}f, {1}f, {2}f);", comp.localScale.x, comp.localScale.y, comp.localScale.z)) : (string.Format("position = new Vector3 ({0}f, {1}f, {2}f);", comp.position.x, comp.position.y, comp.position.z) + string.Format("\neulerAngles = new Vector3 ({0}f, {1}f, {2}f);", comp.eulerAngles.x, comp.eulerAngles.y, comp.eulerAngles.z) + string.Format("\nlocalScale = new Vector3 ({0}f, {1}f, {2}f);", comp.localScale.x, comp.localScale.y, comp.localScale.z))).CopyToClipboard();
			}
			if (GUILayout.Button("<b>Teleport to</b>", new GUILayoutOption[0]) && PlayMakerGlobals.Instance.Variables.FindFsmGameObject("SavePlayer").Value != null)
			{
				PlayMakerGlobals.Instance.Variables.FindFsmGameObject("SavePlayer").Value.transform.position = comp.position + new Vector3(0f, 2f, 0f);
			}
			GUILayout.Space(10f);
			GUILayout.EndHorizontal();
			GUILayout.Space(5f);
		}
		private static void PlayMakerFSMInfo(PlayMakerFSM fsm)
		{
			fsm.enabled = ComponentDisplay.DisplayEnabled(fsm.enabled);
			GUILayout.Label(string.Concat(new string[]
			{
				"<b>FSM Name: </b>",
				fsm.Fsm.Name,
				" (",
				fsm.enabled ? "Enabled" : "Disabled",
				") (",
				fsm.Active ? "Active" : "Inactive",
				")"
			}), new GUILayoutOption[0]);
			if (!ComponentDisplay.fsmToggles.ContainsKey(fsm))
			{
				ComponentDisplay.fsmToggles.Add(fsm, new bool[4]);
			}
			ComponentDisplay.DisplayFSMExpandButton(fsm, "Variables", 0);
			if (fsm.GetFsmVisibility(0))
			{
				VariableDisplay.DisplayVariables(fsm.FsmVariables);
			}
			ComponentDisplay.DisplayFSMExpandButton(fsm, "Global Transitions", 1);
			if (fsm.GetFsmVisibility(1))
			{
				foreach (FsmTransition fsmTransition in fsm.FsmGlobalTransitions)
				{
					GUILayout.Label("Event: \"" + fsmTransition.EventName + "\" To State: " + fsmTransition.ToState, new GUILayoutOption[0]);
				}
			}
			ComponentDisplay.DisplayFSMExpandButton(fsm, "States", 2);
			if (fsm.GetFsmVisibility(2))
			{
				Inspector.BeginBox();
				foreach (FsmState fsmState in fsm.FsmStates)
				{
					if (!ComponentDisplay.stateToggle.ContainsKey(fsmState))
					{
						ComponentDisplay.stateToggle.Add(fsmState, false);
					}
					GUILayout.BeginHorizontal(new GUILayoutOption[0]);
					GUILayout.Space(20f);
					string text = ComponentDisplay.stateToggle[fsmState] ? "Hide" : "Show";
					if (GUILayout.Button(string.Concat(new string[]
					{
						text,
						" - <b>",
						fsmState.Name,
						"</b>",
						fsm.ActiveStateName.Equals(fsmState.Name) ? " (active)" : "",
						" - ",
						text
					}), new GUILayoutOption[0]))
					{
						ComponentDisplay.stateToggle[fsmState] = !ComponentDisplay.stateToggle[fsmState];
					}
					GUILayout.EndHorizontal();
					Inspector.BeginBox();
					if (ComponentDisplay.stateToggle[fsmState])
					{
						if (fsmState.Transitions.Count<FsmTransition>() > 0)
						{
							GUILayout.Label("<b>Transitions:</b>", new GUILayoutOption[0]);
							foreach (FsmTransition fsmTransition2 in fsmState.Transitions)
							{
								GUILayout.Label(string.Concat(new string[]
								{
									"   Event(",
									fsmTransition2.EventName,
									") To State(",
									fsmTransition2.ToState,
									")"
								}), new GUILayoutOption[0]);
							}
							GUILayout.Space(5f);
						}
						GUILayout.Label("<b>Actions:</b>", new GUILayoutOption[0]);
						ActionDisplay.DisplayActions(fsmState.Actions);
						FieldInfo[] fields = fsmState.ActionData.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
						if (fields.Count<FieldInfo>() > 0)
						{
							GUILayout.Label("ActionData:", new GUILayoutOption[0]);
							Inspector.BeginBox();
							foreach (FieldInfo fieldInfo in fields)
							{
								GUILayout.BeginHorizontal(new GUILayoutOption[0]);
								try
								{
									object value = fieldInfo.GetValue(fsmState.ActionData);
									string text2 = value.ToString();
									text2 = text2.Substring(text2.LastIndexOf(".", StringComparison.Ordinal) + 1);
									if (value is NamedVariable)
									{
										GUILayout.Label(string.Concat(new string[]
										{
											fieldInfo.Name,
											": ",
											text2,
											" (",
											(value as NamedVariable).Name,
											")"
										}), new GUILayoutOption[0]);
									}
									else if (value is FsmEvent)
									{
										GUILayout.Label(string.Concat(new string[]
										{
											fieldInfo.Name,
											": ",
											text2,
											" (",
											(value as FsmEvent).Name,
											")"
										}), new GUILayoutOption[0]);
									}
									else
									{
										GUILayout.Label(fieldInfo.Name + ": " + text2, new GUILayoutOption[0]);
									}
								}
								catch (Exception)
								{
									GUILayout.Label(fieldInfo.Name, new GUILayoutOption[0]);
								}
								GUILayout.EndHorizontal();
							}
							Inspector.EndBox();
						}
					}
					Inspector.EndBox();
				}
				Inspector.EndBox();
			}
			ComponentDisplay.DisplayFSMExpandButton(fsm, "Events", 3);
			if (fsm.GetFsmVisibility(3))
			{
				foreach (FsmEvent fsmEvent in fsm.FsmEvents)
				{
					GUILayout.BeginHorizontal(new GUILayoutOption[0]);
					GUILayout.Label("\"" + fsmEvent.Name + "\"", new GUILayoutOption[0]);
					if (GUILayout.Button("Send Event", new GUILayoutOption[]
					{
						GUILayout.Width(100f)
					}))
					{
						fsm.SendEvent(fsmEvent.Name);
					}
					GUILayout.EndHorizontal();
				}
			}
		}
		private static void RigidbodyInfo(Rigidbody comp)
		{
			comp.mass = ComponentDisplay.DisplayTextBox(comp.mass, "Mass");
			comp.drag = ComponentDisplay.DisplayTextBox(comp.drag, "Drag");
			comp.angularDrag = ComponentDisplay.DisplayTextBox(comp.angularDrag, "Angular Drag");
			comp.useGravity = ComponentDisplay.DisplayToggle(comp.useGravity, "Use Gravity");
			comp.isKinematic = ComponentDisplay.DisplayToggle(comp.isKinematic, "Is Kinematic");
			comp.interpolation = (RigidbodyInterpolation)ComponentDisplay.DisplaySlider((int)comp.interpolation, 0, 2, string.Format("<b>Interpolate:</b> {0}", comp.interpolation));
			comp.collisionDetectionMode = (CollisionDetectionMode)ComponentDisplay.DisplaySlider((int)comp.collisionDetectionMode, 0, 2, string.Format("<b>Collision Detection:</b> {0}", comp.collisionDetectionMode));
			GUILayout.Label("<b>Constraints:</b> (Change at own risk!)", new GUILayoutOption[0]);
			Inspector.BeginBox();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("<b>Freeze Position:</b>", new GUILayoutOption[0]);
			bool flag = ComponentDisplay.DisplayToggle((comp.constraints & (RigidbodyConstraints)2) == (RigidbodyConstraints)2, "");
			GUILayout.Label("<b>X:</b>", new GUILayoutOption[0]);
			bool flag2 = ComponentDisplay.DisplayToggle((comp.constraints & (RigidbodyConstraints)4) == (RigidbodyConstraints)4, "");
			GUILayout.Label("<b>Y:</b>", new GUILayoutOption[0]);
			bool flag3 = ComponentDisplay.DisplayToggle((comp.constraints & (RigidbodyConstraints)8) == (RigidbodyConstraints)8, "");
			GUILayout.Label("<b>Z:</b>", new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("<b>Freeze Rotation:</b>", new GUILayoutOption[0]);
			bool flag4 = ComponentDisplay.DisplayToggle((comp.constraints & (RigidbodyConstraints)16) == (RigidbodyConstraints)16, "");
			GUILayout.Label("<b>X</b>", new GUILayoutOption[0]);
			bool flag5 = ComponentDisplay.DisplayToggle((comp.constraints & (RigidbodyConstraints)32) == (RigidbodyConstraints)32, "");
			GUILayout.Label("<b>Y</b>", new GUILayoutOption[0]);
			bool flag6 = ComponentDisplay.DisplayToggle((comp.constraints & (RigidbodyConstraints)64) == (RigidbodyConstraints)64, "");
			GUILayout.Label("<b>Z</b>", new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			RigidbodyConstraints rigidbodyConstraints = 0;
			if (flag)
			{
				rigidbodyConstraints |= (RigidbodyConstraints)2;
			}
			if (flag2)
			{
				rigidbodyConstraints |= (RigidbodyConstraints)4;
			}
			if (flag3)
			{
				rigidbodyConstraints |= (RigidbodyConstraints)8;
			}
			comp.freezeRotation = false;
			if (flag4)
			{
				rigidbodyConstraints |= (RigidbodyConstraints)16;
			}
			if (flag5)
			{
				rigidbodyConstraints |= (RigidbodyConstraints)32;
			}
			if (flag6)
			{
				rigidbodyConstraints |= (RigidbodyConstraints)64;
			}
			comp.constraints = rigidbodyConstraints;
			GUILayout.Space(7.5f);
			Inspector.EndBox();
			comp.detectCollisions = ComponentDisplay.DisplayToggle(comp.detectCollisions, "Detect Collisions");
			comp.centerOfMass = comp.centerOfMass.DisplayVector3("Center of Mass", "");
			new string[]
			{
				string.Format("<b>World Center of Mass:</b> {0}", comp.worldCenterOfMass),
				string.Format("<b>Velocity:</b> {0}", comp.velocity.magnitude),
				string.Format("<b>Velocity Vector:</b> {0}", comp.velocity),
				string.Format("<b>Inertia Tensor:</b> {0}", comp.inertiaTensor)
			}.DisplayLabels();
		}
		private static void BoxColliderInfo(BoxCollider comp)
		{
			ColliderVisualization.DisplayVisualizerButton(comp);
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			comp.isTrigger = ComponentDisplay.DisplayToggle(comp.isTrigger, "Is Trigger");
			comp.sharedMaterial.DisplayPhysicMaterial();
			comp.center = comp.center.DisplayVector3("Center", "");
			comp.size = comp.size.DisplayVector3("Size", "");
		}
		private static void MeshColliderInfo(MeshCollider comp)
		{
			ColliderVisualization.DisplayVisualizerButton(comp);
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			GUILayout.Label(string.Format("<b>Convex:</b> {0}", comp.convex), new GUILayoutOption[0]);
			if (comp.convex)
			{
				comp.isTrigger = ComponentDisplay.DisplayToggle(comp.isTrigger, "Is Trigger");
			}
			else
			{
				GUILayout.Label(string.Format("<b>Is Trigger:</b> {0}", comp.isTrigger), new GUILayoutOption[0]);
			}
			comp.sharedMaterial.DisplayPhysicMaterial();
			GUILayout.Label(string.Format("<b>Mesh:</b> {0}", comp.sharedMesh), new GUILayoutOption[0]);
			comp.sharedMesh.DisplayMeshInfo("Mesh");
		}
		private static void SphereColliderInfo(SphereCollider comp)
		{
			ColliderVisualization.DisplayVisualizerButton(comp);
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			comp.isTrigger = ComponentDisplay.DisplayToggle(comp.isTrigger, "Is Trigger");
			comp.sharedMaterial.DisplayPhysicMaterial();
			comp.center = comp.center.DisplayVector3("Center", "");
			comp.radius = ComponentDisplay.DisplayTextBox(comp.radius, "Radius");
		}
		private static void CapsuleColliderInfo(CapsuleCollider comp)
		{
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			comp.isTrigger = ComponentDisplay.DisplayToggle(comp.isTrigger, "Is Trigger");
			comp.sharedMaterial.DisplayPhysicMaterial();
			comp.center = comp.center.DisplayVector3("Center", "");
			comp.radius = ComponentDisplay.DisplayTextBox(comp.radius, "Radius");
			comp.height = ComponentDisplay.DisplayTextBox(comp.height, "Height");
			comp.direction = ComponentDisplay.DisplaySlider(comp.direction, 0, 2, "<b>Direction:</b> " + (new string[]
			{
				"X-Axis",
				"Y-axis",
				"Z-axis"
			})[comp.direction]);
		}
		private static void CharacterControllerInfo(CharacterController comp)
		{
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			new string[]
			{
				string.Format("<b>Slope Limit:</b> {0}", comp.slopeLimit),
				string.Format("<b>Step Offset:</b> {0}", comp.stepOffset),
				string.Format("<b>Center (X, Y, Z):</b> {0}", comp.center),
				string.Format("<b>Radius:</b> {0}", comp.radius),
				string.Format("<b>Height:</b> {0}", comp.height),
				string.Format("<b>Velocity:</b> {0}", comp.velocity.magnitude),
				string.Format("<b>Velocity Vector (X, Y, Z):</b> {0}", comp.velocity)
			}.DisplayLabels();
		}
		private static void FixedJointInfo(FixedJoint comp)
		{
			ComponentDisplay.DisplayReferenceButton(comp.connectedBody, "Connected Body");
			comp.breakForce = ComponentDisplay.DisplayTextBox(comp.breakForce, "Break Force");
			comp.breakTorque = ComponentDisplay.DisplayTextBox(comp.breakTorque, "Break Torque");
			comp.enableCollision = ComponentDisplay.DisplayToggle(comp.enableCollision, "Enable Collision");
			comp.enablePreprocessing = ComponentDisplay.DisplayToggle(comp.enablePreprocessing, "Enable Preprocessing");
		}
		private static void HingeJointInfo(HingeJoint comp)
		{
			ComponentDisplay.DisplayReferenceButton(comp.connectedBody, "Connected Body");
			new string[]
			{
				string.Format("<b>Anchor:\n   X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.anchor.x, comp.anchor.y, comp.anchor.z),
				string.Format("<b>Axis:\n   X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.axis.x, comp.axis.y, comp.axis.z),
				string.Format("<b>Auto Configure Connected Anchor:</b> {0}", comp.autoConfigureConnectedAnchor),
				string.Format("<b>Connected Anchor:\n   X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.connectedAnchor.x, comp.connectedAnchor.y, comp.connectedAnchor.z),
				string.Format("\n<b>Use Spring:</b> {0}", comp.useSpring),
				"<b>Spring:</b>"
			}.DisplayLabels();
			Inspector.BeginBox();
			new string[]
			{
				string.Format("<b>Spring:</b> {0}", comp.spring.spring),
				string.Format("<b>Damper:</b> {0}", comp.spring.damper),
				string.Format("<b>Target Position:</b> {0}", comp.spring.targetPosition)
			}.DisplayLabels();
			Inspector.EndBox();
			GUILayout.Label(string.Format("<b>Use Motor:</b> {0}", comp.useMotor), new GUILayoutOption[0]);
			GUILayout.Label("<b>Motor:</b>", new GUILayoutOption[0]);
			Inspector.BeginBox();
			new string[]
			{
				string.Format("<b>Target Velocity:</b> {0}", comp.motor.targetVelocity),
				string.Format("<b>Force:</b> {0}", comp.motor.force),
				string.Format("<b>Free Spin:</b> {0}", comp.motor.freeSpin)
			}.DisplayLabels();
			Inspector.EndBox();
			GUILayout.Label(string.Format("<b>Use Limits:</b> {0}", comp.useLimits), new GUILayoutOption[0]);
			GUILayout.Label("<b>Limits:</b>", new GUILayoutOption[0]);
			Inspector.BeginBox();
			new string[]
			{
				string.Format("<b>Min:</b> {0}", comp.limits.min),
				string.Format("<b>Max:</b> {0}", comp.limits.max),
				string.Format("<b>Min Bounce:</b> {0}", comp.limits.minBounce),
				string.Format("<b>Max Bounce:</b> {0}", comp.limits.maxBounce),
				string.Format("<b>Contact Distance:</b> {0}", comp.limits.contactDistance)
			}.DisplayLabels();
			Inspector.EndBox();
			comp.breakForce = ComponentDisplay.DisplayTextBox(comp.breakForce, "Break Force");
			comp.breakTorque = ComponentDisplay.DisplayTextBox(comp.breakTorque, "Break Torque");
			comp.enableCollision = ComponentDisplay.DisplayToggle(comp.enableCollision, "Enable Collision");
			comp.enablePreprocessing = ComponentDisplay.DisplayToggle(comp.enablePreprocessing, "Enable Preprocessing");
		}
		private static void SpringJointInfo(SpringJoint comp)
		{
			ComponentDisplay.DisplayReferenceButton(comp.connectedBody, "Connected Body");
			new string[]
			{
				string.Format("<b>Anchor:\n   X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.anchor.x, comp.anchor.y, comp.anchor.z),
				string.Format("<b>Auto Configure Connected Anchor:</b> {0}", comp.autoConfigureConnectedAnchor),
				string.Format("<b>Connected Anchor:\n   X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.connectedAnchor.x, comp.connectedAnchor.y, comp.connectedAnchor.z)
			}.DisplayLabels();
			comp.spring = ComponentDisplay.DisplayTextBox(comp.spring, "Spring");
			comp.damper = ComponentDisplay.DisplayTextBox(comp.damper, "Damper");
			comp.minDistance = ComponentDisplay.DisplayTextBox(comp.minDistance, "Min Distance");
			comp.maxDistance = ComponentDisplay.DisplayTextBox(comp.maxDistance, "Max Distance");
			comp.breakForce = ComponentDisplay.DisplayTextBox(comp.breakForce, "Break Force");
			comp.breakTorque = ComponentDisplay.DisplayTextBox(comp.breakTorque, "Break Torque");
			comp.enableCollision = ComponentDisplay.DisplayToggle(comp.enableCollision, "Enable Collision");
			comp.enablePreprocessing = ComponentDisplay.DisplayToggle(comp.enablePreprocessing, "Enable Preprocessing");
		}
		private static void ConfigurableJointInfo(ConfigurableJoint comp)
		{
			ComponentDisplay.DisplayReferenceButton(comp.connectedBody, "Connected Body");
			new string[]
			{
				string.Format("<b>Anchor:\n   X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.anchor.x, comp.anchor.y, comp.anchor.z),
				string.Format("<b>Axis:\n   X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.axis.x, comp.axis.y, comp.axis.z),
				string.Format("<b>Auto Configure Connected Anchor:</b> {0}", comp.autoConfigureConnectedAnchor),
				string.Format("<b>Connected Anchor:\n   X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.connectedAnchor.x, comp.connectedAnchor.y, comp.connectedAnchor.z),
				string.Format("<b>Secondary Axis:\n   X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.secondaryAxis.x, comp.secondaryAxis.y, comp.secondaryAxis.z),
				string.Format("<b>X Motion:</b> {0}", comp.xMotion),
				string.Format("<b>Y Motion:</b> {0}", comp.yMotion),
				string.Format("<b>Z Motion:</b> {0}", comp.zMotion),
				string.Format("<b>Angular X Motion:</b> {0}", comp.angularXMotion),
				string.Format("<b>Angular Y Motion:</b> {0}", comp.angularYMotion),
				string.Format("<b>Angular Z Motion:</b> {0}", comp.angularZMotion),
				string.Format("<b>Linear Limit Spring:\n   Spring:</b> {0}\n   <b>Damper:</b> {1}", comp.linearLimitSpring.spring, comp.linearLimitSpring.damper),
				string.Format("<b>Linear Limit:\n   Limit:</b> {0}\n   <b>Bounciness:</b> {1}\n   <b>Contact Distance:</b> {2}", comp.linearLimit.limit, comp.linearLimit.bounciness, comp.linearLimit.contactDistance),
				string.Format("<b>Angular X Limit Spring:\n   Spring:</b> {0}\n   <b>Damper:</b> {1}", comp.angularXLimitSpring.spring, comp.angularXLimitSpring.damper),
				string.Format("<b>Low Angular X Limit:\n   Limit:</b> {0}\n   <b>Bounciness:</b> {1}\n   <b>Contact Distance:</b> {2}", comp.lowAngularXLimit.limit, comp.lowAngularXLimit.bounciness, comp.lowAngularXLimit.contactDistance),
				string.Format("<b>High Angular X Limit:\n   Limit:</b> {0}\n   <b>Bounciness:</b> {1}\n   <b>Contact Distance:</b> {2}", comp.highAngularXLimit.limit, comp.highAngularXLimit.bounciness, comp.highAngularXLimit.contactDistance),
				string.Format("<b>Angular YZ Limit Spring:\n   Spring:</b> {0}\n   <b>Damper:</b> {1}", comp.angularYZLimitSpring.spring, comp.angularYZLimitSpring.damper),
				string.Format("<b>Angular Y Limit:\n   Limit:</b> {0}\n   <b>Bounciness:</b> {1}\n   <b>Contact Distance:</b> {2}", comp.angularYLimit.limit, comp.angularYLimit.bounciness, comp.angularYLimit.contactDistance),
				string.Format("<b>Angular Z Limit:\n   Limit:</b> {0}\n   <b>Bounciness:</b> {1}\n   <b>Contact Distance:</b> {2}", comp.angularZLimit.limit, comp.angularZLimit.bounciness, comp.angularZLimit.contactDistance),
				string.Format("<b>Target Position:\n   X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.targetPosition.x, comp.targetPosition.y, comp.targetPosition.z),
				string.Format("<b>Target Velocity:\n   X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.targetVelocity.x, comp.targetVelocity.y, comp.targetVelocity.z),
				string.Format("<b>X Drive:\n   Mode:</b> {0}\n   <b>Position Spring:</b> {1}\n   <b>Position Damper:</b> {2}\n   <b>Maximum Force:</b> {3}", new object[]
				{
					comp.xDrive.mode,
					comp.xDrive.positionSpring,
					comp.xDrive.positionDamper,
					comp.xDrive.maximumForce
				}),
				string.Format("<b>Y Drive:\n   Mode:</b> {0}\n   <b>Position Spring:</b> {1}\n   <b>Position Damper:</b> {2}\n   <b>Maximum Force:</b> {3}", new object[]
				{
					comp.yDrive.mode,
					comp.yDrive.positionSpring,
					comp.yDrive.positionDamper,
					comp.yDrive.maximumForce
				}),
				string.Format("<b>Z Drive:\n   Mode:</b> {0}\n   <b>Position Spring:</b> {1}\n   <b>Position Damper:</b> {2}\n   <b>Maximum Force:</b> {3}", new object[]
				{
					comp.zDrive.mode,
					comp.zDrive.positionSpring,
					comp.zDrive.positionDamper,
					comp.zDrive.maximumForce
				}),
				string.Format("<b>Target Rotation:\n   X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}<b>, W:</b> {3}", new object[]
				{
					comp.targetRotation.x,
					comp.targetRotation.y,
					comp.targetRotation.z,
					comp.targetRotation.w
				}),
				string.Format("<b>Target Angular Velocity:\n   X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.targetAngularVelocity.x, comp.targetAngularVelocity.y, comp.targetAngularVelocity.z),
				string.Format("<b>Rotation Drive Mode:</b> {0}", comp.rotationDriveMode),
				string.Format("<b>Angular X Drive:\n   Mode:</b> {0}\n   <b>Position Spring:</b> {1}\n   <b>Position Damper:</b> {2}\n   <b>Maximum Force:</b> {3}", new object[]
				{
					comp.angularXDrive.mode,
					comp.angularXDrive.positionSpring,
					comp.angularXDrive.positionDamper,
					comp.angularXDrive.maximumForce
				}),
				string.Format("<b>Angular YZ Drive:\n   Mode:</b> {0}\n   <b>Position Spring:</b> {1}\n   <b>Position Damper:</b> {2}\n   <b>Maximum Force:</b> {3}", new object[]
				{
					comp.angularYZDrive.mode,
					comp.angularYZDrive.positionSpring,
					comp.angularYZDrive.positionDamper,
					comp.angularYZDrive.maximumForce
				}),
				string.Format("<b>Slerp Drive:\n   Mode:</b> {0}\n   <b>Position Spring:</b> {1}\n   <b>Position Damper:</b> {2}\n   <b>Maximum Force:</b> {3}", new object[]
				{
					comp.slerpDrive.mode,
					comp.slerpDrive.positionSpring,
					comp.slerpDrive.positionDamper,
					comp.slerpDrive.maximumForce
				}),
				string.Format("<b>Projection Mode:</b> {0}", comp.projectionMode),
				string.Format("<b>Projection Distance:</b> {0}", comp.projectionDistance),
				string.Format("<b>Projection Angle:</b> {0}", comp.projectionAngle),
				string.Format("<b>Configured In World:</b> {0}", comp.configuredInWorldSpace),
				string.Format("<b>Swap Bodies:</b> {0}", comp.swapBodies),
				string.Format("<b>Break Force:</b> {0}", comp.breakForce),
				string.Format("<b>Break Torque:</b> {0}", comp.breakTorque),
				string.Format("<b>Enable Collision:</b> {0}", comp.enableCollision),
				string.Format("<b>Enable Preprocessing:</b> {0}", comp.enablePreprocessing)
			}.DisplayLabels();
		}
		private static void LightInfo(Light comp) {
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			GUILayout.Label(string.Format("<b>Type:</b> {0}", comp.type), new GUILayoutOption[0]);
			if (comp.type == LightType.Point) {
				comp.range = ComponentDisplay.DisplayTextBox(comp.range, "Range");
			}
			if (comp.type == LightType.Spot) {
				comp.spotAngle = ComponentDisplay.DisplayTextBox(comp.spotAngle, "Spot Angle");
			}
			comp.color = ComponentDisplay.DisplayColor(comp.color, "Color");
			comp.intensity = ComponentDisplay.DisplayTextBox(comp.intensity, "Intensity");
			comp.bounceIntensity = ComponentDisplay.DisplayTextBox(comp.bounceIntensity, "Bounce Intensity");
			comp.shadows = (LightShadows)ComponentDisplay.DisplaySlider((int)comp.shadows, 0, 2, string.Format("<b>Shadow Type:</b> {0}", comp.shadows));
			GUILayout.Label(string.Format("<b>Cookie:</b> {0}", comp.cookie), new GUILayoutOption[0]);
			if (comp.type == LightType.Directional) {
				comp.cookieSize = ComponentDisplay.DisplayTextBox(comp.cookieSize, "Cookie Size");
			}
			new string[] {
				string.Format("<b>Flare:</b> {0}", comp.flare),
				string.Format("<b>Render Mode:</b> {0}", comp.renderMode),
				string.Format("<b>Culling Mask:</b> {0}", comp.cullingMask)
			}.DisplayLabels();
		}
		private static void CameraInfo(Camera comp) {
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			GUILayout.Label(string.Format("<b>Clear Flags:</b> {0}", comp.clearFlags), new GUILayoutOption[0]);
			if (comp.clearFlags <= (CameraClearFlags)2) {
				comp.backgroundColor = ComponentDisplay.DisplayColor(comp.backgroundColor, "Background");
			}
			GUILayout.Label(string.Format("<b>Culling Mask:</b> {0}", comp.cullingMask), new GUILayoutOption[0]);
			Inspector.BeginBox();
			foreach (int num in ComponentDisplay.GetLayerMask(comp.cullingMask)) {
				GUILayout.Label(string.Format("{0} [{1}]", LayerMask.LayerToName(num), num), new GUILayoutOption[0]);
			}
			Inspector.EndBox();
			new string[] {
				string.Format("<b>Projection:</b> ({0}) {1}", comp.orthographic, comp.orthographic ? "Orthographic" : "Perspective"),
				comp.orthographic ? string.Format("    <b>Size:</b> {0}", comp.orthographicSize) : string.Format("    <b>Field Of View:</b> {0}", comp.fieldOfView),
				"<b>Clipping Planes:</b>"
			}.DisplayLabels();
			comp.nearClipPlane = ComponentDisplay.DisplayTextBox(comp.nearClipPlane, "   Near");
			comp.farClipPlane = ComponentDisplay.DisplayTextBox(comp.farClipPlane, "   Far");
			new string[] {
				"<b>Viewport Rect:</b>",
				string.Format("   <b>X:</b> {0}   <b>Y:</b> {1}", comp.rect.x, comp.rect.y),
				string.Format("   <b>W:</b> {0}   <b>H:</b> {1}", comp.rect.width, comp.rect.height),
				string.Format("<b>Depth:</b> {0}", comp.depth),
				string.Format("<b>Rendering Path:</b> {0}", comp.renderingPath),
				string.Format("<b>Target Texture:</b> {0}", comp.targetTexture),
				string.Format("<b>Occlusion Culling:</b> {0}", comp.useOcclusionCulling),
				string.Format("<b>HDR:</b> {0}", comp.hdr)
			}.DisplayLabels();
		}
		private static void TextMeshInfo(TextMesh comp)
		{
			GUILayout.Label("<b>Text:</b>", new GUILayoutOption[0]);
			comp.text = GUILayout.TextArea(comp.text, new GUILayoutOption[0]);
			comp.offsetZ = ComponentDisplay.DisplayTextBox(comp.offsetZ, "Offset Z");
			comp.characterSize = ComponentDisplay.DisplayTextBox(comp.characterSize, "Character Size");
			comp.lineSpacing = ComponentDisplay.DisplayTextBox(comp.lineSpacing, "Line Spacing");
			comp.anchor = (TextAnchor)ComponentDisplay.DisplaySlider((int)comp.anchor, 0, 8, string.Format("<b>Anchor:</b> {0}", comp.anchor));
			comp.alignment = (TextAlignment)ComponentDisplay.DisplaySlider((int)comp.alignment, 0, 2, string.Format("<b>Alignment:</b> {0}", comp.alignment));
			comp.tabSize = ComponentDisplay.DisplayTextBox(comp.tabSize, "Tab Size");
			comp.fontSize = ComponentDisplay.DisplayTextBox(comp.fontSize, "Font Size");
			comp.fontStyle = (FontStyle)ComponentDisplay.DisplaySlider((int)comp.fontStyle, 0, 3, string.Format("<b>Font Style:</b> {0}", comp.fontStyle));
			comp.richText = ComponentDisplay.DisplayToggle(comp.richText, "Rich Text");
			GUILayout.Label(string.Format("<b>Font:</b> {0}", comp.font), new GUILayoutOption[0]);
			comp.color = ComponentDisplay.DisplayColor(comp.color, "Color");
		}
		private static void AnimationInfo(Animation comp)
		{
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			GUILayout.Label(string.Format("<b>Animation clip:</b> {0}", comp.clip), new GUILayoutOption[0]);
			bool flag = false;
			int num = 0;
			foreach (object obj in comp)
			{
				AnimationState animationState = (AnimationState)obj;
				if (!flag)
				{
					flag = true;
					GUILayout.Label("<b>Animation clips:</b>", new GUILayoutOption[0]);
					Inspector.BeginBox();
				}
				GUILayout.Label(string.Format("<b>Clip {0}:</b> {1}", num, animationState.clip), new GUILayoutOption[0]);
				num++;
			}
			if (flag)
			{
				Inspector.EndBox();
			}
			new string[]
			{
				string.Format("<b>Play Automatically:</b> {0}", comp.playAutomatically),
				string.Format("<b>Animate Physics:</b> {0}", comp.animatePhysics),
				string.Format("<b>Culling Type:</b> {0}", comp.cullingType)
			}.DisplayLabels();
			if (GUILayout.Button("Play Animation", new GUILayoutOption[0]) && !comp.isPlaying && comp.clip != null)
			{
				comp.Play();
			}
		}
		private static void MeshFilterInfo(MeshFilter comp)
		{
			GUILayout.Label(string.Format("<b>Mesh:</b> {0}", comp.mesh), new GUILayoutOption[0]);
			comp.mesh.DisplayMeshInfo("Mesh");
			GUILayout.Label(string.Format("<b>Shared Mesh:</b> {0}", comp.sharedMesh), new GUILayoutOption[0]);
			comp.sharedMesh.DisplayMeshInfo("Shared Mesh");
		}
		private static void MeshRendererInfo(MeshRenderer comp)
		{
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			GUILayout.Label(string.Format("<b>Cast Shadows:</b> {0}", comp.shadowCastingMode), new GUILayoutOption[0]);
			GUILayout.Label(string.Format("<b>Receive Shadows:</b> {0}", comp.receiveShadows), new GUILayoutOption[0]);
			comp.sharedMaterials.DisplayMaterials();
			new string[]
			{
				string.Format("<b>Use Light Probes:</b> {0}", comp.useLightProbes),
				string.Format("<b>Reflection Probes:</b> {0}", comp.reflectionProbeUsage),
				string.Format("<b>Anchor Override:</b> {0}", comp.probeAnchor),
				string.Format("<b>Part Of Static Batch:</b> {0}", comp.isPartOfStaticBatch)
			}.DisplayLabels();
		}
		private static void SkinnedMeshRendererInfo(SkinnedMeshRenderer comp)
		{
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			GUILayout.Label(string.Format("<b>Cast Shadows:</b> {0}", comp.shadowCastingMode), new GUILayoutOption[0]);
			GUILayout.Label(string.Format("<b>Receive Shadows:</b> {0}", comp.receiveShadows), new GUILayoutOption[0]);
			comp.sharedMaterials.DisplayMaterials();
			new string[]
			{
				string.Format("<b>Use Light Probes:</b> {0}", comp.useLightProbes),
				string.Format("<b>Reflection Probes:</b> {0}", comp.reflectionProbeUsage),
				string.Format("<b>Anchor Override:</b> {0}", comp.probeAnchor),
				string.Format("<b>Update When Offscreen:</b> {0}", comp.updateWhenOffscreen)
			}.DisplayLabels();
			GUILayout.Label(string.Format("<b>Mesh:</b> {0}", comp.sharedMesh), new GUILayoutOption[0]);
			comp.sharedMesh.DisplayMeshInfo("Mesh");
			new string[]
			{
				string.Format("<b>Root Bone:</b> {0}", comp.rootBone),
				string.Format("<b>Bounds:</b> {0}", comp.bounds),
				string.Format("<b>Local Bounds:</b> {0}", comp.localBounds),
				string.Format("<b>Part Of Static Batch:</b> {0}", comp.isPartOfStaticBatch)
			}.DisplayLabels();
		}
		private static void AudioSourceInfo(AudioSource comp)
		{
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("<b>Audio Clip:</b> " + comp.clip.name, new GUILayoutOption[0]);
			if (GUILayout.Button((comp.isPlaying ? "Stop" : "Play") + " Audio", new GUILayoutOption[0]))
			{
				if (comp.isPlaying)
				{
					comp.Stop();
				}
				else
				{
					comp.Play();
				}
			}
			GUILayout.EndHorizontal();
			GUILayout.Label(string.Format("<b>Output:</b> {0}", comp.outputAudioMixerGroup), new GUILayoutOption[0]);
			comp.mute = ComponentDisplay.DisplayToggle(comp.mute, "Mute");
			comp.bypassEffects = ComponentDisplay.DisplayToggle(comp.bypassEffects, "Bypass Effects");
			comp.bypassListenerEffects = ComponentDisplay.DisplayToggle(comp.bypassListenerEffects, "Bypass Listener Effects");
			comp.bypassReverbZones = ComponentDisplay.DisplayToggle(comp.bypassReverbZones, "Bypass Reverb Zones");
			comp.playOnAwake = ComponentDisplay.DisplayToggle(comp.playOnAwake, "Play On Awake");
			comp.loop = ComponentDisplay.DisplayToggle(comp.loop, "Loop");
			GUILayout.Space(5f);
			comp.priority = ComponentDisplay.DisplayTextBox(comp.priority, "Priority");
			comp.volume = ComponentDisplay.DisplayTextBox(comp.volume, "Volume");
			comp.pitch = ComponentDisplay.DisplayTextBox(comp.pitch, "Pitch");
			comp.panStereo = ComponentDisplay.DisplayTextBox(comp.panStereo, "Stereo Pan");
			comp.spatialBlend = ComponentDisplay.DisplayTextBox(comp.spatialBlend, "Spatial Blend");
			comp.reverbZoneMix = ComponentDisplay.DisplayTextBox(comp.reverbZoneMix, "Reverb zone mix");
			GUILayout.Label("<b>3D Sound Settings:</b>", new GUILayoutOption[0]);
			Inspector.BeginBox();
			comp.dopplerLevel = ComponentDisplay.DisplayTextBox(comp.dopplerLevel, "Doppler level");
			GUILayout.Label(string.Format("<b>Volume Rolloff:</b> {0}", comp.rolloffMode), new GUILayoutOption[0]);
			comp.minDistance = ComponentDisplay.DisplayTextBox(comp.minDistance, "Min Distance");
			comp.spread = ComponentDisplay.DisplayTextBox(comp.spread, "Spread");
			comp.maxDistance = ComponentDisplay.DisplayTextBox(comp.maxDistance, "Max distance");
			Inspector.EndBox();
		}
		private static void ParticleRendererInfo(ParticleRenderer comp)
		{
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			GUILayout.Label(string.Format("<b>Cast Shadows:</b> {0}", comp.shadowCastingMode), new GUILayoutOption[0]);
			GUILayout.Label(string.Format("<b>Receive Shadows:</b> {0}", comp.receiveShadows), new GUILayoutOption[0]);
			comp.sharedMaterials.DisplayMaterials();
			new string[]
			{
				string.Format("<b>Use Light Probes:</b> {0}", comp.useLightProbes),
				string.Format("<b>Reflection Probe Usage:</b> {0}", comp.reflectionProbeUsage),
				string.Format("<b>Probe Anchor:</b> {0}", comp.probeAnchor),
				string.Format("<b>Camera Velocity Scale:</b> {0}", comp.cameraVelocityScale),
				string.Format("<b>Stretch Particles:</b> {0}", comp.particleRenderMode),
				string.Format("<b>Length Scale:</b> {0}", comp.lengthScale),
				string.Format("<b>Velocity Scale:</b> {0}", comp.velocityScale),
				string.Format("<b>Max Particle Size:</b> {0}", comp.maxParticleSize),
				"<b>UV Animation:</b>",
				string.Format("   <b>X Tile:</b> {0}", comp.uvAnimationXTile),
				string.Format("   <b>Y Tile:</b> {0}", comp.uvAnimationYTile),
				string.Format("   <b>Cycles:</b> {0}", comp.uvAnimationCycles)
			}.DisplayLabels();
		}
		private static void ParticleAnimatorInfo(ParticleAnimator comp)
		{
			GUILayout.Label(string.Format("<b>Does Animate Color:</b> {0}", comp.doesAnimateColor), new GUILayoutOption[0]);
			int num = 0;
			GUILayout.Label("<b>Color Animation:</b>", new GUILayoutOption[0]);
			Inspector.BeginBox();
			foreach (Color color in comp.colorAnimation)
			{
				GUILayout.Label(string.Format("<b>{0}: R:</b> {1}<b>, G:</b> {2}<b>, B:</b> {3}<b>, A:</b> {4}", new object[]
				{
					num,
					color.r,
					color.g,
					color.b,
					color.a
				}), new GUILayoutOption[0]);
				num++;
			}
			Inspector.EndBox();
			new string[]
			{
				string.Format("<b>World Rotation Axis: X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.worldRotationAxis.x, comp.worldRotationAxis.y, comp.worldRotationAxis.z),
				string.Format("<b>Local Rotation Axis: X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.localRotationAxis.x, comp.localRotationAxis.y, comp.localRotationAxis.z),
				string.Format("<b>Size Grow:</b> {0}", comp.sizeGrow),
				string.Format("<b>Rnd Force: X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.rndForce.x, comp.rndForce.y, comp.rndForce.z),
				string.Format("<b>Force: X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.force.x, comp.force.y, comp.force.z),
				string.Format("<b>Damping:</b> {0}", comp.damping),
				string.Format("<b>Autodestruct:</b> {0}", comp.autodestruct)
			}.DisplayLabels();
		}
		private static void EllipsoidParticleEmitterInfo(EllipsoidParticleEmitter comp)
		{
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			new string[]
			{
				string.Format("<b>Emit:</b> {0}", comp.emit),
				string.Format("<b>Min Size:</b> {0}", comp.minSize),
				string.Format("<b>Max Size:</b> {0}", comp.maxSize),
				string.Format("<b>Min Energy:</b> {0}", comp.minEnergy),
				string.Format("<b>Max Energy:</b> {0}", comp.maxEnergy),
				string.Format("<b>Min Emission:</b> {0}", comp.minEmission),
				string.Format("<b>Max Emission:</b> {0}", comp.maxEmission),
				string.Format("<b>World Velocity: X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.worldVelocity.x, comp.worldVelocity.y, comp.worldVelocity.z),
				string.Format("<b>Local Velocity: X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.localVelocity.x, comp.localVelocity.y, comp.localVelocity.z),
				string.Format("<b>Rnd Velocity: X:</b> {0}<b>, Y:</b> {1}<b>, Z:</b> {2}", comp.rndVelocity.x, comp.rndVelocity.y, comp.rndVelocity.z),
				string.Format("<b>Emitter Velocity Scale:</b> {0}", comp.emitterVelocityScale),
				string.Format("<b>Angular Velocity:</b> {0}", comp.angularVelocity),
				string.Format("<b>Rnd Angular Velocity:</b> {0}", comp.rndAngularVelocity),
				string.Format("<b>Rnd Rotation:</b> {0}", comp.rndRotation),
				string.Format("<b>Simulate in Worldspace:</b> {0}", comp.useWorldSpace),
				string.Format("<b>Particle Count:</b> {0}", comp.particleCount)
			}.DisplayLabels();
		}
		private static void ProjectorInfo(Projector comp)
		{
			comp.nearClipPlane = ComponentDisplay.DisplayTextBox(comp.nearClipPlane, "Near Clip Plane");
			comp.farClipPlane = ComponentDisplay.DisplayTextBox(comp.farClipPlane, "Far Clip Plane");
			comp.fieldOfView = ComponentDisplay.DisplayTextBox(comp.fieldOfView, "Field Of View");
			comp.aspectRatio = ComponentDisplay.DisplayTextBox(comp.aspectRatio, "Aspect Ratio");
			comp.orthographic = ComponentDisplay.DisplayToggle(comp.orthographic, "Orthographic");
			comp.orthographicSize = ComponentDisplay.DisplayTextBox(comp.orthographicSize, "Orthographic Size");
			comp.material.DisplayMaterial("");
			GUILayout.Label(string.Format("<b>Culling Mask:</b> {0}", comp.ignoreLayers), new GUILayoutOption[0]);
			Inspector.BeginBox();
			foreach (int num in ComponentDisplay.GetLayerMask(comp.ignoreLayers))
			{
				GUILayout.Label(string.Format("{0} [{1}]", LayerMask.LayerToName(num), num), new GUILayoutOption[0]);
			}
			Inspector.EndBox();
		}
		private static void ReflectionProbeInfo(ReflectionProbe comp)
		{
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			GUILayout.Label(string.Format("<b>Type:</b> {0}", comp.mode), new GUILayoutOption[0]);
			if (comp.mode == (UnityEngine.Rendering.ReflectionProbeMode)1)
			{
				Inspector.BeginBox();
				GUILayout.Label(string.Format("<b>Refresh Mode:</b> {0}", comp.refreshMode), new GUILayoutOption[0]);
				GUILayout.Label(string.Format("<b>Time Slicing:</b> {0}", comp.timeSlicingMode), new GUILayoutOption[0]);
				Inspector.EndBox();
			}
			GUILayout.Label("<b>Runtime Settings:</b>", new GUILayoutOption[0]);
			Inspector.BeginBox();
			comp.importance = ComponentDisplay.DisplayTextBox(comp.importance, "Importance");
			comp.intensity = ComponentDisplay.DisplayTextBox(comp.intensity, "Intensity");
			comp.boxProjection = ComponentDisplay.DisplayToggle(comp.boxProjection, "Box Projection");
			comp.size = comp.size.DisplayVector3("Size", "");
			comp.center = comp.center.DisplayVector3("Probe Origin", "");
			Inspector.EndBox();
			GUILayout.Label("<b>Cubemap Capture Settings:</b>", new GUILayoutOption[0]);
			Inspector.BeginBox();
			comp.resolution = ComponentDisplay.DisplayTextBox(comp.resolution, "Resolution");
			comp.hdr = ComponentDisplay.DisplayToggle(comp.hdr, "HDR");
			comp.shadowDistance = ComponentDisplay.DisplayTextBox(comp.shadowDistance, "Shadow Distance");
			GUILayout.Label(string.Format("<b>Clear Flags:</b> {0}", comp.clearFlags), new GUILayoutOption[0]);
			comp.backgroundColor = ComponentDisplay.DisplayColor(comp.backgroundColor, "Background");
			GUILayout.Label(string.Format("<b>Culling Mask:</b> {0}", comp.cullingMask), new GUILayoutOption[0]);
			Inspector.BeginBox();
			foreach (int num in ComponentDisplay.GetLayerMask(comp.cullingMask))
			{
				GUILayout.Label(string.Format("{0} [{1}]", LayerMask.LayerToName(num), num), new GUILayoutOption[0]);
			}
			Inspector.EndBox();
			GUILayout.Label("<b>Clipping Planes:</b>", new GUILayoutOption[0]);
			Inspector.BeginBox();
			comp.nearClipPlane = ComponentDisplay.DisplayTextBox(comp.nearClipPlane, "Near");
			comp.farClipPlane = ComponentDisplay.DisplayTextBox(comp.farClipPlane, "Far");
			Inspector.EndBox();
			Inspector.EndBox();
		}
		private static void PlayMakerArrayListProxyInfo(PlayMakerArrayListProxy comp)
		{
			string format = "<b>_arrayList: ({0})</b>";
			ArrayList arrayList = comp._arrayList;
			GUILayout.Label(string.Format(format, (arrayList != null) ? new int?(arrayList.Count) : null), new GUILayoutOption[0]);
			if (comp._arrayList != null && comp._arrayList.Count > 0)
			{
				Inspector.BeginBox();
				for (int i = 0; i < comp._arrayList.Count; i++)
				{
					comp._arrayList[i] = ComponentDisplay.DisplayGenericValues(comp._arrayList[i], string.Format("{0}", i));
				}
				Inspector.EndBox();
			}
			comp.showEvents = ComponentDisplay.DisplayToggle(comp.showEvents, "Show Events");
			comp.showContent = ComponentDisplay.DisplayToggle(comp.showContent, "Show Content");
			comp.TextureElementSmall = ComponentDisplay.DisplayToggle(comp.TextureElementSmall, "Texture Element Small");
			comp.condensedView = ComponentDisplay.DisplayToggle(comp.condensedView, "Condensed View");
			comp.liveUpdate = ComponentDisplay.DisplayToggle(comp.liveUpdate, "Live Update");
			comp.referenceName = ComponentDisplay.DisplayTextBox(comp.referenceName, "Reference Name");
			comp.enablePlayMakerEvents = ComponentDisplay.DisplayToggle(comp.enablePlayMakerEvents, "Enable Play Maker Events");
			comp.addEvent = ComponentDisplay.DisplayTextBox(comp.addEvent, "Add Event");
			comp.setEvent = ComponentDisplay.DisplayTextBox(comp.setEvent, "Set Event");
			comp.removeEvent = ComponentDisplay.DisplayTextBox(comp.removeEvent, "Remove Event");
			comp.contentPreviewStartIndex = ComponentDisplay.DisplayTextBox(comp.contentPreviewStartIndex, "Content Preview Start Index");
			comp.contentPreviewMaxRows = ComponentDisplay.DisplayTextBox(comp.contentPreviewMaxRows, "Content Preview Max Rows");
			GUILayout.Label(string.Format("<b>Pre Fill Type:</b> {0} ({1})", comp.preFillType, comp.preFillType), new GUILayoutOption[0]);
			comp.preFillObjectTypeIndex = ComponentDisplay.DisplayTextBox(comp.preFillObjectTypeIndex, "Pre Fill Object Type Index");
			comp.preFillCount = ComponentDisplay.DisplayTextBox(comp.preFillCount, "Pre Fill Count");
			string format2 = "<b>Pre Fill Key List: ({0})</b>";
			List<string> preFillKeyList = comp.preFillKeyList;
			GUILayout.Label(string.Format(format2, (preFillKeyList != null) ? new int?(preFillKeyList.Count) : null), new GUILayoutOption[0]);
			if (comp.preFillKeyList != null && comp.preFillKeyList.Count > 0)
			{
				Inspector.BeginBox();
				for (int j = 0; j < comp.preFillKeyList.Count; j++)
				{
					comp.preFillKeyList[j] = ComponentDisplay.DisplayTextBox(comp.preFillKeyList[j], string.Format("[{0}]", j));
				}
				Inspector.EndBox();
			}
			string format3 = "<b>Pre Fill Bool List: ({0})</b>";
			List<bool> preFillBoolList = comp.preFillBoolList;
			GUILayout.Label(string.Format(format3, (preFillBoolList != null) ? new int?(preFillBoolList.Count) : null), new GUILayoutOption[0]);
			if (comp.preFillBoolList != null && comp.preFillBoolList.Count > 0)
			{
				Inspector.BeginBox();
				for (int k = 0; k < comp.preFillBoolList.Count; k++)
				{
					comp.preFillBoolList[k] = ComponentDisplay.DisplayToggle(comp.preFillBoolList[k], string.Format("[{0}]", k));
				}
				Inspector.EndBox();
			}
			string format4 = "<b>Pre Fill Color List: ({0})</b>";
			List<Color> preFillColorList = comp.preFillColorList;
			GUILayout.Label(string.Format(format4, (preFillColorList != null) ? new int?(preFillColorList.Count) : null), new GUILayoutOption[0]);
			if (comp.preFillColorList != null && comp.preFillColorList.Count > 0)
			{
				Inspector.BeginBox();
				for (int l = 0; l < comp.preFillColorList.Count; l++)
				{
					comp.preFillColorList[l] = ComponentDisplay.DisplayColor(comp.preFillColorList[l], string.Format("[{0}]", l));
				}
				Inspector.EndBox();
			}
			string format5 = "<b>Pre Fill Float List: ({0})</b>";
			List<float> preFillFloatList = comp.preFillFloatList;
			GUILayout.Label(string.Format(format5, (preFillFloatList != null) ? new int?(preFillFloatList.Count) : null), new GUILayoutOption[0]);
			if (comp.preFillFloatList != null && comp.preFillFloatList.Count > 0)
			{
				Inspector.BeginBox();
				for (int m = 0; m < comp.preFillFloatList.Count; m++)
				{
					comp.preFillFloatList[m] = ComponentDisplay.DisplayTextBox(comp.preFillFloatList[m], string.Format("[{0}]", m));
				}
				Inspector.EndBox();
			}
			string format6 = "<b>Pre Fill Game Object List: ({0})</b>";
			List<GameObject> preFillGameObjectList = comp.preFillGameObjectList;
			GUILayout.Label(string.Format(format6, (preFillGameObjectList != null) ? new int?(preFillGameObjectList.Count) : null), new GUILayoutOption[0]);
			if (comp.preFillGameObjectList != null && comp.preFillGameObjectList.Count > 0)
			{
				Inspector.BeginBox();
				for (int n = 0; n < comp.preFillGameObjectList.Count; n++)
				{
					ComponentDisplay.DisplayReferenceButton(comp.preFillGameObjectList[n], string.Format("[{0}]", n));
				}
				Inspector.EndBox();
			}
			string format7 = "<b>Pre Fill Int List: ({0})</b>";
			List<int> preFillIntList = comp.preFillIntList;
			GUILayout.Label(string.Format(format7, (preFillIntList != null) ? new int?(preFillIntList.Count) : null), new GUILayoutOption[0]);
			if (comp.preFillIntList != null && comp.preFillIntList.Count > 0)
			{
				Inspector.BeginBox();
				for (int num = 0; num < comp.preFillIntList.Count; num++)
				{
					comp.preFillIntList[num] = ComponentDisplay.DisplayTextBox(comp.preFillIntList[num], string.Format("[{0}]", num));
				}
				Inspector.EndBox();
			}
			string format8 = "<b>Pre Fill Material List: ({0})</b>";
			List<Material> preFillMaterialList = comp.preFillMaterialList;
			GUILayout.Label(string.Format(format8, (preFillMaterialList != null) ? new int?(preFillMaterialList.Count) : null), new GUILayoutOption[0]);
			if (comp.preFillMaterialList != null && comp.preFillMaterialList.Count > 0)
			{
				Inspector.BeginBox();
				for (int num2 = 0; num2 < comp.preFillMaterialList.Count; num2++)
				{
					comp.preFillMaterialList[num2].DisplayMaterial(string.Format("[{0}]", num2));
				}
				Inspector.EndBox();
			}
			string format9 = "<b>Pre Fill Object List: ({0})</b>";
			List<UnityEngine.Object> preFillObjectList = comp.preFillObjectList;
			GUILayout.Label(string.Format(format9, (preFillObjectList != null) ? new int?(preFillObjectList.Count) : null), new GUILayoutOption[0]);
			if (comp.preFillObjectList != null && comp.preFillObjectList.Count > 0)
			{
				Inspector.BeginBox();
				for (int num3 = 0; num3 < comp.preFillObjectList.Count; num3++)
				{
					GUILayout.Label(string.Format("<b>[{0}]:</b> {1}", num3, comp.preFillObjectList[num3]), new GUILayoutOption[0]);
				}
				Inspector.EndBox();
			}
			string format10 = "<b>Pre Fill Quaternion List: ({0})</b>";
			List<Quaternion> preFillQuaternionList = comp.preFillQuaternionList;
			GUILayout.Label(string.Format(format10, (preFillQuaternionList != null) ? new int?(preFillQuaternionList.Count) : null), new GUILayoutOption[0]);
			if (comp.preFillQuaternionList != null && comp.preFillQuaternionList.Count > 0)
			{
				Inspector.BeginBox();
				for (int num4 = 0; num4 < comp.preFillQuaternionList.Count; num4++)
				{
					comp.preFillQuaternionList[num4] = comp.preFillQuaternionList[num4].DisplayQuaternion(string.Format("[{0}]", num4), "");
				}
				Inspector.EndBox();
			}
			string format11 = "<b>Pre Fill Rect List: ({0})</b>";
			List<Rect> preFillRectList = comp.preFillRectList;
			GUILayout.Label(string.Format(format11, (preFillRectList != null) ? new int?(preFillRectList.Count) : null), new GUILayoutOption[0]);
			if (comp.preFillRectList != null && comp.preFillRectList.Count > 0)
			{
				Inspector.BeginBox();
				for (int num5 = 0; num5 < comp.preFillRectList.Count; num5++)
				{
					GUILayout.Label(string.Format("<b>[{0}]:</b> {1}", num5, comp.preFillRectList[num5]), new GUILayoutOption[0]);
				}
				Inspector.EndBox();
			}
			string format12 = "<b>Pre Fill String List: ({0})</b>";
			List<string> preFillStringList = comp.preFillStringList;
			GUILayout.Label(string.Format(format12, (preFillStringList != null) ? new int?(preFillStringList.Count) : null), new GUILayoutOption[0]);
			if (comp.preFillStringList != null && comp.preFillStringList.Count > 0)
			{
				Inspector.BeginBox();
				for (int num6 = 0; num6 < comp.preFillStringList.Count; num6++)
				{
					comp.preFillStringList[num6] = ComponentDisplay.DisplayTextBox(comp.preFillStringList[num6], string.Format("[{0}]", num6));
				}
				Inspector.EndBox();
			}
			string format13 = "<b>Pre Fill Texture List: ({0})</b>";
			List<Texture2D> preFillTextureList = comp.preFillTextureList;
			GUILayout.Label(string.Format(format13, (preFillTextureList != null) ? new int?(preFillTextureList.Count) : null), new GUILayoutOption[0]);
			if (comp.preFillTextureList != null && comp.preFillTextureList.Count > 0)
			{
				Inspector.BeginBox();
				for (int num7 = 0; num7 < comp.preFillTextureList.Count; num7++)
				{
					GUILayout.Label(string.Format("<b>[{0}]:</b> {1}", num7, comp.preFillTextureList[num7]), new GUILayoutOption[0]);
				}
				Inspector.EndBox();
			}
			string format14 = "<b>Pre Fill Vector 2 List: ({0})</b>";
			List<Vector2> preFillVector2List = comp.preFillVector2List;
			GUILayout.Label(string.Format(format14, (preFillVector2List != null) ? new int?(preFillVector2List.Count) : null), new GUILayoutOption[0]);
			if (comp.preFillVector2List != null && comp.preFillVector2List.Count > 0)
			{
				Inspector.BeginBox();
				for (int num8 = 0; num8 < comp.preFillVector2List.Count; num8++)
				{
					comp.preFillVector2List[num8] = comp.preFillVector2List[num8].DisplayVector2(string.Format("[{0}]", num8), "");
				}
				Inspector.EndBox();
			}
			string format15 = "<b>Pre Fill Vector 3 List: ({0})</b>";
			List<Vector3> preFillVector3List = comp.preFillVector3List;
			GUILayout.Label(string.Format(format15, (preFillVector3List != null) ? new int?(preFillVector3List.Count) : null), new GUILayoutOption[0]);
			if (comp.preFillVector3List != null && comp.preFillVector3List.Count > 0)
			{
				Inspector.BeginBox();
				for (int num9 = 0; num9 < comp.preFillVector3List.Count; num9++)
				{
					comp.preFillVector3List[num9] = comp.preFillVector3List[num9].DisplayVector3(string.Format("[{0}]", num9), "");
				}
				Inspector.EndBox();
			}
			string format16 = "<b>Pre Fill Audio Clip List: ({0})</b>";
			List<AudioClip> preFillAudioClipList = comp.preFillAudioClipList;
			GUILayout.Label(string.Format(format16, (preFillAudioClipList != null) ? new int?(preFillAudioClipList.Count) : null), new GUILayoutOption[0]);
			if (comp.preFillAudioClipList != null && comp.preFillAudioClipList.Count > 0)
			{
				Inspector.BeginBox();
				for (int num10 = 0; num10 < comp.preFillAudioClipList.Count; num10++)
				{
					GUILayout.Label(string.Format("<b>[{0}]:</b> {1}", num10, comp.preFillAudioClipList[num10]), new GUILayoutOption[0]);
				}
				Inspector.EndBox();
			}
		}
		private static void AudioLowPassFilterInfo(AudioLowPassFilter comp)
		{
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			comp.cutoffFrequency = ComponentDisplay.DisplayTextBox(comp.cutoffFrequency, "Cutoff Frequency");
			comp.lowpassResonanceQ = ComponentDisplay.DisplayTextBox(comp.lowpassResonanceQ, "Lowpass Resonance Q");
		}
		private static void AudioHighPassFilterInfo(AudioHighPassFilter comp)
		{
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			comp.cutoffFrequency = ComponentDisplay.DisplayTextBox(comp.cutoffFrequency, "Cutoff Frequency");
			comp.highpassResonanceQ = ComponentDisplay.DisplayTextBox(comp.highpassResonanceQ, "Highpass Resonance Q");
		}
		private static void AudioDistortionFilterInfo(AudioDistortionFilter comp)
		{
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			comp.distortionLevel = ComponentDisplay.DisplayTextBox(comp.distortionLevel, "Distortion Level");
		}
		private static void AudioEchoFilterInfo(AudioEchoFilter comp)
		{
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			comp.delay = ComponentDisplay.DisplayTextBox(comp.delay, "Delay");
			comp.decayRatio = ComponentDisplay.DisplayTextBox(comp.decayRatio, "Decay Ratio");
			comp.wetMix = ComponentDisplay.DisplayTextBox(comp.wetMix, "Wet Mix");
			comp.dryMix = ComponentDisplay.DisplayTextBox(comp.dryMix, "Dry Mix");
		}
		private static void AudioReverbFilterInfo(AudioReverbFilter comp)
		{
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			comp.reverbPreset = (AudioReverbPreset)ComponentDisplay.DisplaySlider((int)comp.reverbPreset, 0, 27, string.Format("<b>Reverb Preset:</b> {0}", comp.reverbPreset));
			if (comp.reverbPreset == (AudioReverbPreset)27)
			{
				comp.dryLevel = ComponentDisplay.DisplayTextBox(comp.dryLevel, "Dry Level");
				comp.room = ComponentDisplay.DisplayTextBox(comp.room, "Room");
				comp.roomHF = ComponentDisplay.DisplayTextBox(comp.roomHF, "Room HF");
				comp.roomLF = ComponentDisplay.DisplayTextBox(comp.roomLF, "Room LF");
				comp.decayTime = ComponentDisplay.DisplayTextBox(comp.decayTime, "Decay Time");
				comp.decayHFRatio = ComponentDisplay.DisplayTextBox(comp.decayHFRatio, "Decay HF Time");
				comp.reflectionsLevel = ComponentDisplay.DisplayTextBox(comp.reflectionsLevel, "Reflections Level");
				comp.reflectionsDelay = ComponentDisplay.DisplayTextBox(comp.reflectionsDelay, "Reflections Delay");
				comp.reverbLevel = ComponentDisplay.DisplayTextBox(comp.reverbLevel, "Reverb Level");
				comp.reverbDelay = ComponentDisplay.DisplayTextBox(comp.reverbDelay, "Reverb Delay");
				comp.hfReference = ComponentDisplay.DisplayTextBox(comp.hfReference, "HF Reference");
				comp.lfReference = ComponentDisplay.DisplayTextBox(comp.lfReference, "LF Reference");
				comp.diffusion = ComponentDisplay.DisplayTextBox(comp.diffusion, "Diffusion");
				comp.density = ComponentDisplay.DisplayTextBox(comp.density, "Density");
			}
		}
		private static void AudioChorusFilterInfo(AudioChorusFilter comp)
		{
			comp.enabled = ComponentDisplay.DisplayEnabled(comp.enabled);
			comp.dryMix = ComponentDisplay.DisplayTextBox(comp.dryMix, "Dry Mix");
			comp.wetMix1 = ComponentDisplay.DisplayTextBox(comp.wetMix1, "Wet Mix 1");
			comp.wetMix2 = ComponentDisplay.DisplayTextBox(comp.wetMix2, "Wet Mix 2");
			comp.wetMix3 = ComponentDisplay.DisplayTextBox(comp.wetMix3, "Wet Mix 3");
			comp.delay = ComponentDisplay.DisplayTextBox(comp.delay, "Delay");
			comp.rate = ComponentDisplay.DisplayTextBox(comp.rate, "Rate");
			comp.depth = ComponentDisplay.DisplayTextBox(comp.depth, "Depth");
		}
		private static void UITextInfo(Text comp)
		{
			GUILayout.Label("<b>Text:</b>", new GUILayoutOption[0]);
			comp.text = GUILayout.TextArea(comp.text, new GUILayoutOption[0]);
			GUILayout.Label(string.Format("<b>Font:</b> {0}", comp.font), new GUILayoutOption[0]);
			comp.fontStyle = (FontStyle)ComponentDisplay.DisplaySlider((int)comp.fontStyle, 0, 3, string.Format("<b>Font Style:</b> {0}", comp.fontStyle));
			comp.fontSize = ComponentDisplay.DisplayTextBox(comp.fontSize, "Font Size");
			comp.lineSpacing = ComponentDisplay.DisplayTextBox(comp.lineSpacing, "Line Spacing");
			comp.supportRichText = ComponentDisplay.DisplayToggle(comp.supportRichText, "Rich Text");
			comp.color = ComponentDisplay.DisplayColor(comp.color, "Color");
		}
		private static void UIContentSizeFitterInfo(ContentSizeFitter comp)
		{
			new string[]
			{
				string.Format("<b>Horizontal Fit:</b> {0}", comp.horizontalFit),
				string.Format("<b>Vertical Fit:</b> {0}", comp.verticalFit)
			}.DisplayLabels();
		}
		private static void UIVerticalLayoutGroupInfo(VerticalLayoutGroup comp)
		{
			new string[]
			{
				string.Format("<b>Padding:</b>   \n{0}   \n{1}   \n{2}   \n{3}", new object[]
				{
					comp.padding.left,
					comp.padding.right,
					comp.padding.top,
					comp.padding.bottom
				}),
				string.Format("<b>Spacing:</b> {0}", comp.spacing),
				string.Format("<b>Child Alignment:</b> {0}", comp.childAlignment),
				string.Format("<b>Child Force Expand Width:</b> {0}", comp.childForceExpandWidth),
				string.Format("<b>Child Force Expand Height:</b> {0}", comp.childForceExpandHeight)
			}.DisplayLabels();
		}
		private static void UIScrollRectInfo(ScrollRect comp)
		{
			new string[]
			{
				string.Format("<b>Content:</b> {0}", comp.content)
			}.DisplayLabels();
		}
		private static void UILayoutElementInfo(LayoutElement comp)
		{
			new string[]
			{
				string.Format("<b>Ignore Layout:</b> {0}", comp.ignoreLayout),
				string.Format("<b>Min Width:</b> {0}", comp.minWidth),
				string.Format("<b>Min Height:</b> {0}", comp.minHeight),
				string.Format("<b>Preferred Width:</b> {0}", comp.preferredWidth),
				string.Format("<b>Preferred Height:</b> {0}", comp.preferredHeight),
				string.Format("<b>Flexible Width:</b> {0}", comp.flexibleWidth),
				string.Format("<b>Flexible Height:</b> {0}", comp.flexibleHeight)
			}.DisplayLabels();
		}
		private static void GenericComponentInfo(Component comp)
		{
			try
			{
				(comp as MonoBehaviour).enabled = ComponentDisplay.DisplayEnabled((comp as MonoBehaviour).enabled);
			}
			catch
			{
			}
			BindingFlags bindingAttr = (ComponentDisplay.variablesPublic ? BindingFlags.Public : BindingFlags.Default) | (ComponentDisplay.variablesNonPublic ? BindingFlags.NonPublic : BindingFlags.Default) | BindingFlags.Instance;
			foreach (FieldInfo fieldInfo in comp.GetType().GetFields(bindingAttr))
			{
				try
				{
					object value = fieldInfo.GetValue(comp);
					if (!(value is int))
					{
						if (!(value is bool))
						{
							if (!(value is float))
							{
								if (!(value is string))
								{
									if (!(value is Vector3))
									{
										if (!(value is Quaternion))
										{
											if (!(value is GameObject))
											{
												if (!(value is Color))
												{
													if (!(value is Material))
													{
														if (!(value is IList))
														{
															if (!(value is IDictionary))
															{
																if (!(value is PlayMakerFSM))
																{
																	if (!(value is FsmState))
																	{
																		if (!(value is FsmEvent))
																		{
																			if (!(value is Component))
																			{
																				GUILayout.Label("<b>" + fieldInfo.Name + ":</b> " + value.ToString(), new GUILayoutOption[0]);
																			}
																			else
																			{
																				ComponentDisplay.DisplayReferenceButton(value as Component, fieldInfo.Name);
																			}
																		}
																		else
																		{
																			GUILayout.Label(string.Concat(new string[]
																			{
																				"<b>",
																				fieldInfo.Name,
																				":</b> \"",
																				(value as FsmEvent).Name,
																				"\""
																			}), new GUILayoutOption[0]);
																		}
																	}
																	else if ((value as FsmState).Fsm.Initialized)
																	{
																		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
																		GUILayout.Label("<b>" + fieldInfo.Name + ":</b> " + (value as FsmState).Name, new GUILayoutOption[0]);
																		ComponentDisplay.DisplayReferenceButton((value as FsmState).Fsm.Owner as PlayMakerFSM, "");
																		GUILayout.EndHorizontal();
																	}
																	else
																	{
																		GUILayout.Label(string.Format("<b>{0}:</b> {1}", fieldInfo.Name, value), new GUILayoutOption[0]);
																	}
																}
																else
																{
																	GUILayout.BeginHorizontal(new GUILayoutOption[0]);
																	GUILayout.Label("<b>" + fieldInfo.Name + ":</b> " + (value as PlayMakerFSM).Fsm.Name, new GUILayoutOption[0]);
																	ComponentDisplay.DisplayReferenceButton(value as PlayMakerFSM, "");
																	GUILayout.EndHorizontal();
																}
															}
															else
															{
																fieldInfo.SetValue(comp, (value as IDictionary).DisplayDictionary("<b>" + fieldInfo.Name + ":</b> " + value.ToString()));
															}
														}
														else
														{
															fieldInfo.SetValue(comp, (value as IList).DisplayList("<b>" + fieldInfo.Name + ":</b> " + value.ToString()));
														}
													}
													else
													{
														GUILayout.Label("<b>" + fieldInfo.Name + ":</b> " + value.ToString(), new GUILayoutOption[0]);
														(value as Material).DisplayMaterial("");
													}
												}
												else
												{
													fieldInfo.SetValue(comp, ComponentDisplay.DisplayColor((Color)value, fieldInfo.Name));
												}
											}
											else
											{
												ComponentDisplay.DisplayReferenceButton(value as GameObject, fieldInfo.Name);
											}
										}
										else
										{
											fieldInfo.SetValue(comp, ((Quaternion)value).DisplayQuaternion(fieldInfo.Name, ""));
										}
									}
									else
									{
										fieldInfo.SetValue(comp, ((Vector3)value).DisplayVector3(fieldInfo.Name, ""));
									}
								}
								else
								{
									fieldInfo.SetValue(comp, ComponentDisplay.DisplayTextBox((string)value, fieldInfo.Name));
								}
							}
							else
							{
								fieldInfo.SetValue(comp, ComponentDisplay.DisplayTextBox((float)value, fieldInfo.Name));
							}
						}
						else
						{
							fieldInfo.SetValue(comp, ComponentDisplay.DisplayToggle((bool)value, fieldInfo.Name));
						}
					}
					else
					{
						fieldInfo.SetValue(comp, ComponentDisplay.DisplayTextBox((int)value, fieldInfo.Name));
					}
				}
				catch (Exception)
				{
					GUILayout.Label("<b>" + fieldInfo.Name + ":</b>", new GUILayoutOption[0]);
				}
			}
		}
		private static void ComponentToggle(Component comp)
		{
			ComponentDisplay.componentToggle[comp] = !ComponentDisplay.componentToggle[comp];
		}
		private static List<int> GetLayerMask(int layerMask)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < 32; i++)
			{
				if (layerMask == (layerMask | 1 << i))
				{
					list.Add(i);
				}
			}
			return list;
		}
		internal static IList DisplayList(this IList list, string label = "")
		{
			if (!string.IsNullOrEmpty(label))
			{
				GUILayout.Label(label, new GUILayoutOption[0]);
			}
			if (list.Count > 0)
			{
				Inspector.BeginBox();
				int num = 0;
				while (num < list.Count && num < ComponentDisplay.listCountLimit)
				{
					list[num] = ComponentDisplay.DisplayGenericValues(list[num], string.Format("{0}", num));
					num++;
				}
				if (list.Count > ComponentDisplay.listCountLimit)
				{
					GUILayout.Label("... (count limit reached)", new GUILayoutOption[0]);
				}
				Inspector.EndBox();
			}
			return list;
		}
		internal static IDictionary DisplayDictionary(this IDictionary dictionary, string label = "")
		{
			if (!string.IsNullOrEmpty(label))
			{
				GUILayout.Label(label, new GUILayoutOption[0]);
			}
			if (dictionary.Keys.Count > 0)
			{
				Inspector.BeginBox();
				List<object> list = new List<object>();
				foreach (object item in dictionary.Keys)
				{
					list.Add(item);
				}
				int num = 0;
				while (num < list.Count && num < ComponentDisplay.listCountLimit)
				{
					GUILayout.Label(string.Format("<b>[{0}]:</b>", num), new GUILayoutOption[0]);
					Inspector.BeginBox();
					GUILayout.BeginHorizontal(new GUILayoutOption[0]);
					GUILayout.Label("<b>Key:</b>", new GUILayoutOption[0]);
					ComponentDisplay.DisplayGenericValues(list[num], "");
					GUILayout.EndHorizontal();
					GUILayout.BeginHorizontal(new GUILayoutOption[0]);
					GUILayout.Label("<b>Value:</b>", new GUILayoutOption[0]);
					dictionary[list[num]] = ComponentDisplay.DisplayGenericValues(dictionary[list[num]], "");
					GUILayout.EndHorizontal();
					Inspector.EndBox();
					num++;
				}
				Inspector.EndBox();
			}
			return dictionary;
		}
		internal static void DisplayLabels(this string[] fields)
		{
			for (int i = 0; i < fields.Length; i++)
			{
				GUILayout.Label(fields[i], new GUILayoutOption[0]);
			}
		}
		internal static void DisplayMaterials(this Material[] materials)
		{
			GUILayout.Label("<b>Materials:</b>", new GUILayoutOption[0]);
			int num = 0;
			foreach (Material material in materials)
			{
				GUILayout.Label(string.Format("  <b>Material {0}:</b>", num), new GUILayoutOption[0]);
				material.DisplayMaterial("");
				num++;
			}
		}
		internal static void DisplayMaterial(this Material material, string label = "")
		{
			if (!string.IsNullOrEmpty(label))
			{
				GUILayout.Label("<b>" + label + ":</b>", new GUILayoutOption[0]);
			}
			Inspector.BeginBox();
			GUILayout.Label("<b>Name:</b> " + material.name, new GUILayoutOption[0]);
			GUILayout.Label("<b>Shader:</b> " + material.shader.name, new GUILayoutOption[0]);
			if (ShaderInfo.textureTypes.Any((string type) => material.HasProperty(type)))
			{
				GUILayout.Label("<b>Textures:</b>", new GUILayoutOption[0]);
				Inspector.BeginBox();
				/*string text = "";
				IEnumerable<string> textureTypes = ShaderInfo.textureTypes;
				Func<string, bool> _p;
				Func<string, bool> predicate;
				if ((predicate = _p) == null)
				{
					predicate = (_p = ((string type) => material.HasProperty(type)));
				}
				foreach (string text2 in textureTypes.Where(predicate))
				{
					if (material.GetTexture(text2) != null)
					{
						GUILayout.Label("<b>" + text2 + ":</b> " + material.GetTexture(text2).name, new GUILayoutOption[0]);
					}
					else
					{
						text = text + text2 + ", ";
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					GUILayout.Label("<b>Unused Texture properties:</b> " + text, new GUILayoutOption[0]);
				}*/
				Inspector.EndBox();
			}
			if (ShaderInfo.floatTypes.Any((string type) => material.HasProperty(type)))
			{
				GUILayout.Label("<b>Floats:</b>", new GUILayoutOption[0]);
				Inspector.BeginBox();
				/*IEnumerable<string> floatTypes = ShaderInfo.floatTypes;
				Func<string, bool> <>9__4;
				Func<string, bool> predicate2;
				if ((predicate2 = <>9__4) == null)
				{
					predicate2 = (<>9__4 = ((string type) => material.HasProperty(type)));
				}
				foreach (string text3 in floatTypes.Where(predicate2))
				{
					material.SetFloat(text3, ComponentDisplay.DisplayTextBox(material.GetFloat(text3), text3));
				}*/
				Inspector.EndBox();
			}
			if (ShaderInfo.colorTypes.Any((string type) => material.HasProperty(type)))
			{
				GUILayout.Label("<b>Colors:</b>", new GUILayoutOption[0]);
				Inspector.BeginBox();
				/*IEnumerable<string> colorTypes = ShaderInfo.colorTypes;
				Func<string, bool> <>9__5;
				Func<string, bool> predicate3;
				if ((predicate3 = <>9__5) == null)
				{
					predicate3 = (<>9__5 = ((string type) => material.HasProperty(type)));
				}
				foreach (string text4 in colorTypes.Where(predicate3))
				{
					material.SetColor(text4, ComponentDisplay.DisplayColor(material.GetColor(text4), text4));
				}*/
				Inspector.EndBox();
			}
			Inspector.EndBox();
		}
		internal static void DisplayPhysicMaterial(this PhysicMaterial material)
		{
			GUILayout.Label(string.Format("<b>Physics Material:</b> {0}", material), new GUILayoutOption[0]);
			if (material != null)
			{
				Inspector.BeginBox();
				new string[]
				{
					string.Format("<b>    Dynamic Friction:</b> {0}", material.dynamicFriction),
					string.Format("<b>    Static Friction:</b> {0}", material.staticFriction),
					string.Format("<b>    Bounciness:</b> {0}", material.bounciness),
					string.Format("<b>    Friction Combine:</b> {0}", material.frictionCombine),
					string.Format("<b>    Bounce Combine:</b> {0}", material.bounceCombine),
					string.Format("<b>    Friction Direction 2:</b> {0}", material.frictionDirection2),
					string.Format("<b>    Dynamic Friction 2:</b> {0}", material.dynamicFriction2),
					string.Format("<b>    Static Friction 2:</b> {0}", material.staticFriction2)
				}.DisplayLabels();
				Inspector.EndBox();
			}
		}
		internal static void DisplayMeshInfo(this Mesh mesh, string topLabel = "")
		{
			GUILayout.Label("<b>" + topLabel + " Info:</b>", new GUILayoutOption[0]);
			Inspector.BeginBox();
			new string[]
			{
				string.Format("<b>Sub Mesh Count:</b> {0}", mesh.subMeshCount),
				string.Format("<b>Bounds:</b> {0}", mesh.bounds),
				string.Format("<b>Vertex Count:</b> {0}", mesh.vertexCount),
				string.Format("<b>BlendShape Count:</b> {0}", mesh.blendShapeCount)
			}.DisplayLabels();
			Inspector.EndBox();
		}
		internal static void DisplayReferenceButton(Component component, string label = "")
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (!string.IsNullOrEmpty(label))
			{
				GUILayout.Label(string.Concat(new string[]
				{
					"<b>",
					label,
					":</b> (",
					(component != null) ? component.GetType().ToString().Split(new char[]
					{
						'.'
					}).Last<string>() : null,
					")"
				}), new GUILayoutOption[0]);
			}
			if (component != null && GUILayout.Button(component.transform.name ?? "", new GUILayoutOption[0]))
			{
				Inspector.Inspect(component.transform, false, false);
			}
			GUILayout.EndHorizontal();
		}
		internal static void DisplayReferenceButton(GameObject gameObject, string label = "")
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (!string.IsNullOrEmpty(label))
			{
				GUILayout.Label("<b>" + label + ":</b> (GameObject)", new GUILayoutOption[0]);
			}
			if (gameObject != null && GUILayout.Button(gameObject.transform.name ?? "", new GUILayoutOption[0]))
			{
				Inspector.Inspect(gameObject.transform, false, false);
			}
			GUILayout.EndHorizontal();
		}
		internal static bool DisplayToggle(bool value, string label = "")
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (!string.IsNullOrEmpty(label))
			{
				GUILayout.Label(string.Format("<b>{0}:</b> ({1})", label, value), new GUILayoutOption[0]);
			}
			value = GUILayout.Toggle(value, "", new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			return value;
		}
		internal static bool DisplayEnabled(bool value)
		{
			value = ComponentDisplay.DisplayToggle(value, "Enabled");
			GUILayout.Space(5f);
			return value;
		}
		internal static string DisplayTextBox(string value, string label = "")
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (!string.IsNullOrEmpty(label))
			{
				GUILayout.Label("<b>" + label + ":</b>", new GUILayoutOption[]
				{
					GUILayout.MinWidth(150f)
				});
			}
			value = GUILayout.TextField(value, new GUILayoutOption[]
			{
				GUILayout.MinWidth(50f)
			});
			GUILayout.EndHorizontal();
			return value;
		}
		internal static int DisplayTextBox(int value, string label = "")
		{
			return int.Parse(ComponentDisplay.DisplayTextBox(value.ToString(), label));
		}
		internal static float DisplayTextBox(float value, string label = "")
		{
			return float.Parse(ComponentDisplay.DisplayTextBox(value.ToString(), label));
		}
		internal static Color DisplayColor(Color color, string label = "")
		{
			if (!string.IsNullOrEmpty(label))
			{
				GUILayout.Label(string.Format("<b>{0}:</b> {1}", label, color), new GUILayoutOption[0]);
			}
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			color.r = float.Parse(GUILayout.TextField(color.r.ToString(), new GUILayoutOption[0]));
			color.g = float.Parse(GUILayout.TextField(color.g.ToString(), new GUILayoutOption[0]));
			color.b = float.Parse(GUILayout.TextField(color.b.ToString(), new GUILayoutOption[0]));
			color.a = float.Parse(GUILayout.TextField(color.a.ToString(), new GUILayoutOption[0]));
			GUILayout.EndHorizontal();
			return color;
		}
		internal static Vector3 DisplayVector3(this Vector3 vector3, string label, string extraLabel = "")
		{
			if (!string.IsNullOrEmpty(label))
			{
				GUILayout.Label("<b>" + label + " (X, Y, Z):</b>" + extraLabel, new GUILayoutOption[0]);
			}
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			vector3.x = float.Parse(GUILayout.TextField(vector3.x.ToString(), new GUILayoutOption[0]));
			vector3.y = float.Parse(GUILayout.TextField(vector3.y.ToString(), new GUILayoutOption[0]));
			vector3.z = float.Parse(GUILayout.TextField(vector3.z.ToString(), new GUILayoutOption[0]));
			GUILayout.EndHorizontal();
			return vector3;
		}
		internal static Quaternion DisplayQuaternion(this Quaternion quaternion, string label, string extraLabel = "")
		{
			if (!string.IsNullOrEmpty(label))
			{
				GUILayout.Label("<b>" + label + " (X, Y, Z, W):</b>" + extraLabel, new GUILayoutOption[0]);
			}
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			quaternion.x = float.Parse(GUILayout.TextField(quaternion.x.ToString(), new GUILayoutOption[0]));
			quaternion.y = float.Parse(GUILayout.TextField(quaternion.y.ToString(), new GUILayoutOption[0]));
			quaternion.z = float.Parse(GUILayout.TextField(quaternion.z.ToString(), new GUILayoutOption[0]));
			quaternion.w = float.Parse(GUILayout.TextField(quaternion.w.ToString(), new GUILayoutOption[0]));
			GUILayout.EndHorizontal();
			return quaternion;
		}
		internal static Vector3 DisplayVector2(this Vector2 vector2, string label, string extraLabel = "")
		{
			GUILayout.Label("<b>" + label + " (X, Y):</b>" + extraLabel, new GUILayoutOption[0]);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			vector2.x = float.Parse(GUILayout.TextField(vector2.x.ToString(), new GUILayoutOption[0]));
			vector2.y = float.Parse(GUILayout.TextField(vector2.y.ToString(), new GUILayoutOption[0]));
			GUILayout.EndHorizontal();
			return vector2;
		}
		internal static int DisplaySlider(int value, int left, int right, string label)
		{
			GUILayout.Label(label, new GUILayoutOption[0]);
			return Mathf.RoundToInt(GUILayout.HorizontalSlider((float)value, (float)left, (float)right, new GUILayoutOption[0]));
		}
		internal static object DisplayGenericValues(object value, string labelInfo = "")
		{
			string text = string.IsNullOrEmpty(labelInfo) ? "" : ("[" + labelInfo + "]");
			if (!(value is int))
			{
				if (!(value is bool))
				{
					if (!(value is float))
					{
						if (!(value is string))
						{
							if (!(value is Color))
							{
								if (!(value is Vector3))
								{
									if (!(value is Quaternion))
									{
										if (!(value is Component))
										{
											if (!(value is GameObject))
											{
												if (!(value is FsmState))
												{
													if (!(value is Material))
													{
														if (!(value is IList))
														{
															if (!(value is IDictionary))
															{
																GUILayout.Label("<b>" + text + ":</b> " + value.ToString(), new GUILayoutOption[0]);
															}
															else
															{
																value = (value as IDictionary).DisplayDictionary("<b>" + text + ":</b> " + value.ToString());
															}
														}
														else
														{
															value = (value as IList).DisplayList("<b>" + text + ":</b> " + value.ToString());
														}
													}
													else
													{
														if (!string.IsNullOrEmpty(text))
														{
															GUILayout.Label("<b>" + text + ":</b>", new GUILayoutOption[0]);
														}
														(value as Material).DisplayMaterial("");
													}
												}
												else if ((value as FsmState).Fsm.Initialized)
												{
													GUILayout.BeginHorizontal(new GUILayoutOption[0]);
													GUILayout.Label("<b>" + text + ":</b> " + (value as FsmState).Name, new GUILayoutOption[0]);
													ComponentDisplay.DisplayReferenceButton((value as FsmState).Fsm.Owner as PlayMakerFSM, "");
													GUILayout.EndHorizontal();
												}
												else
												{
													GUILayout.Label(string.Format("<b>{0}:</b> {1}", text, value), new GUILayoutOption[0]);
												}
											}
											else
											{
												ComponentDisplay.DisplayReferenceButton(value as GameObject, text);
											}
										}
										else
										{
											ComponentDisplay.DisplayReferenceButton(value as Component, text);
										}
									}
									else
									{
										value = ((Quaternion)value).DisplayQuaternion(text, "");
									}
								}
								else
								{
									value = ((Vector3)value).DisplayVector3(text, "");
								}
							}
							else
							{
								value = ComponentDisplay.DisplayColor((Color)value, text);
							}
						}
						else
						{
							value = ComponentDisplay.DisplayTextBox((string)value, text);
						}
					}
					else
					{
						value = ComponentDisplay.DisplayTextBox((float)value, text);
					}
				}
				else
				{
					value = ComponentDisplay.DisplayToggle((bool)value, text);
				}
			}
			else
			{
				value = ComponentDisplay.DisplayTextBox((int)value, text);
			}
			return value;
		}
		internal static bool DisplayTransformIncrementButton(Vector3 vector3, out Vector3 newVector3)
		{
			newVector3 = vector3;
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			bool flag;
			if (ComponentDisplay.DisplayButton(string.Format("{0}", ComponentDisplay.transformIncrement * -1f), out flag))
			{
				newVector3.x += ComponentDisplay.transformIncrement * -1f;
			}
			bool flag2;
			if (ComponentDisplay.DisplayButton(string.Format("{0}", ComponentDisplay.transformIncrement), out flag2))
			{
				newVector3.x += ComponentDisplay.transformIncrement;
			}
			bool flag3;
			if (ComponentDisplay.DisplayButton(string.Format("{0}", ComponentDisplay.transformIncrement * -1f), out flag3))
			{
				newVector3.y += ComponentDisplay.transformIncrement * -1f;
			}
			bool flag4;
			if (ComponentDisplay.DisplayButton(string.Format("{0}", ComponentDisplay.transformIncrement), out flag4))
			{
				newVector3.y += ComponentDisplay.transformIncrement;
			}
			bool flag5;
			if (ComponentDisplay.DisplayButton(string.Format("{0}", ComponentDisplay.transformIncrement * -1f), out flag5))
			{
				newVector3.z += ComponentDisplay.transformIncrement * -1f;
			}
			bool flag6;
			if (ComponentDisplay.DisplayButton(string.Format("{0}", ComponentDisplay.transformIncrement), out flag6))
			{
				newVector3.z += ComponentDisplay.transformIncrement;
			}
			GUILayout.EndHorizontal();
			return flag || flag2 || flag3 || flag4 || flag5 || flag6;
		}
		internal static bool DisplayButton(string label, out bool pressed)
		{
			pressed = false;
			if (GUILayout.Button(label, new GUILayoutOption[0]))
			{
				pressed = true;
				return true;
			}
			return false;
		}
		private static void SetFsmVisibility(this PlayMakerFSM fsm, int type)
		{
			ComponentDisplay.fsmToggles[fsm][type] = !ComponentDisplay.fsmToggles[fsm][type];
		}
		private static bool GetFsmVisibility(this PlayMakerFSM fsm, int type)
		{
			return ComponentDisplay.fsmToggles[fsm][type];
		}
		private static void DisplayFSMExpandButton(PlayMakerFSM fsm, string typeName, int type)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Space(10f);
			string text = ComponentDisplay.fsmToggles[fsm][type] ? "Hide" : "Show";
			if (GUILayout.Button(string.Concat(new string[]
			{
				text,
				" - <b>",
				typeName,
				"</b> - ",
				text
			}), new GUILayoutOption[0]))
			{
				fsm.SetFsmVisibility(type);
			}
			GUILayout.EndHorizontal();
		}
		public static bool variablesPublic;
		public static bool variablesNonPublic;
		public static Dictionary<FsmState, bool> stateToggle = new Dictionary<FsmState, bool>();
		public static Dictionary<Component, bool> componentToggle = new Dictionary<Component, bool>();
		public static Dictionary<PlayMakerFSM, bool[]> fsmToggles = new Dictionary<PlayMakerFSM, bool[]>();
		public static float transformIncrement = 1f;
		public static Vector3[] transformLocalValues;
		public static Vector3[] transformGlobalValues;
		public static Vector3 transformScaleValues;
		public static int listCountLimit = 20;
		private static bool showLocalPosition = true;
	}
}
