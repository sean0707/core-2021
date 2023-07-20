Shader "Custom/MyDissolveSurface" 
{
	Properties{
		//英文版
		//_Color ("Color", Color) = (1,1,1,1)
		//_MainTex ("Albedo (RGB)", 2D) = "white" {}
		//_Glossiness ("Smoothness", Range(0,1)) = 0.5
		//_Metallic ("Metallic", Range(0,1)) = 0.0
		//
		// _NoiseTex ("NoiseTex (R)",2D) = "white"{}  
		//        _EdgeWidth("EdgeWidth",Range(0,0.5)) = 0.1  
		//        _EdgeColor("EdgeColor",Color) =  (1,1,1,1)  
		//  _EdgeThresholdValue ("EdgeThresholdValue(Zero for not use)",Range(0,1)) = 0.5  
		//        _DissolvePercentage ("DissolvePercentage",Range(0,1)) = 0  
		//中文版
		_Color("顏色", Color) = (1,1,1,1)
		_MainTex("主貼圖 (RGB)", 2D) = "white" {}
		_Glossiness("平滑度", Range(0,1)) = 0.5
		_Metallic("金屬性", Range(0,1)) = 0.0
		_NoiseTex("噪聲貼圖 (R)",2D) = "white"{}
		_EdgeWidth("邊緣寬度",Range(0,0.5)) = 0.1
		_EdgeColor("邊緣顏色",Color) = (1,1,1,1)
		_EdgeThresholdValue("硬邊緣閾值(0為不使用)",Range(0,1)) = 0.5
		_DissolvePercentage("溶解百分比",Range(0,1)) = 0
	}

		SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200
		CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			//原編譯指令
			//#pragma surface surf Standard fullforwardshadows
			//增加addshadow以獲得正確的陰影
			#pragma surface surf Standard fullforwardshadows addshadow
			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0
			sampler2D _MainTex;
			sampler2D _NoiseTex;
			float _EdgeWidth;
			float4 _EdgeColor;
			float _EdgeThresholdValue;
			float _DissolvePercentage;
			struct Input {
			float2 uv_MainTex;
			float3 worldPos;
			};
			half _Glossiness;
			half _Metallic;
			fixed4 _Color;
			void surf(Input IN, inout SurfaceOutputStandard o) {

				// Albedo comes from a texture tinted by color
				fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
				o.Albedo = c.rgb;
				// Metallic and smoothness come from slider variables
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				o.Alpha = c.a;
				float DissolveFactor = saturate(_DissolvePercentage);
				//使用固定座標
						   // float noiseValue = tex2D(_NoiseTex,IN.uv_MainTex).r;   
							//使用世界座標
							 float noiseValue = tex2D(_NoiseTex,IN.worldPos.rg).r;

							 //如果該值對應噪聲圖的值更大，則拋棄

						   if (noiseValue <= DissolveFactor)
						   {
							   discard;
						   }
						   float4 texColor = tex2D(_MainTex,IN.uv_MainTex);
						   float EdgeFactor = saturate((noiseValue - DissolveFactor) / (_EdgeWidth*DissolveFactor));
						   float4 BlendColor = texColor * _EdgeColor;

						  if (_EdgeThresholdValue > 0) {
							  //不使用漸變（硬邊緣）
							 float HardEdgeFactor = EdgeFactor;
							 if (HardEdgeFactor > _EdgeThresholdValue) {
							 HardEdgeFactor = 1;
							 o.Emission = 0;
							 }
				   else {
				  HardEdgeFactor = 0;
				  o.Emission = _EdgeColor;
				  }
				  o.Albedo = lerp(texColor,BlendColor,1 - EdgeFactor);
				   }
		else {
	   o.Emission = 0;
	   //使用漸變（軟邊緣）
	   if (_EdgeThresholdValue >= 1) {
		 o.Albedo = BlendColor;
		 o.Alpha = 0;
	   }
else {
o.Albedo = lerp(texColor,BlendColor,1 - EdgeFactor);
}
}

}
ENDCG
		}
			FallBack "Diffuse"
}