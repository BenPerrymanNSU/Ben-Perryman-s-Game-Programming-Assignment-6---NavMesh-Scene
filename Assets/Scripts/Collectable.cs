/*
    Collectable.cs controls player collision with the
    Collectable prefab box collider trigger
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject collectable;
    public GameObject collectablePole;

    // On collision with the player update score,
    // play audio, destroy prefab object, and signal
    // to the collectible spawner to spawn another
    void OnTriggerEnter(Collider col){
        if (col.tag == "Player"){
            DataManager.playerScore++;
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            Destroy(collectable);
            Destroy(collectablePole);
            CollectSpawner.hasSpawned = false;
        }
    }
}
