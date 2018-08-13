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
    GameObject child;


	// Use this for initialization
	void Awake () {
        
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        collider = gameObject.GetComponent<BoxCollider>();

      

        if (spawnsAfter > 0)
        {
            meshRenderer.enabled = false;
            collider.enabled = false;
            if (transform.childCount > 0)
            {
                child = transform.GetChild(0).gameObject;

                child.SetActive(false);

            }
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
        if (timeSinceStart >= lifetime + spawnsAfter + 0.5f)
        {
            Destroy(gameObject);

        }
        if (timeSinceStart >= lifetime + spawnsAfter)
        {
            gameObject.GetComponent<ScaleAnimator>().enabled = true;
            gameObject.GetComponent<ScaleAnimator>().forward = true;
            collider.enabled = false;
            return;
        }


        if (timeSinceStart >= spawnsAfter)
        {
            gameObject.GetComponent<ScaleAnimator>().enabled = true;
            gameObject.GetComponent<ScaleAnimator>().forward = false;
            meshRenderer.enabled = true;
            collider.enabled = true;
            if (child != null)
            {
                if (transform.localScale.x > 0.5f)
                {
                    child.SetActive(true);
                }
            }

        }
       


		
	}
}
