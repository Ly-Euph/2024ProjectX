Shader "Custom/CenterFadeOutShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _FadeAmount("Fade Amount", Range(0, 1)) = 0.0
        _Center("Center Position", Vector) = (0, 0, 0, 0)
    }
        SubShader
        {
            Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
            LOD 200

            CGPROGRAM
            #pragma surface surf Standard alpha:fade

            sampler2D _MainTex;
            float _FadeAmount;
            float4 _Center;

            struct Input
            {
                float2 uv_MainTex;
                float3 worldPos;
            };

            void surf(Input IN, inout SurfaceOutputStandard o)
            {
                half4 c = tex2D(_MainTex, IN.uv_MainTex);
                float distanceFromCenter = distance(IN.worldPos, _Center.xyz);
                float fadeFactor = smoothstep(_FadeAmount, _FadeAmount + 0.1, distanceFromCenter);
                o.Albedo = c.rgb;
                o.Alpha = c.a * fadeFactor;  // 1.0から0.0にフェードアウト
            }
            ENDCG
        }
            FallBack "Diffuse"
}
// 
// 部分的に消すやつ
//Shader "Custom/PartialFadeShader"
//{
//    Properties
//    {
//        _MainTex("Texture", 2D) = "white" {}
//        _Center("Center Position", Vector) = (0, 0, 0, 0)
//        _Radius("Fade Radius", Range(0, 10)) = 0.2
//    }
//        SubShader
//        {
//            Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
//            LOD 200
//
//            CGPROGRAM
//            #pragma surface surf Standard alpha:fade
//
//            sampler2D _MainTex;
//            float4 _Center;
//            float _Radius;
//
//            struct Input
//            {
//                float2 uv_MainTex;
//                float3 worldPos;
//            };
//
//            void surf(Input IN, inout SurfaceOutputStandard o)
//            {
//                float distanceFromCenter = distance(IN.worldPos, _Center.xyz);
//                float fadeFactor = smoothstep(_Radius - 0.1, _Radius, distanceFromCenter);
//                o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
//                o.Alpha = fadeFactor;
//            }
//            ENDCG
//        }
//            FallBack "Diffuse"
//}

