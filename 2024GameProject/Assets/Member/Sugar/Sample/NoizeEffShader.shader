Shader "Custom/AnimatedNoiseShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _NoiseTex("Noise Texture", 2D) = "white" {}
        _Intensity("Intensity", Range(0,1)) = 0.5
        _Speed("Speed", Vector) = (1, 1, 0, 0)
    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 100

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag

                #include "UnityCG.cginc"

                struct appdata
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
                float _Intensity;
                float2 _Speed;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    float2 uv = i.uv + _Speed * _Time.y;
                    fixed4 col = tex2D(_MainTex, uv);
                    fixed4 noise = tex2D(_NoiseTex, uv);
                    col.rgb = lerp(col.rgb, noise.rgb, _Intensity);
                    return col;
                }
                ENDCG
            }
        }
            FallBack "Diffuse"
}
