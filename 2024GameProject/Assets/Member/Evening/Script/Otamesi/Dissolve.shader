Shader "Custom/Dissolve"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "white" {}
        _NoiseTex("Noise Texture", 2D) = "white" {}
        _DissolveAmount("Dissolve Amount", Range(0,1)) = 0.0
        _EdgeColor("Edge Color", Color) = (1, 0.5, 0, 1)
        _EdgeWidth("Edge Width", Range(0, 0.2)) = 0.05
    }

        SubShader
        {
            Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
            LOD 100
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata_t
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                sampler2D _NoiseTex;
                float _DissolveAmount;
                float4 _EdgeColor;
                float _EdgeWidth;

                v2f vert(appdata_t v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;

                    // 頂点を溶けるように下にずらす
                    float noise = tex2Dlod(_NoiseTex, float4(v.uv, 0, 0)).r;
                    v.vertex.y -= noise * _DissolveAmount * 0.5; // 下方向に動かす

                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    float4 col = tex2D(_MainTex, i.uv);
                    float noise = tex2D(_NoiseTex, i.uv).r;

                    // ディゾルブマスクの適用
                    float dissolve = noise - _DissolveAmount;

                    // エッジ部分を光らせる
                    float edge = smoothstep(-_EdgeWidth, _EdgeWidth, dissolve);

                    // Alpha の調整（0.1 → -0.1 に変更して、より広い範囲で透明化）
                    float alpha = smoothstep(-0.1, 0.2, dissolve);

                    fixed4 finalColor = lerp(_EdgeColor, col, edge);
                    finalColor.a *= alpha; // 消える効果

                    return finalColor;
                }
                ENDCG
            }
        }
}
