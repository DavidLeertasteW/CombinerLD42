using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurserMovement : MonoBehaviour
{


    public KeyCode forward, backward, left, right, shift, alt;

    public int pawns;


    public string winText = "Player X wins!";

    AudioEffects audioEffects;
    SkinnedMeshRenderer skinned;

    [SerializeField]
    Vector2 ownPawn, otherCube, noCube;
    [SerializeField]
    Vector2 altOwnPawn, altOtherCube, altNoCube;
    [SerializeField]
    Vector2 shiftOwnPawn, shiftOtherCube, shiftNoCube;
   

    // Use this for initialization
    void Start()
    {
        audioEffects = Camera.main.gameObject.GetComponent<AudioEffects>();
        skinned = gameObject.GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!Input.GetKey(shift) && !Input.GetKey(alt))
        {
            if (Input.GetKeyDown(forward))
            {
                transform.position = transform.position + Vector3.forward;
                if (audioEffects != null)
                {
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
            //BlendshapeUpdate(1, 0);
            //BlendshapeUpdate(2, 0);



            }


       // Vector2 temp = CheckLowerCube();
        //BlendshapeUpdate((int)temp.x, temp.y);

       
    }


       




        
            
	
    void BlendshapeUpdate (int index, float newValue){
        if (skinned != null)
        {
            skinned.SetBlendShapeWeight(index, newValue);
        }

    }
    Vector2 CheckLowerCube () {
        RaycastHit ray;
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out ray, 1))
        {
            if (ray.transform.gameObject.GetComponent<PawnControler>() != null)
            {
                if (ray.transform.gameObject.GetComponent<PawnControler>().master == gameObject)
                {
                    if(Input.GetKey(shift)){
                        return shiftOwnPawn;
                    } else if (Input.GetKey(alt))
                    {
                        return altOwnPawn;
                    }else {
                        return ownPawn;
                    }

                }
                else
                {
                    if (Input.GetKey(shift))
                    {
                        return shiftOtherCube;
                    }
                    else if (Input.GetKey(alt))
                    {
                        return altOtherCube;
                    }
                    else
                    {
                        return otherCube;
                    }

                }
            }
            else
            {
                if (Input.GetKey(shift))
                {
                    return shiftOtherCube;
                }
                else if (Input.GetKey(alt))
                {
                    return altOtherCube;
                }
                else
                {
                    return otherCube;
                }
            }
        }
        else
        {
            if (Input.GetKey(shift))
            {
                return shiftNoCube;
            }
            else if (Input.GetKey(alt))
            {
                return altNoCube;
            }
            else
            {
                return noCube;
            }
        }



    }


}
    

