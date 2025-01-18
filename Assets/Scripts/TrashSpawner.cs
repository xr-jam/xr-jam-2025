using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> trashPrefabs;
    public void SpawnRandom()
    {
        int rnd = Random.Range(0, trashPrefabs.Count);
        var obj = Instantiate(trashPrefabs[rnd], transform.position, Quaternion.identity, transform);

        AddForce movement = obj.AddComponent<AddForce>();
        obj.AddComponent<BoxCollider>();
        obj.AddComponent<Rigidbody>();

        movement.surfaceSpeed = 1;
    }
}
