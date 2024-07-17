Shader"Unlit/OutlineShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _OutlineColor ("Outlinr color", Color) = (0.255, 0.215, 0, 1)  
        _OutlineWidth ("Outline Width", Range(0, 0.1)) = 0.05
        _OutlineGlowIntensity("Glow Intensity", Range(0, 10)) = 5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        CGPROGRAM
        #pragma surface surf Lambert
        sampler2D _MainTex ;

        struct Input
        {
             float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }

        ENDCG

        Pass
        {
            Cull Front

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag


            #include "UnityCG.cginc"
            
            //defining the input structure for the vertex shader.
            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            
            //defining the output structure of the vertex shader / input to the fragment shader.
            struct v2f
            {
                float4 pos : SV_POSITION;
            };
            
            //Defining variables for vertex and fragment shaders
            float _OutlineWidth;
            fixed4 _OutlineColor;
            float _GlowIntensity;

            //Vertex shader.It expands the vertex along its normal by _OutlineWidth and transforms it to clip space.
            v2f vert(appdata v)
            {
                v2f o;
                v.vertex.xyz += v.normal * _OutlineWidth;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }
            
            //Fragment shader. Returning the outline color and glow.
            fixed4 frag(v2f i) : SV_Target
            {
                return _OutlineColor * _GlowIntensity;
            }
            ENDCG
        }
    }
}
