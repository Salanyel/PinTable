Shader "PinTable/PinTableShader1"
{
	Properties
	{
		_Color ("Vertex Color", Color) = (1,1,1,1)
		_Factor ("Height Modifier", Float) = 0.5
		_Speed ("Speed of the noise", Float) = 0.5
		_MainTex ("Noise texture", 2D) = "white" {}
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

				float4 _Color;
				float _Factor;
				float _Speed;
				sampler2D _MainTex;

				struct VertOut {
				 	float4 position : SV_POSITION;
				 	fixed4 color : COLOR;
				};

				VertOut vert (float4 position : POSITION, fixed4 color : COLOR, float2 uv : TEXCOORD0) {
					VertOut output;
					float4 modifiedUV = float4(uv.x + _Time.y * _Speed, uv.y + _Time.y * _Speed, 0, 0);

					output.color = color;
					position = position + color * float4(0, _Factor, 0, 0) * tex2Dlod(_MainTex, modifiedUV);
					output.position = UnityObjectToClipPos(position);

					return  output;
				}

				fixed4 frag (VertOut input) : SV_TARGET {
					fixed4 output;
					output = input.color * _Color;
					return output;
				}

			ENDCG
		}
	}

	FallBack "Diffuse"
}
