/*
    CollectSpawner.cs controls Where and when Collectible prefabs spawn
*/
using UnityEngine;

public class CollectSpawner : MonoBehaviour
{
    public GameObject collectable;
    public Transform[] collectSpawnPoints;
    private int savedIndex = 0;
    private int randomIndex = 0;
    private float spawnTimer = 2f;
    public static bool hasSpawned = false;

    // Whenever a Collectible prefab is collect by the player
    // spawn another shortly after
    void FixedUpdate(){
        if (spawnTimer <= Time.time){
            if (hasSpawned == false){
                SpawnCollectable();
            }
        }
    }

    // Chooses a random spawnpoint to spawn Collectible prefab,
    // will only spawn a Collectible at a new spawnpoint, 
    // never the same one.
    void SpawnCollectable(){
        if(randomIndex != savedIndex){
            savedIndex = randomIndex;
            Transform collectSpawnPoint = collectSpawnPoints[randomIndex];
            Instantiate(collectable, new Vector3(collectSpawnPoint.position.x, collectSpawnPoint.position.y + 26f, collectSpawnPoint.position.z), collectSpawnPoint.rotation);
            hasSpawned = true;
        }
        else{
            randomIndex = Random.Range(0, collectSpawnPoints.Length);
        }

    }
}
