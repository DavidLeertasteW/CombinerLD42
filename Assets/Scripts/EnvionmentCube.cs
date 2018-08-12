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

    ParticleSystem particle;


	// Use this for initialization
	void Start () {
        
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        collider = gameObject.GetComponent<BoxCollider>();

       /* particle = transform.GetChild(0).gameObject.GetComponent<ParticleSystem>();

        if (particle != null)
        {
            particle.Stop();
            var duration = particle.main;
            duration.duration = lifetime;
            particle.Play();

        }
*/

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
        float perc = timeSinceStart / (lifetime + spawnsAfter);
        Color col = Color.Lerp(Color.white, Color.black, perc);
        mat.color = col;
       
       

        //rateOverTime = perc*20;


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
