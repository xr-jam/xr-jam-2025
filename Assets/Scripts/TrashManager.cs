using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    [SerializeField]
    TrashSpawner trashSpawner;

    [SerializeField]
    float timeToSpawn;
    private float timeToSpawnDelta;
    public float trashSpeed = 1f;
    private float targetSpeedIncrease = 5f;

    float spawnTimer = 0f;
    float secondTimer = 0f;

    private void Start()
    {
        trashSpawner.trashManager = this;
        targetSpeedIncrease = trashSpeed * 5 / 300;
        timeToSpawnDelta = (timeToSpawn - timeToSpawn * 0.2f) / 300;
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

        secondTimer += Time.deltaTime;
        if (secondTimer >= 1f)
        {
            trashSpeed += targetSpeedIncrease;
            timeToSpawn -= timeToSpawnDelta;
            secondTimer = 0f;
        }
    }
}
