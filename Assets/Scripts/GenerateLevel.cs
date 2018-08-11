using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour {
    [SerializeField]
    int width = 10, height = 10;

   

	// Use this for initialization
	void Start () {
        
        //GenerateLevel
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                SpawnCube(x, z);

            }
        }



    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnCube (int posX , int posZ){
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(posX, 0, posZ);
        cube.name = (posX + " ; " + posZ);


    }
   
}
