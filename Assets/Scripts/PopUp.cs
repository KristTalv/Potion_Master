using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PopUp : MonoBehaviour
{
    public GameObject victoryPopup; // The pop up GameObject

    // Buttons
    public Button quittButton;
    public Button replayButton;

    private IEnumerator givePopup; // corutine. So that player can see the last potion before the pop up.

    public void Start()
    {
        quittButton.onClick.AddListener(quitGame);
        replayButton.onClick.AddListener(startGame);
    }
    public void startGame()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
    public void quitGame()
    {
        Application.Quit();
    }
    public void popUpVictory()
    {
        givePopup = WaitAndPop(2.5f);
        StartCoroutine(givePopup);
        
    }
    private IEnumerator WaitAndPop(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        victoryPopup.SetActive(true);

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
