using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudioAfterPlaying : MonoBehaviour {

    AudioSource thisSource;

	// Use this for initialization
	void Start () {

        thisSource = gameObject.GetComponent<AudioSource>();
        thisSource.Play();
		
	}
	
	// Update is called once per frame
	void Update () {
        if(thisSource.isPlaying == false){
            Destroy(gameObject);
        }
		
	}
}
