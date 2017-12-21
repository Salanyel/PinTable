// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "PinTable/VertexColor"
{
	Properties
	{
	}

	SubShader
	{	
		Tags {
			"RenderType" = "Opaque"
		}

		Pass {		
			CGPROGRAM 
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				struct VertIn {
					float4 vertex : POSITION;
					float4 color : COLOR;
				};

				struct VertOut {
				 float4 position : POSITION;
				 float4 color : COLOR;
				};

				VertOut vert (VertIn input) {
					VertOut output;
					output.position = UnityObjectToClipPos(input.vertex);
					output.color = input.color;
					return  output;
				}

				struct FragOut {
					float4 color : COLOR;
				};

				FragOut frag (float4 color: COLOR) {
					FragOut output;
					output.color = color;
					return output;
				}

			ENDCG
		}
	}

	FallBack "Diffuse"
}
