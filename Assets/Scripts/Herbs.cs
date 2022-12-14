using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herbs : MonoBehaviour
{
    //In this scrit: makes herbs collectable,
    //destroid, instanssiated to CRAFT ROOM and change tag from "Herb" to "Craft".


    public GameObject spawnPoint_A; // Will get the position where instansiate the herb in CRAFT ROOM
    public GameObject spawnPoint_B;
    public GameObject spawnPoint_C;

    private GameObject herbClone; // This is used for resinging tag to game object. This is important for
                                  // crafting. Herb needs to change tag to "Craft".  

    public GameObject herb_A; // Update herbs here
    public GameObject herb_B;
    public GameObject herb_C;
    public GameObject herb_D;
    public GameObject herb_E;

    public AudioSource pickUpSound; // SFX
    public AudioSource weedPickUp; 



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                if (hit.transform.tag == "Herb") 
                {
                    pickUpSound.Play(); //SFX

                    //  Chekcs what tag and saves name to herb_name,
                    //  then instansiate it to craft room,
                    //  then change the tag form "Herb" to "Craft"
                    //  and finally destroy object
                    if(hit.transform.gameObject.name == herb_A.name || hit.transform.gameObject.name == herb_A.name +  "(Clone)")
                    {
                        herbClone = GameObject.Instantiate(hit.transform.gameObject, spawnPoint_A.transform.position, hit.transform.rotation);
                        herbClone.tag = "Craft";
                        Destroy(hit.transform.gameObject);
                    }
                    else if (hit.transform.gameObject.name == herb_B.name || hit.transform.gameObject.name == herb_B.name + "(Clone)")
                    {                      
                        herbClone = GameObject.Instantiate(hit.transform.gameObject, spawnPoint_B.transform.position, hit.transform.rotation);
                        herbClone.tag = "Craft";
                        Destroy(hit.transform.gameObject);
                    }
                    else if (hit.transform.gameObject.name == herb_C.name || hit.transform.gameObject.name == herb_C.name + "(Clone)")
                    {                       
                        herbClone = GameObject.Instantiate(hit.transform.gameObject, spawnPoint_C.transform.position, hit.transform.rotation);
                        herbClone.tag = "Craft";
                        Destroy(hit.transform.gameObject);
                    }
                    else if (hit.transform.gameObject.name == herb_D.name || hit.transform.gameObject.name == herb_D.name + "(Clone)")
                    {                      
                        herbClone = GameObject.Instantiate(hit.transform.gameObject, spawnPoint_C.transform.position, hit.transform.rotation);
                        herbClone.tag = "Craft";
                        Destroy(hit.transform.gameObject);
                    }
                    else if (hit.transform.gameObject.name == herb_E.name || hit.transform.gameObject.name == herb_E.name + "(Clone)")
                    {                       
                        herbClone = GameObject.Instantiate(hit.transform.gameObject, spawnPoint_C.transform.position, hit.transform.rotation);
                        herbClone.tag = "Craft";
                        Destroy(hit.transform.gameObject);
                    }

                }
                if (hit.transform.tag == "Weed")
                {
                    weedPickUp.Play();
                    Destroy(hit.transform.gameObject);
                }

            }

        }

    }


}
