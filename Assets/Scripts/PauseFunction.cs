/*
    PauseFunction.cs controls the players ability to pause the game and access the pause menu
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseFunction : MonoBehaviour
{
    public GameObject player;
    public Text PauseText;
    public Image DarkenBack;
    public Image DarkenBack2;
    public Button RestartButton;
    public Button QuitButton;
    public Text LivesCounter;
    public Text ScoreCounter;
    public Image LivesBack;
    public Image ScoreBack;
    private bool Paused = false;

    // On start of scene set time to normal, re-enable player movement input,
    // and disable pause menu UI elements
    void Start(){
        Time.timeScale = 1;
        player.GetComponent<PlayerController>().enabled = true;
        PauseText.gameObject.SetActive(false);
        DarkenBack.gameObject.SetActive(false);
        DarkenBack2.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);
        LivesCounter.gameObject.SetActive(true);
        ScoreCounter.gameObject.SetActive(true);
        LivesBack.gameObject.SetActive(true);
        ScoreBack.gameObject.SetActive(true);
    }

    // Every frame check for player input for the ESC key
    // if pressed then either pause or unpause the game
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Stops time, disables player movement input, activate
    // pause menu UI elements, updates bool
    void PauseGame(){
        Time.timeScale = 0;
        player.GetComponent<PlayerController>().enabled = false;
        PauseText.gameObject.SetActive(true);
        DarkenBack.gameObject.SetActive(true);
        DarkenBack2.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        QuitButton.gameObject.SetActive(true);
        LivesCounter.gameObject.SetActive(false);
        ScoreCounter.gameObject.SetActive(false);
        LivesBack.gameObject.SetActive(false);
        ScoreBack.gameObject.SetActive(false);

        Paused = true;
    }

    // Sets time back to normal, re-enables player movement input,
    // disables all pause menu UI elements, updates bool
    public void ResumeGame(){
        Time.timeScale = 1;
        player.GetComponent<PlayerController>().enabled = true;
        PauseText.gameObject.SetActive(false);
        DarkenBack.gameObject.SetActive(false);
        DarkenBack2.gameObject.SetActive(false);
        RestartButton.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);
        LivesCounter.gameObject.SetActive(true);
        ScoreCounter.gameObject.SetActive(true);
        LivesBack.gameObject.SetActive(true);
        ScoreBack.gameObject.SetActive(true);

        Paused = false;
    }
}
