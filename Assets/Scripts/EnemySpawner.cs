/*
    EnemySpawner.cs Controls where and how many killer prefabs should spawn
*/
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Killer;
    public Transform[] KillerSpawnPoints;
    private int savedIndex = 0;
    private int savedIndex2 = 0;
    private int randomIndex = 0;
    private int maxEnemies = 3;
    private float spawnTimer = 0f;
    public static bool hasSpawned = false;

    // Every frame check if Killers should be spawned,
    // will spawn if there is less than maxEnemies
    void Update(){
        if (spawnTimer <= Time.time){
            if (hasSpawned == false){
                SpawnKillers();
            }
        }
    }

    // Chooses random spawnpoints to spawn killer prefabs,
    // saves previous chosen spawnpoint to make sure multiple
    // prefabs do not spawn at the same spawnpoint.
    // once i = 3, sets bool to true.
    void SpawnKillers(){
        for (int i = 0; i < maxEnemies;){
            randomIndex = Random.Range(0, KillerSpawnPoints.Length);
            if(randomIndex != savedIndex && randomIndex != savedIndex2){
                if (i == 0){
                    savedIndex = randomIndex;
                }
                if (i == 1){
                    savedIndex2 = randomIndex;
                }
                Transform KillerSpawnPoint = KillerSpawnPoints[randomIndex];
                Instantiate(Killer, new Vector3(KillerSpawnPoint.position.x, KillerSpawnPoint.position.y, KillerSpawnPoint.position.z), KillerSpawnPoint.rotation);
                i++;
            }
        }
        hasSpawned = true;
    }
}