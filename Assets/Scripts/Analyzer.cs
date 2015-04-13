using UnityEngine;
using System.Collections;

public class Analyzer : MonoBehaviour {

    public float[] cubeInitPosX;
    public float[] cubeInitPosY;
    public float[] cubeInitPosZ;
    public GameObject[] cubes;
    public GameObject cube;
    public float juice = 50f;



	// Use this for initialization
	void Start () {



        float x, y;
        float length = 18f;
        float angle = 0.0f;
        float interval = 0.1f;

        int cicleSize = 0;
        while (angle < 2 * Mathf.PI)
        {
            angle += interval;
            cicleSize++;
        }

        angle = 0.0f;
        


        while (angle < 2 * Mathf.PI)
        {
            x = (length * Mathf.Cos(angle));
            y = (length * Mathf.Sin(angle));
            Instantiate(cube, new Vector3(x, 0, y), Quaternion.identity);
            angle += interval;
        }
     
        cubes = GameObject.FindGameObjectsWithTag("Cubes");
        cubeInitPosX = new float[cubes.Length];
        cubeInitPosY = new float[cubes.Length];
        cubeInitPosZ = new float[cubes.Length];

        for (int i = 0; i < cubes.Length; i++)
        {
            cubeInitPosX[i] = cubes[i].transform.localPosition.x;
            cubeInitPosY[i] = cubes[i].transform.localPosition.y;
            cubeInitPosZ[i] = cubes[i].transform.localPosition.z;
        }
        


      /*  cubeInitPosX = new float[4];
        cubeInitPosY = new float[4];
        cubeInitPosZ = new float[4];
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cubes");
        for (int i = 0; i < cubes.Length; i++)
        {
            switch (cubes[i].name)
            {
                case "Cube1":
                    cubeInitPosX[0] = cubes[i].transform.localPosition.x;
                    cubeInitPosY[0] = cubes[i].transform.localPosition.y;
                    cubeInitPosZ[0] = cubes[i].transform.localPosition.z;
                    break;
                case "Cube2":
                    cubeInitPosX[1] = cubes[i].transform.localPosition.x;
                    cubeInitPosY[1] = cubes[i].transform.localPosition.y;
                    cubeInitPosZ[1] = cubes[i].transform.localPosition.z;
                    break;
                case "Cube3":
                    cubeInitPosX[2] = cubes[i].transform.localPosition.x;
                    cubeInitPosY[2] = cubes[i].transform.localPosition.y;
                    cubeInitPosZ[2] = cubes[i].transform.localPosition.z;
                    break;
                case "Cube4":
                    cubeInitPosX[3] = cubes[i].transform.localPosition.x;
                    cubeInitPosY[3] = cubes[i].transform.localPosition.y;
                    cubeInitPosZ[3] = cubes[i].transform.localPosition.z;
                    break;
            }

        }
       * */
	
	}
	
	// Update is called once per frame
	void Update () {


        float[] audioValues = AudioListener.GetSpectrumData(8192, 0, FFTWindow.BlackmanHarris);
        //float [] audioValues = AudioListener.GetOutputData(1024,0);

        /*
        float div1=0,div2=0,div3=0,div4=0;

        for (int i = 3; i < 5; i++)     { div1 += audioValues[i]; }
        for (int i = 14; i < 18; i++)   { div2 += audioValues[i]; }
        for (int i = 26; i < 29; i++)   { div3 += audioValues[i]; }
        for (int i = 45; i < 60; i++)   { div4 += audioValues[i]; }
        */

        cubes = GameObject.FindGameObjectsWithTag("Cubes");
        for (int i = 0; i < cubes.Length; i++)
        {
            cubeInitPosX[i] = cubes[i].transform.localPosition.x;
            cubeInitPosY[i] = cubes[i].transform.localPosition.y;
            cubeInitPosZ[i] = cubes[i].transform.localPosition.z;
        }
		
		int counter = 6;
		float div;
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].transform.localPosition = new Vector3(cubeInitPosX[i], cubeInitPosY[i], cubeInitPosZ[i]);
			
