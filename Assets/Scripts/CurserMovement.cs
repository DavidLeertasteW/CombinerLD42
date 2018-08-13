using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurserMovement : MonoBehaviour
{


    public KeyCode forward, backward, left, right, shift, alt;

    public int pawns;


    public string winText = "Player X wins!";

    AudioEffects audioEffects;
   

    // Use this for initialization
    void Start()
    {
        audioEffects = Camera.main.gameObject.GetComponent<AudioEffects>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!Input.GetKey(shift)&&!Input.GetKey(alt))
        {
            if (Input.GetKeyDown(forward))
            {
                transform.position = transform.position + Vector3.forward;
                if(audioEffects != null){
                    audioEffects.PlaySoundEffect(0, "walking");
                }

            }
            if (Input.GetKeyDown(backward))
            {
                transform.position = transform.position + Vector3.back;
                if (audioEffects != null)
                {
                    audioEffects.PlaySoundEffect(0, "walking");
                }

            }
            if (Input.GetKeyDown(left))
            {
                transform.position = transform.position + Vector3.left;
                if (audioEffects != null)
                {
                    audioEffects.PlaySoundEffect(0, "walking");
                }

            }
            if (Input.GetKeyDown(right))
            {
                transform.position = transform.position + Vector3.right;
                if (audioEffects != null)
                {
                    audioEffects.PlaySoundEffect(0, "walking");
                }

            }
        }






            }


        }
    

