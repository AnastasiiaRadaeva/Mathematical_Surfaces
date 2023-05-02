Shader "Graph/Point Surface" //It begins with the Shader keyword followed by a string defining a menu item for the shader.
{
	Properties {
		_Smoothness ("Smoothness", Range(0,1)) = 0.5
	}
	
    SubShader {
        CGPROGRAM
		#pragma surface ConfigureSurface Standard fullforwardshadows
		#pragma target 3.0
        
        struct Input {
			float3 worldPos;
		};

        float _Smoothness;
        
		void ConfigureSurface (Input input, inout SurfaceOutputStandard surface)
        //inout is keyword which indicates that it's both passed to the function and used for the result of the function.
		{
			surface.Albedo.gb = saturate(input.worldPos.xy * 0.5 + 0.5);
			surface.Smoothness = _Smoothness;
		}
        ENDCG
    }
	FallBack "Diffuse" //fallback to the standard diffuse shader
}
