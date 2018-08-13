using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffects : MonoBehaviour {



    [SerializeField]
    GameObject audioPlayingObject;


    [SerializeField]
    AudioClip[] walkingEffects, destructionEffects;

	// Use this for initialization
	void Awake () {
        
	}


    public void PlaySoundEffect(int strength, string type)
    {
        switch (strength)
        {
            case 0:
                CreateAudioPlayer(0, type);
                break;
            case 1:
                CreateAudioPlayer(1, type);
                break;
            case 2:
                CreateAudioPlayer(2, type);
                break;
            case 4:
                CreateAudioPlayer(3, type);
                break;
            case 8:
                CreateAudioPlayer(4, type);
                break;
            case 16:
                CreateAudioPlayer(5, type);
                break;
            case 32:
                CreateAudioPlayer(6, type);
                break;
            case 64:
                CreateAudioPlayer(7, type);
                break;
            case 128:
                CreateAudioPlayer(8, type);
                break;


        }
    }
    void CreateAudioPlayer(int index, string type="walking"){
        
        AudioSource tempSource = GameObject.Instantiate(audioPlayingObject).GetComponent<AudioSource>();
        if (type == "walking")
        {
            tempSource.clip = walkingEffects[index];
        }
        if (type == "destruction")
        {
            tempSource.clip = destructionEffects[index];
        }
    }
}
