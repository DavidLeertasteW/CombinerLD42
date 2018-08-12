using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSuccess : MonoBehaviour {

    [SerializeField]
    GameObject toEliminate;
    [SerializeField]
    LevelManager level;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (toEliminate == null||toEliminate.active == false){
            Debug.Log("Success");
            level.triggerSinglePlayerSuccess = true;
        }
	}
}
