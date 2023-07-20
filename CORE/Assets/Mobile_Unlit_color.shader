//////////////////////////////////////////
//
// NOTE: This is *not* a valid shader file
//
///////////////////////////////////////////
Shader "Custom/Mobile_Unlit_Color" {
Properties {
 _MultiColor ("MultiColor", Color) = (1,1,1,1)
 _AddColor ("AddColor", Color) = (0,0,0,0)
 _MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader { 
 Pass {
  Blend SrcAlpha OneMinusSrcAlpha
  SetTexture [_MainTex] { ConstantColor [_MultiColor] combine texture * constant, texture alpha * constant alpha }
  SetTexture [_MainTex] { ConstantColor [_AddColor] combine previous + constant, previous alpha + constant alpha }
 }
}
}