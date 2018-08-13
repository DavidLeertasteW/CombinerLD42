using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerUI : MonoBehaviour {
    [SerializeField]
    GameObject[] activateThese;
    [SerializeField]
    GameObject[] deactivateThese;
    [SerializeField]
    Transform master;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (master != null)
        {


            if (transform.position == master.position)
            {
                Debug.Log("trigger");
                for (int i = 0; i < activateThese.Length; i++)
                {
                    activateThese[i].SetActive(true);
                }
                for (int i = 0; i < deactivateThese.Length; i++)
                {
                    deactivateThese[i].SetActive(false);
                }

            }

        }
	}
}
