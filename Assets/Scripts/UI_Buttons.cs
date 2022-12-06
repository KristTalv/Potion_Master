using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Buttons : MonoBehaviour
{
    public Button nextRoom_Button; // Buttons

    public bool buttonState = false; // Camera movement works with boolean. 

    // Start is called before the first frame update
    void Start()
    {

        Button nextButton = nextRoom_Button.GetComponent<Button>(); // Next Room
        nextButton.onClick.AddListener(pleaseMoveCamera);
      
        
    }


    void pleaseMoveCamera()
    {
        if (buttonState == false)
        {
            buttonState = true;
        }
        else
        {
            buttonState = false;

        }


    }


}
