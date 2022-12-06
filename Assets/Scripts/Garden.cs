using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Garden : MonoBehaviour
{
    // In this script: herbs get spawnd in the Garden. There is two lists. Spawn points and herbs.

    public GameObject herbA; // Herbs
    public GameObject herbB;
    public GameObject herbC;
    public GameObject herbD;
    public GameObject herbE;


    public GameObject g_spawn_weed;
    private GameObject weed;

    private float wateringPlantsScore = 0; // watering the plants

    public UI_Sleep_Button sleepButtonScript; // Sleep button script

    public int manxRandom = 10; // Spawn random location
    public int minRandom = -10;
    private int randomX;

    //private bool spawn_point_Free = true; // New Herbs should spawn only if conditions are true

    private List<GameObject> g_spawnHerbs = new List<GameObject>(5); // herbs

    private List<GameObject> weedCaunter = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        
        g_spawnHerbs.Add(herbA);
        g_spawnHerbs.Add(herbB);
        g_spawnHerbs.Add(g_spawn_weed);
        //g_spawnHerbs.Add(g_spawn_weed);
        //g_spawnHerbs.Add(g_spawn_weed);
        //g_spawnHerbs.Add(herbD);
        //g_spawnHerbs.Add(herbE);

        spawn_Herbs();
       
    }
    
    
    public void spawn_Herbs()
    {
        

        SetWateringScore();

        if (weedCaunter.Count > 5)
        {
            g_spawnHerbs.Clear();
        }
        if (wateringPlantsScore > 30 && !g_spawnHerbs.Contains(herbD))
        {
            g_spawnHerbs.Add(herbD); 
        }
        if (wateringPlantsScore > 50 && !g_spawnHerbs.Contains(herbE))
        {
            g_spawnHerbs.Add(herbE);
        }

        foreach(GameObject @object in g_spawnHerbs)
        {
            randomX = Random.Range(minRandom, manxRandom);
            Instantiate(@object, new Vector3(randomX, 0.5f, 0), gameObject.transform.rotation);

        }

        weed = GameObject.FindWithTag("Weed");
        weedCaunter.Add(weed);

    }


    public void SetWateringScore()
    {
        wateringPlantsScore = sleepButtonScript.CalculateWateringScore();
    }


}
