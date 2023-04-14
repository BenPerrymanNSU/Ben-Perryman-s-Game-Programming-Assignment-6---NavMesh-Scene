/*
    ButtonScript.cs controls the button UI elements in the pause
    and game over overlays
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Try Again button will reset lives, score, and highscore
    // restarts current scene
    public void ScreenRestart(){
        DataManager.playerScore = 0;
        DataManager.playerLives = 3;
        DataManager.playerHighScore = 0;
        SceneManager.LoadScene(0);
    }

    // Closes the unity play window
    public void QuitGame(){
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
