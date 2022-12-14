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

    public GameObject weed_Prefab; // Weed
    private Array testArrayWeed;
    private int weedCaunt = 0;

    private float wateringPlantsScore = 0; // Watering the plants

    public UI_Sleep_Button sleepButtonScript; // Sleep button script

    public int manxRandom = 10; // Spawn random location
    public int minRandom = -10;
    private int randomX;

    private List<GameObject> herbListG = new List<GameObject>(5); // Herb list

    // Start is called before the first frame update
    void Start()
    {
        createHerbList();
        spawn_Herbs();   
    }

    private void createHerbList()
    {
        herbListG.Add(herbA);
        herbListG.Add(herbB);
        herbListG.Add(weed_Prefab);
    }

    public void spawn_Herbs()
    {
        countWeeds();
        SetWateringScore();
   
        if (weedCaunt > 2)
        {
            herbListG.Add(weed_Prefab);
        }
        if (wateringPlantsScore > 10 && !herbListG.Contains(herbC) && weedCaunt < 1)
        {
            herbListG.Add(herbC); 
        }
        if (wateringPlantsScore > 20 && !herbListG.Contains(herbD) && weedCaunt < 1)
        {
            herbListG.Add(herbD);
        }
        if (wateringPlantsScore > 30 && !herbListG.Contains(herbE) && weedCaunt < 1)
        {
            herbListG.Add(herbE);
        }

        foreach (GameObject @object in herbListG)
        {
            randomX = Random.Range(minRandom, manxRandom);
            Instantiate(@object, new Vector3(randomX, 0.5f, 0), @object.transform.rotation);
        }
    }

    private int countWeeds()
    {
        testArrayWeed = GameObject.FindGameObjectsWithTag("Weed");
        weedCaunt = testArrayWeed.Length;
        return weedCaunt;       
    }

    public void SetWateringScore()
    {
        wateringPlantsScore = sleepButtonScript.CalculateWateringScore();
    }
}
