/*
    PlayerRespawn.cs controls the players ability to respawn
    after being killed by a killer as well as the game over
    overlay
*/
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject player;
    public Camera MainCamera;
    public Animator animator;
    public static bool playerIsDead = false;
    public static bool GameOver = false;
    private float respawnDelay = 2.5f;

    public Text GameOverText;
    public Image DarkenBack;
    public Image DarkenBack2;
    public Image DarkenBack3;
    public Text HighScoresText;
    public Text HighScoresList;
    public Button RestartButton;
    public Button QuitButton;
    public Text LivesCounter;
    public Text ScoreCounter;
    public Image LivesBack;
    public Image ScoreBack;

    // On start of scene reset bools, reactivates
    // player input and hitbox, finally ensure that
    // game over UI elements are hidden
    void Start(){
        playerIsDead = false;
        GameOver = false;
        CollectSpawner.hasSpawned = false;
        EnemySpawner.hasSpawned = false;
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<CapsuleCollider>().enabled = true;
        MainCamera.GetComponent<PauseFunction>().enabled = true;
        DarkenBack3.gameObject.SetActive(false);
        HighScoresText.gameObject.SetActive(false);
        HighScoresList.gameObject.SetActive(false);
        GameOverText.gameObject.SetActive(false);
    }

    // When the player hitbox collides with the killers kill
    // hitbox play a noise, play death animation, 
    // disable player input and hitbox. Resets score and subtracts 
    // a life, calls respawn function.
    void OnTriggerEnter(Collider col){
        if (col.tag == "Kill"){
            if (DataManager.playerLives > 0){
                DataManager.playerLives--;
            }
        playerIsDead = true;
        animator.Play("Base Layer.Dead", 0, 0);
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        DataManager.playerScore = 0;
        player.GetComponent<CapsuleCollider>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<CapsuleCollider>().enabled = false;
        MainCamera.GetComponent<PauseFunction>().enabled = false;
            Invoke("Respawn", respawnDelay);
        }
    }

    // Restart scene if the player still has lives to lose,
    // otherwise activate game over overlay, stop time, and
    // disable player input/hitbox
    void Respawn(){
        if (DataManager.playerLives > 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else{
            GameOver = true;
            Time.timeScale = 0;
            player.GetComponent<CapsuleCollider>().enabled = false;
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<CapsuleCollider>().enabled = false;
            MainCamera.GetComponent<PauseFunction>().enabled = false;
            GameOverText.gameObject.SetActive(true);
            DarkenBack.gameObject.SetActive(true);
            DarkenBack2.gameObject.SetActive(true);
            DarkenBack3.gameObject.SetActive(true);
            HighScoresText.gameObject.SetActive(true);
            HighScoresList.gameObject.SetActive(true);
            RestartButton.gameObject.SetActive(true);
            QuitButton.gameObject.SetActive(true);
            LivesCounter.gameObject.SetActive(false);
            ScoreCounter.gameObject.SetActive(false);
            LivesBack.gameObject.SetActive(false);
            ScoreBack.gameObject.SetActive(false);

        }
    }
}
