using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Craft : MonoBehaviour
{
    // UI 
    public Text text_numOfPotions;
    private int numOfPotions = 0;
    public PopUp popUp;             // Pop up script.
    
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
    private List<string> potionList = new List<string>();

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

    private void Start()
    {
        text_numOfPotions.text = numOfPotions.ToString();
    }

    // The next method is for when a component goes in the pot.
    private void OnTriggerEnter(Component other) 
    {
        splashAudio.Play();
        craftComponentList.Add(other.transform.name); // Update the craftList so kombinations are possible.     
        produsePotion();                             
        GameObject.Destroy(other.transform.gameObject);
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
                GameObject.Instantiate(potion_1, spawnPoint_Potion.transform.position, spawnPoint_Potion.transform.rotation);
                if(potionList.Contains(potion_1.name) == false)
                {
                    potionList.Add(potion_1.name);
                    numOfPotions++;
                    text_numOfPotions.text = numOfPotions.ToString();
                }
                craftComponentList.Clear();
            }      
        }
        if (craftComponentList.Contains(craftComponentB.name + "(Clone)(Clone)"))
        {
            if (craftComponentList.Contains(craftComponentC.name + "(Clone)(Clone)") && craftComponentList.Count == 2)
            {
                winParticle.Play();
                sucsessAudio.Play();
                GameObject.Instantiate(potion_2, spawnPoint_Potion.transform.position, spawnPoint_Potion.transform.rotation);
                if (potionList.Contains(potion_2.name) == false)
                {
                    potionList.Add(potion_2.name);
                    numOfPotions++;
                    text_numOfPotions.text = numOfPotions.ToString();
                }
                craftComponentList.Clear();
            }
        }

        if (craftComponentList.Contains(craftComponentD.name + "(Clone)(Clone)"))
        {
            if (craftComponentList.Contains(craftComponentE.name + "(Clone)(Clone)") && craftComponentList.Count == 2)
            {
                winParticle.Play();
                sucsessAudio.Play();
                GameObject.Instantiate(potion_3, spawnPoint_Potion.transform.position, spawnPoint_Potion.transform.rotation);
                if (potionList.Contains(potion_3.name) == false)
                {
                    potionList.Add(potion_3.name);
                    numOfPotions++;
                    text_numOfPotions.text = numOfPotions.ToString();
                }
                craftComponentList.Clear();
            }        
        }
        if (craftComponentList.Contains(craftComponentC.name + "(Clone)(Clone)"))
        {
            if (craftComponentList.Contains(craftComponentE.name + "(Clone)(Clone)") && craftComponentList.Count == 2)
            {
                winParticle.Play();
                sucsessAudio.Play();
                GameObject.Instantiate(potion_3, spawnPoint_Potion.transform.position, spawnPoint_Potion.transform.rotation);
                if (potionList.Contains(potion_3.name) == false)
                {
                    potionList.Add(potion_3.name);
                    numOfPotions++;
                    text_numOfPotions.text = numOfPotions.ToString();
                }
                craftComponentList.Clear();
            }        
        }
        if (craftComponentList.Contains(craftComponentE.name + "(Clone)(Clone)"))
        {
            if (craftComponentList.Contains(craftComponentA.name + "(Clone)(Clone)") && craftComponentList.Count == 2)
            {
                winParticle.Play();
                sucsessAudio.Play();
                GameObject.Instantiate(potion_4, spawnPoint_Potion.transform.position, spawnPoint_Potion.transform.rotation);
                if (potionList.Contains(potion_4.name) == false)
                {
                    potionList.Add(potion_4.name);
                    numOfPotions++;
                    text_numOfPotions.text = numOfPotions.ToString();
                }
                craftComponentList.Clear();
            }
        }
        if (craftComponentList.Count >= 2)
        {
            failAudio.Play();
            failParticle.Play();
            craftComponentList.Clear();
        }
        if (numOfPotions == 4)
        {
            popUp.popUpVictory();
        }

    }

}
