using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    private GameObject wateringObject;

    private bool boolean_pooringWater = false;

    public ParticleSystem pourWaterParticle;

    public float totalDistance = 0;
    public float startPointWC;
    public bool record = false;
    private Vector3 previousLoc;



    // Start is called before the first frame update
    void Start()
    {
        record = false;
        startPointWC += Vector3.Distance(transform.position, previousLoc);

    }

    // Update is called once per frame
    void Update()
    {
        if (record == true)
        {
            RecordDistance();
        }
        Watering();


    }

    private void RecordDistance()
    {
        totalDistance += Vector3.Distance(transform.position, previousLoc);
        previousLoc = transform.position;

    }
    private void Watering()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1) && boolean_pooringWater == false)
        {
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 45;
            transform.rotation = Quaternion.Euler(rotationVector);


            record = true;
            boolean_pooringWater = true;
            pourWaterParticle.Play();


        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && boolean_pooringWater == true)
        {
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 0;
            transform.rotation = Quaternion.Euler(rotationVector);


            boolean_pooringWater = false;
            record = false;
            pourWaterParticle.Stop();;

        }

    }
}
