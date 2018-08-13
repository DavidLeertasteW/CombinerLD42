using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffects : MonoBehaviour {



    [SerializeField]
    GameObject audioPlayingObject;


    [SerializeField]
    AudioClip[] walkingEffects, destructionEffects;

    [SerializeField]
    AnimationCurve volume;

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
        
        if (type == "destruction")
        {
            AudioSource tempSource = GameObject.Instantiate(audioPlayingObject).GetComponent<AudioSource>();
            tempSource.clip = destructionEffects[index];
            tempSource.volume = volume.Evaluate(1 / (index + 1)) * 0.25f;
            type = "walking";
        }
        

        if (type == "walking")
        {
            AudioSource tempSource = GameObject.Instantiate(audioPlayingObject).GetComponent<AudioSource>();
            tempSource.clip = walkingEffects[index];
            tempSource.volume = volume.Evaluate(1 / (index+1));
        }
       
    }
}
