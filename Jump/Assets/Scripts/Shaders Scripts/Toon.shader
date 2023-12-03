Shader "Unlit/Toon"
{
    Properties
    {
        _Albedo("Albedo", Color) = (1,1,1,1)
        _Shades("Shades", Range(1, 20)) = 3
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
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
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float3 worldNormal : TEXCOORD0;
            };

            float4 _Albedo;
            float _Shades;
            

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                //calculate the cosine of the given angle between the normal vector and the light direction
                //the world space light direction is stored in _WorldSpaceLightPose0
                //the world space normal is stores in i.worldNormal
                //calculate doct product

                float cosineAngle = dot(normalize(i.worldNormal), normalize(_WorldSpaceLightPos0.xyz));

                //set the min to zero because a negative can occur if the lighting is behined the shaded point
                cosineAngle = max(cosineAngle, 0.0);
                cosineAngle = floor(cosineAngle * _Shades) / _Shades;
                return _Albedo * cosineAngle;
            }
            ENDCG
        }
    }
}
