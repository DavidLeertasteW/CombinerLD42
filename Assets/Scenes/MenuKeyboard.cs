using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuKeyboard : MonoBehaviour
{

    [SerializeField]
    KeyCode left, right, up, down, enter;

    [SerializeField]
    Button leftB, rightB, upB, downB;

    Button activeButton;

    // Use this for initialization
    void Start()
    {
        activeButton = rightB;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(enter))
        {
            activeButton.onClick.Invoke();
        }
        if (Input.GetKey(left))
            {

            UpdateActiveButton(leftB);
            }
        

        if (Input.GetKey(right))
        {

            UpdateActiveButton(rightB);
        }
        if (Input.GetKey(up))
        {

            UpdateActiveButton(upB);
        }
        if (Input.GetKey(down))
        {

            UpdateActiveButton(downB);
        }

        ButtonColorUpdater(leftB);
        ButtonColorUpdater(rightB);
        ButtonColorUpdater(upB);
        ButtonColorUpdater(downB);
        activeButton.image.color = Color.gray;



    }
    void ButtonColorUpdater(Button button)
    {
        if (button != null){
            button.image.color = Color.white;
        }
    }
    void UpdateActiveButton (Button sourceButton){
        if ((sourceButton != null)&&(sourceButton.isActiveAndEnabled))
        {
            
            activeButton = sourceButton;
        }
    }

}
