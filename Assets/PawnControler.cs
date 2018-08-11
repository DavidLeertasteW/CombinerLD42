using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnControler : MonoBehaviour
{

    public GameObject master;

    CurserMovement curserControls;

    public int strentgh;
    public int playerNumber;

    TextMesh textM;



    // Use this for initialization
    void Start()
    {
        if (master != null)
        {
            curserControls = master.GetComponent<CurserMovement>();
        }
        textM = transform.GetChild(0).gameObject.GetComponent<TextMesh>();
        textM.text = strentgh.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (master == null)
        {
            return;
        }
        if ((master.transform.position == transform.position) && (Input.GetKey(curserControls.shift)))
        {
            if (Input.GetKeyDown(curserControls.forward))
            {
                Raycast(Vector3.forward);

            }
            if (Input.GetKeyDown(curserControls.backward))
            {
                Raycast(Vector3.back);

            }
            if (Input.GetKeyDown(curserControls.left))
            {
                Raycast(Vector3.left);

            }
            if (Input.GetKeyDown(curserControls.right))
            {
                Raycast(Vector3.right);

            }


        }



    }
	void FixedUpdate()
	{
        if(!Physics.Raycast(transform.position,Vector3.down,1))
        {
            Destroy(gameObject);
        }
	}

	void Raycast(Vector3 direction)
    {
        RaycastHit ray;

        if (Physics.Raycast(transform.position, direction, out ray,1))
        {
            GameObject targetObject = ray.collider.gameObject;

            PawnControler targetPawn = targetObject.GetComponent<PawnControler>();
            if (targetPawn == null){
                return;
            }

            if ((playerNumber == targetPawn.playerNumber) || (targetPawn.playerNumber < 0))
            {
                if (strentgh == targetPawn.strentgh)
                {
                    strentgh += targetPawn.strentgh;
                    textM.text = strentgh.ToString();
                    transform.position = targetObject.transform.position;
                    master.transform.position = transform.position;
                    Destroy(targetObject);
                }
            }
            if (strentgh > targetPawn.strentgh)
            {
                //strentgh += targetPawn.strentgh;
                transform.position = targetObject.transform.position;
                master.transform.position = transform.position;
                Destroy(targetObject);
            }else if (strentgh < targetPawn.strentgh)
            {
                //strentgh += targetPawn.strentgh;
                transform.position = targetObject.transform.position;
                master.transform.position = transform.position;
                Destroy(gameObject);
            }else if (strentgh == targetPawn.strentgh)
            {
                //strentgh += targetPawn.strentgh;
                transform.position = targetObject.transform.position;
                master.transform.position = transform.position;
                Destroy(gameObject);
                Destroy(targetObject);
            }
        }else{
            transform.position += direction;
            master.transform.position = transform.position;

        }



    }


}