			if(i < 7){
				div = 0;
				for(int j = 0; j <= 1; j++){
					div += audioValues[counter];
					counter++;
				}
				cubes[i].transform.localScale = new Vector3(1f, div*juice, 1f);
				cubes[i].transform.localPosition = new Vector3(cubeInitPosX[i], Mathf.Abs(div*juice / 2), cubeInitPosZ[i]);				
			}
			if(i >= 7 && i < 14){
				div = 0;
				for(int j = 0; j <= 2; j++){
					div += audioValues[counter];
					counter++;
				}
				cubes[i].transform.localScale = new Vector3(1f, div*juice, 1f);
				cubes[i].transform.localPosition = new Vector3(cubeInitPosX[i], Mathf.Abs(div*juice / 2), cubeInitPosZ[i]);	
			}
			if( i >= 14 && i < 21){
				div = 0;
				for(int j = 0; j <= 4; j++){
					div += audioValues[counter];
					counter++;
				}
				cubes[i].transform.localScale = new Vector3(1f, div*juice, 1f);
				cubes[i].transform.localPosition = new Vector3(cubeInitPosX[i], Mathf.Abs(div*juice / 2), cubeInitPosZ[i]);	
			}
			if( i >= 21 && i < 28){
				div = 0;
				for(int j = 0; j <= 8; j++){
					div += audioValues[counter];
					counter++;
				}
				cubes[i].transform.localScale = new Vector3(1f, div*juice, 1f);
				cubes[i].transform.localPosition = new Vector3(cubeInitPosX[i], Mathf.Abs(div*juice / 2), cubeInitPosZ[i]);	
			}
			if( i >= 28 && i < 35){
				div = 0;
				for(int j = 0; j <= 16; j++){
					div += audioValues[counter];
					counter++;
				}
				cubes[i].transform.localScale = new Vector3(1f, div*juice, 1f);
				cubes[i].transform.localPosition = new Vector3(cubeInitPosX[i], Mathf.Abs(div*juice / 2), cubeInitPosZ[i]);	
			}
			if( i >= 35 && i < 42){
				div = 0;
				for(int j = 0; j <= 32; j++){
					div += audioValues[counter];
					counter++;
				}
				cubes[i].transform.localScale = new Vector3(1f, div*juice, 1f);
				cubes[i].transform.localPosition = new Vector3(cubeInitPosX[i], Mathf.Abs(div*juice / 2), cubeInitPosZ[i]);	
			}
			if( i >= 42 && i < 49){
				div = 0;
				for(int j = 0; j <= 64; j++){
					div += audioValues[counter];
					counter++;
				}
				cubes[i].transform.localScale = new Vector3(1f, div*juice, 1f);
				cubes[i].transform.localPosition = new Vector3(cubeInitPosX[i], Mathf.Abs(div*juice / 2), cubeInitPosZ[i]);	
			}
			if( i >= 49 && i < 56){
				div = 0;
				for(int j = 0; j <= 128; j++){
					div += audioValues[counter];
					counter++;
				}
				cubes[i].transform.localScale = new Vector3(1f, div*juice, 1f);
				cubes[i].transform.localPosition = new Vector3(cubeInitPosX[i], Mathf.Abs(div*juice / 2), cubeInitPosZ[i]);	
			}
			if( i >= 56 && i < 63){
				div = 0;
				for(int j = 0; j <= 256; j++){
					div += audioValues[counter];
					counter++;
				}
				cubes[i].transform.localScale = new Vector3(1f, div*juice, 1f);
				cubes[i].transform.localPosition = new Vector3(cubeInitPosX[i], Mathf.Abs(div*juice / 2), cubeInitPosZ[i]);	
			}
			
            //cubes[i].transform.localScale = new Vector3(1f, audioValues[i]*juice, 1f);
            //cubes[i].transform.localPosition = new Vector3(cubeInitPosX[i], Mathf.Abs(audioValues[i]*juice / 2), cubeInitPosZ[i]);



            //transform.RotateAround(Vector3.zero, Vector3.up, 1*Time.deltaTime);
            cubes[i].transform.RotateAround(Vector3.zero, Vector3.up, 10f * Time.deltaTime);

            //float totalVolume = 0;
            //for (int v = 0; v < 8192; v++)
            //{
            //    totalVolume += audioValues[v];
            //}
            //Debug.Log(totalVolume);
        }
    
	}

}
