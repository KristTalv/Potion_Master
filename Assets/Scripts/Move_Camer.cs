using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Move_Camer : MonoBehaviour
{
    // Buttons
    public UI_Buttons uI_Buttons;

    // Destination points
    public GameObject destinationPoint;
    public GameObject startDestinationPoint;

    // Speed
    public float moveSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {     
        if (uI_Buttons.buttonState == true)
        {
            Move_Camera_ToRoom();
        }
        if (uI_Buttons.buttonState == false)
        {
            Move_Camera_Start();
        }
    }

    private void Move_Camera_ToRoom()
    {
        transform.position = Vector3.Lerp(gameObject.transform.position, destinationPoint.transform.position, moveSpeed * Time.deltaTime);
    }

    private void Move_Camera_Start()
    {
        transform.position = Vector3.Lerp(gameObject.transform.position, startDestinationPoint.transform.position, moveSpeed * Time.deltaTime);
    }
}   
