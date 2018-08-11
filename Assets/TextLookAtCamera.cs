using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLookAtCamera : MonoBehaviour {



	// Use this for initialization
	void Start () {
        transform.LookAt(Camera.main.gameObject.transform.position);

        transform.Rotate(transform.up, 180);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
