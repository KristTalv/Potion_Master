using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    private GameObject wateringObject; // wateringcan object

    private bool boolean_pooringWater = false;

    public ParticleSystem pourWaterParticle; // Vfx
    public ParticleSystem idleWaterParticle;
    public AudioSource soundWatering; // Sfx

    public float totalDistance = 0; // Waterin score
    public float startPointWC;
    public bool record = false;
    private Vector3 previousLoc;

    public GameObject respawnPoint;
    private float reSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        record = false;
        startPointWC += Vector3.Distance(transform.position, previousLoc);
        idleWaterParticle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (record == true)
        {
            RecordDistance();
        }
        if(transform.position.y < -0.6)
        {
            transform.position = Vector3.Lerp(gameObject.transform.position, respawnPoint.transform.position, reSpeed * Time.deltaTime);
        }

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
            idleWaterParticle.Stop();
            pourWaterParticle.Play();
            soundWatering.Play();

        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && boolean_pooringWater == true)
        {
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 0;
            transform.rotation = Quaternion.Euler(rotationVector);

            boolean_pooringWater = false;
            record = false;
            pourWaterParticle.Stop();
            soundWatering.Stop();
            idleWaterParticle.Play();
        }

    }
    void OnMouseDrag()
    {
        Watering();
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));

    }

}
