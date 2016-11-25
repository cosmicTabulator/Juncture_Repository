Shader "Unlit/Color Swapper"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_ColorA ("A",Color) = (0, 0, 0, 1)
		_ColorB ("B",Color) = (0, 0, 0, 1)
		_ColorC ("C",Color) = (0, 0, 0, 1)
		_ColorD ("D",Color) = (0, 0, 0, 1)
		//_Level ("Level", int) = 0;
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			fixed4 _ColorA;
			fixed4 _ColorB;
			fixed4 _ColorC;
			fixed4 _ColorD;

			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				if(col.r > _ColorA.r-0.01){
					col = _ColorB;
				}
				else if(col.r > _ColorB.r-0.01){
					col = _ColorC;
				}
				else if(col.r > _ColorC.r-0.01){
					col = _ColorD;
				}
				return col;
			}
			ENDCG
		}
	}
}
