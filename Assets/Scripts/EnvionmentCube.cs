using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvionmentCube : MonoBehaviour {

    [SerializeField]
    float lifetime = 60, spawnsAfter = 0;



    float timeSinceStart = 0;

    Material mat;
    BoxCollider collider;
    MeshRenderer meshRenderer;

	// Use this for initialization
	void Start () {
        
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        collider = gameObject.GetComponent<BoxCollider>();

        if (spawnsAfter > 0)
        {
            meshRenderer.enabled = false;
            collider.enabled = false;
        }

        mat = meshRenderer.material;
	}
	
	// Update is called once per frame
	void Update () {
        
        timeSinceStart += Time.deltaTime;
        mat.color = Color.Lerp(Color.white, Color.black, timeSinceStart / (lifetime+spawnsAfter));
        if (timeSinceStart >= spawnsAfter)
        {
            meshRenderer.enabled = true;
            collider.enabled = true;

        }

        if (timeSinceStart >= lifetime + spawnsAfter){
            Destroy(gameObject);

        }
		
	}
}
