Shader "Custom/FadeOutShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _FadeAmount("Fade Amount", Range(0, 1)) = 0
    }
        SubShader
        {
            Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
            LOD 200

            CGPROGRAM
            #pragma surface surf Standard alpha:fade

            sampler2D _MainTex;
            half _FadeAmount;

            struct Input
            {
                float2 uv_MainTex;
                float3 worldPos;
            };

            void surf(Input IN, inout SurfaceOutputStandard o)
            {
                half4 c = tex2D(_MainTex, IN.uv_MainTex);
                float fade = saturate((IN.worldPos.y - _FadeAmount) * 10); // 調整可能なスケーリングファクター
                o.Albedo = c.rgb;
                o.Alpha = c.a * fade;
            }
            ENDCG
        }
            FallBack "Diffuse"
}
