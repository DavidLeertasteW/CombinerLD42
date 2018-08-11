using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvionmentCube : MonoBehaviour {

    [SerializeField]
    float lifetime = 60;


    float timeSinceStart = 0;

    Material mat;

	// Use this for initialization
	void Start () {
        mat = gameObject.GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceStart += Time.deltaTime;
        mat.color = Color.Lerp(Color.white, Color.black, timeSinceStart / lifetime);

        if (timeSinceStart >= lifetime){
            Destroy(gameObject);

        }
		
	}
}
