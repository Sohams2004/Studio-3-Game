Shader"Unlit/Dissolve"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (0,0,0,1)
        _Width ("Width", Range(0, 1)) = 0.2
        _DissolveTex("Dissovle Texture", 2D) = "white" {}
        _DissolveThreshold("Dissolve threshold", Range(0,1)) = 0.5
        _EdgeColor("Edge Color", Color) = (1,0.5,0,1)
        
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

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
            float4 _Color;
            float _DissolveThreshold;
            float _Width;
            float4 _EdgeColor;
            

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed dissolveValue = tex2D(_MainTex, i.uv).r;
    
                if(dissolveValue < _DissolveThreshold - _Width)
                {
                    discard;
                }
    
                else if(dissolveValue < _DissolveThreshold)
                {
                    col.rbg = lerp(_EdgeColor.rgb, col.rgb, (dissolveValue - (_DissolveThreshold - _Width)) / _Width);

                }
                return col;
            }
            ENDCG
        }
    }
}
