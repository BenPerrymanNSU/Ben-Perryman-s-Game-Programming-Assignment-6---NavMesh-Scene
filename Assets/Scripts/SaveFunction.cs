/*
    SaveFunction.cs controls saving score information to the
    included text file and retreiving score information from 
    the text file to display in the scoreboard seen at the end
    of the game.
*/

using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEditor;

public class SaveFunction : MonoBehaviour
{
    public Text ScoreList;
    private string filePath  = "Assets/SavedHighScores.txt";
    public int NumScores = 10;
    public bool hasWritten = false;
    public bool hasDisplayed = false;

    // On start of scene set bool functions to false to allow
    // for future high score writing and displaying.
    void start(){
        hasWritten = false;
        hasDisplayed = false;
    }

    // Every frame check if the GameOver bool has been set to true
    // if write and display bools have not been set to true then
    // call both write and display functions.
    void Update(){
        if (PlayerRespawn.GameOver == true && hasWritten == false && hasDisplayed == false){
            Invoke("WriteScores", 0.000001f);
            hasWritten = true;
            Invoke("DisplayScores", 0.000001f);
            hasDisplayed = true;
        }
    }

    // Reades information stored in the included text file and
    // displays each line in the Text UI object.
    void DisplayScores(){
        string Dline;
        string[] Dfields;
        int DisplayScores = 0;
        ScoreList.text = "";

        StreamReader reader = new StreamReader(filePath);
        while(!reader.EndOfStream && DisplayScores < NumScores){
            Dline = reader.ReadLine();
            Dfields = Dline.Split('/');
            ScoreList.text += Dfields[0] + " / " + Dfields[1] + "\n";
            DisplayScores += 1;
        }
        reader.Close();
    }

    // Retrieves players score information and text file score information
    // if player's highscore is larger than an entry in the list then
    // it will re-write information in the text file to include new score
    // information, smallest score is always removed.
    void WriteScores(){
        string Wline;
        string[] Wfields;
        int writtenScores = 0;
        string newPlayerName = "You";
        string newPlayerScore = DataManager.playerHighScore.ToString();
        string[] namesToWrite = new string[10];
        string[] scoresToWrite = new string[10];
        bool newScoreToWrite = false;

        if (DataManager.playerLives == 0){
            StreamReader reader = new StreamReader(filePath);
            while (!reader.EndOfStream){
                Wline = reader.ReadLine();
                Wfields = Wline.Split('/');
                if (!newScoreToWrite && writtenScores < NumScores){
                    if (Convert.ToInt32(newPlayerScore) > Convert.ToInt32(Wfields[1])){
                        namesToWrite[writtenScores] = newPlayerName;
                        scoresToWrite[writtenScores] = newPlayerScore;
                        newScoreToWrite = true;
                        writtenScores += 1;
                    }
                }
                if (writtenScores < NumScores){
                    namesToWrite[writtenScores] = Wfields[0];
                    scoresToWrite[writtenScores] = Wfields[1];
                    writtenScores += 1;
                }
            }
            reader.Close();
            StreamWriter writer = new StreamWriter(filePath);
            for (int i = 0; i < writtenScores; i++){
                writer.WriteLine(namesToWrite[i] + '/' + scoresToWrite[i]);
            }
            writer.Close();
            AssetDatabase.ImportAsset(filePath);
            TextAsset asset = (TextAsset)Resources.Load("Scores");
        }
    }

    /*

    Template for filling high scores text document:

    Guy / 25
    Marge / 20
    Bob / 18
    Harry / 16
    Larry / 14
    Karry / 13
    David / 12
    Will / 10
    John / 8
    Jeb / 5
    
    */
}
