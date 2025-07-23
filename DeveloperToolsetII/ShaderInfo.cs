using System;
using System.Collections.Generic;

namespace DeveloperToolsetII
{
	public static class ShaderInfo
	{
		public static string[] textureTypes = new string[]
		{
			"_MainTex",
			"_MetallicGlossMap",
			"_BumpMap",
			"_ParallaxMap",
			"_OcclusionMap",
			"_EmissionMap",
			"_DetailMask",
			"_DetailAlbedoMap",
			"_DetailNormalMap",
			"_SpecGlossMap",
			"_Rain",
			"_ShadowTex",
			"_FalloffTex"
		};
		public static string[] floatTypes = new string[]
		{
			"_Cutoff",
			"_Glossiness",
			"_Metallic",
			"_BumpScale",
			"_Parallax",
			"_OcclusionStrength",
			"_DetailNormalMapScale",
			"_UVSec",
			"_InvFade",
			"_RainOpacity",
			"_Raining",
			"_Shininess",
			"_Intensity"
		};
		public static string[] colorTypes = new string[]
		{
			"_Color",
			"_EmissionColor",
			"_TintColor",
			"_SpecColor",
			"_Tint"
		};
		public static Dictionary<string, List<string[]>> materialProperties = new Dictionary<string, List<string[]>>
		{
			{
				"Standard",
				new List<string[]>
				{
					new string[]
					{
						"_MainTex",
						"_MetallicGlossMap",
						"_BumpMap",
						"_ParallaxMap",
						"_OcclusionMap",
						"_EmissionMap",
						"_DetailMask",
						"_DetailAlbedoMap",
						"_DetailNormalMap"
					},
					new string[]
					{
						"_Cutoff",
						"_Glossiness",
						"_Metallic",
						"_BumpScale",
						"_Parallax",
						"_OcclusionStrength",
						"_DetailNormalMapScale",
						"_UVSec"
					},
					new string[]
					{
						"_Color",
						"_EmissionColor"
					}
				}
			},
			{
				"Standard (Specular setup)",
				new List<string[]>
				{
					new string[]
					{
						"_MainTex",
						"_SpecGlossMap",
						"_BumpMap",
						"_ParallaxMap",
						"_OcclusionMap",
						"_EmissionMap",
						"_DetailMask",
						"_DetailAlbedoMap",
						"_DetailNormalMap"
					},
					new string[]
					{
						"_Cutoff",
						"_Glossiness",
						"_BumpScale",
						"_Parallax",
						"_OcclusionStrength",
						"_DetailNormalMapScale",
						"_UVSec"
					},
					new string[]
					{
						"_Color",
						"_SpecColor",
						"_EmissionColor"
					}
				}
			},
			{
				"Particles/Alpha Blended",
				new List<string[]>
				{
					new string[]
					{
						"_MainTex"
					},
					new string[]
					{
						"_InvFade"
					},
					new string[]
					{
						"_TintColor"
					}
				}
			},
			{
				"Windshield/windshield",
				new List<string[]>
				{
					new string[]
					{
						"_MainTex",
						"_BumpMap",
						"_Rain"
					},
					new string[]
					{
						"_Glossiness",
						"_RainOpacity",
						"_Raining"
					},
					new string[]
					{
						"_Color"
					}
				}
			},
			{
				"Legacy Shaders/Diffuse",
				new List<string[]>
				{
					new string[]
					{
						"_MainTex"
					},
					new string[0],
					new string[]
					{
						"_Color"
					}
				}
			},
			{
				"Legacy Shaders/Bumped Diffuse",
				new List<string[]>
				{
					new string[]
					{
						"_MainTex",
						"_BumpMap"
					},
					new string[0],
					new string[]
					{
						"_Color"
					}
				}
			},
			{
				"Legacy Shaders/Bumped Specular",
				new List<string[]>
				{
					new string[]
					{
						"_MainTex",
						"_BumpMap"
					},
					new string[]
					{
						"_Shininess"
					},
					new string[]
					{
						"_Color",
						"_SpecColor"
					}
				}
			},
			{
				"Unlit/Texture",
				new List<string[]>
				{
					new string[]
					{
						"_MainTex"
					},
					new string[0],
					new string[0]
				}
			},
			{
				"Legacy Shaders/Transparent/Diffuse",
				new List<string[]>
				{
					new string[]
					{
						"_MainTex"
					},
					new string[0],
					new string[]
					{
						"_Color"
					}
				}
			}
		};
	}
}
