using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Craft : MonoBehaviour
{  
    
    // VFX
    public ParticleSystem failParticle;
    public ParticleSystem winParticle;

    // Provaid combonents for crafting
    public GameObject craftComponentA;
    public GameObject craftComponentB;
    public GameObject craftComponentC;
    public GameObject craftComponentD;
    public GameObject craftComponentE;

    private List<string> craftComponentList = new List<string>(5);

    // Potion prefabs
    public GameObject potion_1;
    public GameObject potion_2;
    public GameObject potion_3;
    public GameObject potion_4;

    //Potion spawnpont
    public GameObject spawnPoint_Potion;

    //Audio
    public AudioSource splashAudio;
    public AudioSource failAudio;
    public AudioSource sucsessAudio;


    // The next method is for when a component goes in the pot.
    private void OnTriggerEnter(Component other) 
    {
        splashAudio.Play();

        craftComponentList.Add(other.transform.name); // Update the craftList so kombinations are possible.
        
        produsePotion();
        GameObject.Destroy(other.transform.gameObject);

        foreach (var index in craftComponentList)
        {
            Debug.Log("Start:");
            Debug.Log("craftList has: " + index );
            Debug.Log("List lenght is: " + craftComponentList.Count);
            Debug.Log("End.");
        }

    }
    
    // After components go in the pot, this method will be called. This metohd
    // will see what objects are in the pot and instansiate a correct potion.
    private void produsePotion()
    {




        if (craftComponentList.Contains(craftComponentA.name + "(Clone)(Clone)"))
        {
            if ( craftComponentList.Contains(craftComponentB.name + "(Clone)(Clone)") && craftComponentList.Count == 2)
            {
                winParticle.Play();
                sucsessAudio.Play();
                Debug.Log("Potion!!");
                GameObject.Instantiate(potion_1, spawnPoint_Potion.transform.position, spawnPoint_Potion.transform.rotation);
            }
            
        }
        if (craftComponentList.Contains(craftComponentB.name + "(Clone)(Clone)"))
        {
            if (craftComponentList.Contains(craftComponentC.name + "(Clone)(Clone)") && craftComponentList.Count == 2)
            {
                winParticle.Play();
                sucsessAudio.Play();
                Debug.Log("Potion!!");
                GameObject.Instantiate(potion_2, spawnPoint_Potion.transform.position, spawnPoint_Potion.transform.rotation);
            }

        }

        if (craftComponentList.Contains(craftComponentD.name + "(Clone)(Clone)"))
        {
            if (craftComponentList.Contains(craftComponentE.name + "(Clone)(Clone)") && craftComponentList.Count == 2)
            {
                winParticle.Play();
                sucsessAudio.Play();
                Debug.Log("Potion!!" + craftComponentList.Count);
                GameObject.Instantiate(potion_1, spawnPoint_Potion.transform.position, spawnPoint_Potion.transform.rotation);
            }
        
        }
        if (craftComponentList.Contains(craftComponentC.name + "(Clone)(Clone)"))
        {
            if (craftComponentList.Contains(craftComponentA.name + "(Clone)(Clone)") && craftComponentList.Count == 2)
            {
                winParticle.Play();
                sucsessAudio.Play();
                Debug.Log("Potion!!" + craftComponentList.Count);
                GameObject.Instantiate(potion_3, spawnPoint_Potion.transform.position, spawnPoint_Potion.transform.rotation);
            }
        
        }
        if (craftComponentList.Contains(craftComponentE.name + "(Clone)(Clone)"))
        {
            if (craftComponentList.Contains(craftComponentA.name + "(Clone)(Clone)") && craftComponentList.Count == 2)
            {
                winParticle.Play();
                sucsessAudio.Play();
                Debug.Log("Potion!!" + craftComponentList.Count);
                GameObject.Instantiate(potion_4, spawnPoint_Potion.transform.position, spawnPoint_Potion.transform.rotation);
            }
        
        }
        if (craftComponentList.Count >= 3)
        {
            failAudio.Play();
            failParticle.Play();
            Debug.Log("Potion failed. Explosion and nasty smell!");
            craftComponentList.Clear();
        }
         

    }

    
}
