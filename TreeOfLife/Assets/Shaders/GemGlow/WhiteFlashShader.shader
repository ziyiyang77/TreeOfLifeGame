Shader "Custom/WhiteFlashShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _GlowCenter("Glow Center", Vector) = (0.5,0.5,0,0)
        _GlowRadius("Glow Radius", Float) = 0.5
        _GlowIntensity("Glow Intensity", Float) = 1
    }

        SubShader
        {
            Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Off

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
                float4 _MainTex_ST;
                float2 _GlowCenter;
                float _GlowRadius;
                float _GlowIntensity;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    float dist = distance(i.uv, _GlowCenter);
                    float glow = smoothstep(_GlowRadius, 0.0, dist) * _GlowIntensity;
                    fixed4 texColor = tex2D(_MainTex, i.uv);
                    fixed4 glowColor = fixed4(1, 1, 1, 1) * glow;
                    return texColor + glowColor;
                }
                ENDCG
            }
        }
}
