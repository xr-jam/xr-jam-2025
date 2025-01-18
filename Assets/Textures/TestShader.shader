Shader "UI/TestShader"
{
    Properties
    {
        _Color("Base Color", Color) = (1,1,1,1)
        _FadeWidth("Fade Width", Float) = 0.5
    }
        SubShader
    {
        Tags { "Queue" = "Overlay" }
        Pass
        {
            ZTest Always Cull Off ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

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
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            float _FadeWidth;
            float4 _Color;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // Calculate distance to the nearest edge on X-axis and Y-axis
                float distToEdgeX = max(i.uv.x, 1.0 - i.uv.x); // Distance from nearest X edge
                float distToEdgeY = max(i.uv.y, 1.0 - i.uv.y); // Distance from nearest Y edge

                // Combine X and Y distances (fade effect depends on both)
                float distToEdge = max(distToEdgeX, distToEdgeY); // Choose max distance to edge (invert center effect)

                // Invert the distance and create fade effect
                float alpha = saturate((distToEdge - (1.0 - _FadeWidth)) / _FadeWidth);

                return fixed4(_Color.rgb, _Color.a * alpha);
            }


            ENDCG
        }
    }
}
