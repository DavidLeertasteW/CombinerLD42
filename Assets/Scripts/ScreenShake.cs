using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {
    [SerializeField]
    float strengthMultiplier = 0.01f;

    public float strength = 0;
    //public int duration = 1;


    // Use this for initialization
    Vector3 initialPos;
	void Start () {
        initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

      
		
	}
    public IEnumerator ShakeThat(){



        for (int i = 0; i < strength+1; i++)
        {
            float tempStrength = strength * strengthMultiplier;

            transform.position = initialPos + new Vector3(Random.Range(-tempStrength,tempStrength),Random.Range(-tempStrength, tempStrength),Random.Range(-tempStrength, tempStrength));
            Debug.Log("ShakingAt:" + strength + " For:" + strength * 0.1f + "Seconds ");
            if(i == strength){
                strength = 0;
                //duration = 0;
                transform.position = initialPos;
            }

            yield return new WaitForSeconds(.1f);
        }


    }
}
