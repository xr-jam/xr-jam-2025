using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    [SerializeField]
    TrashSpawner trashSpawner;

    [SerializeField]
    float timeToSpawn;
    public float trashSpeed = 1f;

    float spawnTimer = 0f;

    private void Start()
    {
        trashSpawner.trashManager = this;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        //every spawn interval take random spawner and spawn trash.
        if (spawnTimer >= timeToSpawn)
        {
            trashSpawner.SpawnRandom();
            spawnTimer = 0f;
        }
    }
}
