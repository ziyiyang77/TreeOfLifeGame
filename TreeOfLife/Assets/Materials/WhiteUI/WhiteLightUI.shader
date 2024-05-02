Shader "UI/WhiteLightUI"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {} // ��ť����ͼ
        _GlowColor("Glow Color", Color) = (1,1,1,1) // ������ɫ
        _GlowStrength("Glow Strength", Float) = 1.0 // ����ǿ��
    }

        SubShader
        {
            Tags { "Queue" = "Overlay" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
            Blend SrcAlpha OneMinusSrcAlpha
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
                    UNITY_FOG_COORDS(1)
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float4 _GlowColor;
                float _GlowStrength;

                v2f vert(appdata_t v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    UNITY_TRANSFER_FOG(o,o.vertex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    // ������ͼ
                    fixed4 texColor = tex2D(_MainTex, i.uv);

                // ���㷢��Ч��
                fixed4 glow = _GlowColor * _GlowStrength;

                // ���ؾ������⴦�����ɫ
                return texColor + glow;
            }
            ENDCG
        }
        }
}
