using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControler : MonoBehaviour {

    [SerializeField]
    KeyCode forward, backward, left, right;
    [SerializeField]
    Transform enemyTrans;

    CharacterControler enemyChar;
    Material ownMat;

    public int strength = 1;

	// Use this for initialization
	void Start () {

        enemyChar = enemyTrans.gameObject.GetComponent<CharacterControler>();
        ownMat = GetComponent<MeshRenderer>().sharedMaterial;
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(forward)){
            CheckUnderlyingTile();
            transform.position = transform.position + Vector3.forward;


        }
        if (Input.GetKeyDown(backward))
        {

            CheckUnderlyingTile();
            transform.position = transform.position + (Vector3.forward * -1);



        }
        if (Input.GetKeyDown(left))
        {
            CheckUnderlyingTile();
            transform.position = transform.position + Vector3.left;



        }
        if (Input.GetKeyDown(right))
        {
            CheckUnderlyingTile();
            transform.position = transform.position + Vector3.right;



        }
        if (transform.position == enemyTrans.position)
        {
            if (strength > enemyChar.strength){
                Debug.Log(this.gameObject.name + "winner");
            }else if (strength < enemyChar.strength)
            {
                this.enabled = false;
                Debug.Log(this.gameObject.name + "looser");
            }

        }

		
	}

    void CheckUnderlyingTile () {
        RaycastHit hit;

       
        
        if (Physics.Raycast(transform.position,Vector3.down,out hit)){
            

            Material m = hit.transform.gameObject.GetComponent<MeshRenderer>().material;
           // BoxCollider mc = hit.transform.gameObject.GetComponent<BoxCollider>();
            if(m.color != Color.grey){
                Debug.Log("notown");
                m.color = Color.grey;
               // mc.enabled = false;
                strength++;
            }else if (m.color == Color.grey)
           {
                Debug.Log("own");

                strength--;
            }






        }else {
            Debug.Log("Empty");
        }




    }


}
