using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnControler : MonoBehaviour
{
    [System.Serializable]
    class MovementPatternParameters 
    {
        
        public Vector3Int direction;

        public int steps = 1;

        public float stepsPerSecond = 2;
    }

    public GameObject master;

    CurserMovement curserControls;

    public int strentgh;
    public int playerNumber;

    TextMesh textM;

    [SerializeField]
    MovementPatternParameters[] movements;

    int patternIndex = 0;
    int patternStepIndex = 0;
    float patternTimeCount = 0;

    // Use this for initialization
    void Start()
    {
        if (master != null)
        {
            curserControls = master.GetComponent<CurserMovement>();
        }
        //need to output the pawn's strength
        textM = transform.GetChild(0).gameObject.GetComponent<TextMesh>();
        textM.text = strentgh.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        //when the pawn has no master, it is percieved as neutral and strats using nutral movement patterns
        if (master == null)
        {
            if (movements.Length > 0)
            {
                NeutralMovementPattern();
            }
            return;
        }
        //if not, it is reacting to player input
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
            //neutral pawns have a player number below zero, and are also adding to your count
            if ((playerNumber == targetPawn.playerNumber) || (targetPawn.playerNumber < 0))
            {
                //but only if they have the same strength
                if (strentgh == targetPawn.strentgh)
                {
                    strentgh += targetPawn.strentgh;
                    textM.text = strentgh.ToString();
                    transform.position = targetObject.transform.position;
                    if (master != null)
                    {
                        master.transform.position = transform.position;
                    }
                    Destroy(targetObject);
                }
            }
            if (strentgh > targetPawn.strentgh)
            {
                //strentgh += targetPawn.strentgh;
                transform.position = targetObject.transform.position;
                if (master != null)
                {
                    master.transform.position = transform.position;
                }
                Destroy(targetObject);
            }else if (strentgh < targetPawn.strentgh)
            {
                //strentgh += targetPawn.strentgh;
                transform.position = targetObject.transform.position;
                if (master != null)
                {
                    master.transform.position = transform.position;
                }
                Destroy(gameObject);
            }else if (strentgh == targetPawn.strentgh)
            {
                //strentgh += targetPawn.strentgh;
                transform.position = targetObject.transform.position;
                if (master != null)
                {
                    master.transform.position = transform.position;
                }
                Destroy(gameObject);
                Destroy(targetObject);
            }
        }else{
            transform.position += direction;
            if (master != null)
            {
                master.transform.position = transform.position;
            }

        }



    }
    void NeutralMovementPattern () 
    {
        

        patternTimeCount += Time.deltaTime;
        if (1/movements[patternIndex].stepsPerSecond <= patternTimeCount){
            patternTimeCount = 0;
            Raycast(movements[patternIndex].direction);
            patternStepIndex++;
            if(patternStepIndex == movements[patternIndex].steps){
                patternStepIndex = 0;
                patternIndex ++;
                if(patternIndex == movements.Length){
                    patternIndex = 0;
                }

            }
        }



    }


}

