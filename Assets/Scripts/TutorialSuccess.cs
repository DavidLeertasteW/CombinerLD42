using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSuccess : MonoBehaviour {

    [SerializeField]
    GameObject toEliminate1, toEliminate2;
    [SerializeField]
    LevelManager level;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if ((toEliminate1 == null||toEliminate1.active == false)&&(toEliminate2 == null || toEliminate2.active == false)){
            Debug.Log("Success");
            level.triggerSinglePlayerSuccess = true;
        }
	}
}
