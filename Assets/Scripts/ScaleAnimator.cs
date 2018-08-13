using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleAnimator : MonoBehaviour {

    Transform rectTransform;
    [SerializeField]
    bool activeAtStart = false;
    [SerializeField]
    AnimationCurve animationCurve;
    [SerializeField]
    float duration = 1;
    float currenttime = 0;
    public bool forward = true;


    // Use this for initialization
    void Start()
    {
        rectTransform = gameObject.GetComponent<Transform>();
        rectTransform.localScale = Vector3.zero;
        if (!activeAtStart)
        {
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(rectTransform != null)
        {
            currenttime += Time.unscaledDeltaTime;
            if (forward)
            {
                float perc = Mathf.Clamp01(currenttime / duration);
                rectTransform.localScale = Vector3.LerpUnclamped(Vector3.zero, Vector3.one, animationCurve.Evaluate(perc));
            }else
            {
                float perc = 1-Mathf.Clamp01(currenttime / duration);  
                rectTransform.localScale = Vector3.LerpUnclamped(Vector3.zero, Vector3.one, animationCurve.Evaluate(perc));
            }

        }
		
	}
}
