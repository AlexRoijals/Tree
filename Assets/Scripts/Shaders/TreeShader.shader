Shader "Custom/TreeShader" {
	Properties {
		
		//Standard Properties
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0

		//Vertex Animation Shader
		_Value1( "Value 1", Float ) = 0
		_Value2( "Value 2", Float ) = 0
		_Value3( "Value 3", Float ) = 0
	}
	SubShader 
		{
			//Pass
			//{
				Tags { "RenderType" = "Opaque" }
				LOD 200

				CGPROGRAM
				// Physically based Standard lighting model, and enable shadows on all light types
				#pragma surface surf Standard fullforwardshadows

				// Use shader model 3.0 target, to get nicer looking lighting
				#pragma target 3.0

				sampler2D _MainTex;

				struct Input {
					float2 uv_MainTex;
				};

				half _Glossiness;
				half _Metallic;
				fixed4 _Color;

				// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
				// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
				// #pragma instancing_options assumeuniformscaling
				UNITY_INSTANCING_BUFFER_START(Props)
					// put more per-instance properties here
				UNITY_INSTANCING_BUFFER_END(Props)

				void surf(Input IN, inout SurfaceOutputStandard o) 
				{
					// Albedo comes from a texture tinted by color
					fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
					o.Albedo = c.rgb;
					// Metallic and smoothness come from slider variables
					o.Metallic = _Metallic;
					o.Smoothness = _Glossiness;
					o.Alpha = c.a;
				}

				ENDCG
			//}
					Pass
				{
					Tags{ "LightMode" = "ForwardBase" }

					// Render faces when looking from the inside
					Cull Off

					CGPROGRAM

					// Pragmas
					#pragma vertex vert
					#pragma fragment frag

					// User defined variables
					uniform float4 _Color;
				uniform float _Value1;
				uniform float _Value2;
				uniform float _Value3;

				// Base input structs
				struct vertexInput
				{
					float4 vertex : POSITION;
					float3 normal : NORMAL;
					float4 texcoord : TEXCOORD0;
				};

				struct fragmentInput
				{
					float4 pos : SV_POSITION;
					float4 color : COLOR;
				};

				// Vertex function
				fragmentInput vert(vertexInput i)
				{
					fragmentInput o;

					// VERTEX ANIMATION ///////////////////////////////////////////////////////////////

					// Fat mesh
					// i.vertex.xyz += i.normal * _Value1;

					// Waving mesh
					//i.vertex.x += sin( ( i.vertex.y + _Time * _Value3 ) * _Value2 ) * _Value1;

					// Bubbling mesh
					i.vertex.xyz += i.normal * (sin((i.vertex.x + _Time * _Value3) * _Value2) + cos((i.vertex.z + _Time * _Value3) * _Value2)) * _Value1;

					//////////////////////////////////////////////////////////// EO VERTEX ANIMATION //

					// COLOR
					o.color = i.texcoord;								// UV
					//o.color = float4(i.normal, 1) * 0.5 + 0.5;		// Normals

																	// This line must be after the vertex manipulation
					o.pos = UnityObjectToClipPos(i.vertex);
					return o;
				}

				// Fragment function
				float4 frag(fragmentInput i) : Color
				{
					return i.color;
				}

					ENDCG
				}

		
	}
	FallBack "Diffuse"
}
