#pragma strict

var tex : Texture2D;
var fallback : Texture2D;
private var matrice : Vector2;
@range (1,8)
var quality : int = 1;
var flowspeed : float;
var renderers : Renderer[];
var refraction : boolean;

//cameras
private var WaterCamRight : GameObject;
var FarClipPlane : int;

function Start () {
	tex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
	matrice = new Vector2(0,0);

	WaterCamRight = new GameObject("RefractCameraRight");
	WaterCamRight.AddComponent.<Camera>();
	WaterCamRight.GetComponent.<Camera>().enabled = true;
	WaterCamRight.GetComponent.<Camera>().farClipPlane = GetComponent.<Camera>().farClipPlane;
	WaterCamRight.GetComponent.<Camera>().depth = GetComponent.<Camera>().depth-1;
	WaterCamRight.GetComponent.<Camera>().cullingMask = 1 + 0;
}

function Update () {
	matrice.x = matrice.x+(flowspeed/100);
	matrice.y = matrice.y-(flowspeed/100);
	
	for (var i = 0; i < renderers.length; ++i) {
	renderers[i].sharedMaterial.SetTextureOffset("_Normals",-matrice);
	renderers[i].sharedMaterial.SetTextureOffset("_ReflectTex",matrice);
	renderers[i].sharedMaterial.SetTextureOffset("_WaveMap",matrice);
		if (refraction){
			renderers[i].sharedMaterial.SetTexture("_RefractTex",tex);
		}
		else {
			renderers[i].sharedMaterial.SetTexture("_RefractTex",fallback);
		}
	}
}

function OnPreCull () {
	if (refraction){
		WaterCamRight.transform.position = transform.position;
		WaterCamRight.transform.rotation = transform.rotation;
		WaterCamRight.GetComponent.<Camera>().rect = Rect(0,0,1.0f/quality,1.0f/quality);
		WaterCamRight.GetComponent.<Camera>().Render();
		tex.Resize(Screen.width/quality, Screen.height/quality, TextureFormat.ARGB32, false);
		tex.ReadPixels(new Rect(0,0,Screen.width/quality,Screen.width/quality),0,0);
		tex.Apply();
		for (var i = 0; i < renderers.length; ++i) {
				renderers[i].sharedMaterial.SetTexture("_RefractTex",tex);
		}
	}
}