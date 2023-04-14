/*
    DataManager.cs controls the lives counter and score UI
    as well as storing highscore information for the save
    function script.
*/
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    public static int playerLives = 3;
    public static int playerScore = 0;
    public static int playerHighScore = 0;
    public int Lives;
    public int Score;
    public int HighScore;

    // Every frame update lives and score UI elements and
    // store a new highscore value if it is large enough.
    public void Update(){
        Lives = playerLives;
        Score = playerScore;
        HighScore = playerHighScore;
        livesText.text = "Lives: " + Lives; 
        scoreText.text = "Score: " + Score; 

        if (playerScore > playerHighScore){
            playerHighScore = playerScore;
        }
    }

}
