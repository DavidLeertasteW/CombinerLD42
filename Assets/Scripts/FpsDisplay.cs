using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FpsDisplay : MonoBehaviour {

    Text uiText;
    int counter = 0, steps = 10;
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

            if ((fps < 25) && (QualitySettings.GetQualityLevel() != 0)){
                QualitySettings.SetQualityLevel(0);
            }else if((fps >50) && (QualitySettings.GetQualityLevel() != 1)) {

                QualitySettings.SetQualityLevel(1);
            }





        }


	}
}
