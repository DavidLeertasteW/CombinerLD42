using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurserMovement : MonoBehaviour
{


    public KeyCode forward, backward, left, right, shift, alt;

    public int pawns;


    public string winText = "Player X wins!";
   

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!Input.GetKey(shift)&&!Input.GetKey(alt))
        {
            if (Input.GetKeyDown(forward))
            {
                transform.position = transform.position + Vector3.forward;

            }
            if (Input.GetKeyDown(backward))
            {
                transform.position = transform.position + Vector3.back;

            }
            if (Input.GetKeyDown(left))
            {
                transform.position = transform.position + Vector3.left;

            }
            if (Input.GetKeyDown(right))
            {
                transform.position = transform.position + Vector3.right;

            }
        }






            }

        }
    

