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

                UNITY_VERTEX_INPUT_INSTANCE_ID // For GPU instancing
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;

                UNITY_VERTEX_OUTPUT_STEREO // For stereo output
            };

            float _FadeWidth;
            float4 _Color;

            v2f vert(appdata_t v)
            {
                v2f o;

                // Initialize for instancing and stereo rendering (no parameters needed)
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_OUTPUT(v2f, o); // Proper initialization of output struct
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

                // Transform the vertex position for VR
                #ifdef UNITY_SINGLE_PASS_STEREO
                    float4x4 unity_ObjectToClip = unity_StereoMatrixVP[unity_StereoEyeIndex];
                #else
                    float4x4 unity_ObjectToClip = UNITY_MATRIX_MVP;
                #endif

                o.vertex = mul(unity_ObjectToClip, v.vertex);

                // Pass UV coordinates to the fragment shader
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

                return fixed4(_Color.rgb, _Color.a * alpha); // Apply fade effect to the alpha
            }
            ENDCG
        }
    }
}
