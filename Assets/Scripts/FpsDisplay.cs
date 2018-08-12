using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FpsDisplay : MonoBehaviour {

    Text uiText;
    int counter = 0, steps = 5;
    float currentMeassure = 0;

	// Use this for initialization
	void Start () {
        uiText = GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
        counter++;
        currentMeassure += Time.unscaledDeltaTime;

        if (counter >= steps)
        {
            
            currentMeassure = 1 / (currentMeassure/counter);
            float fps = (float)(Mathf.RoundToInt(currentMeassure * 100)) / 100;
            uiText.text = fps.ToString();
            counter = 0;
            currentMeassure = 0;





        }


	}
}
