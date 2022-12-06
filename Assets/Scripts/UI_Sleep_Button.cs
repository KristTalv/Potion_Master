using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Sleep_Button : MonoBehaviour
{
    public Button sleep_Button; // Buttons

    public Text number_Of_Days; // Day cauntter
    private int numDay = 0;

    public GameObject wateringCanScript; //Scripts
    public GameObject gardenScript;

    // Start is called before the first frame update
    void Start()
    {

        Button sleepButton = sleep_Button.GetComponent<Button>(); // Next Day
        sleepButton.onClick.AddListener(pleaseSleep);

        Text numberOfDaysText = number_Of_Days.GetComponent<Text>(); // Display the number of days in UI
        numberOfDaysText.text = numDay.ToString();

    }

    void pleaseSleep()
    {

        CalculateWateringScore();

        // Call here the Garden script and needed methods.
        Garden garden = gameObject.GetComponent<Garden>();
        garden = gardenScript.GetComponent<Garden>();

        garden.spawn_Herbs();

        cauntDays(); // Update the number of days in UI.
    }

    public float CalculateWateringScore()
    {
        WateringCan wateringCan = gameObject.GetComponent<WateringCan>();
        wateringCan = wateringCanScript.GetComponent<WateringCan>();

        float wateringScore = wateringCan.totalDistance;
        //sDebug.Log("Watering dis:" + wateringScore);
        return wateringScore;
    }
    // Update the number of days in UI.
    void cauntDays()
    {
        numDay = numDay + 1;
        number_Of_Days.text = numDay.ToString();

    }

}
