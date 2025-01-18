using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    [SerializeField]
    List<TrashSpawner> trashSpawners;

    [SerializeField]
    float timeToSpawn;

    float spawnTimer = 0f;
    void Update()
    {
        spawnTimer += Time.deltaTime;
        //every spawn interval take random spawner and spawn trash.
        if (spawnTimer >= timeToSpawn)
        {
            int rnd = Random.Range(0, trashSpawners.Count);
            trashSpawners[rnd].SpawnRandom();
            spawnTimer = 0f;
        }
    }
}
