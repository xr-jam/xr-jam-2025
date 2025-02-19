using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> trashPrefabs;

    public TrashManager trashManager;


    public void SpawnRandom()
    {
        int rnd = Random.Range(0, trashPrefabs.Count);
        var obj = Instantiate(trashPrefabs[rnd], transform.position, Quaternion.identity, transform);

        Trash trash = obj.AddComponent<Trash>();
        
        //parse by name
        if (obj.name.Contains("plastic"))
        {
            trash.Category = TrashType.Category.Plastic;
        }
        else if (obj.name.Contains("paper"))
        {
            trash.Category = TrashType.Category.Paper;
        }
        else if (obj.name.Contains("misc"))
        {
            trash.Category = TrashType.Category.Misc;
        }
        else if (obj.name.Contains("glass"))
        {
            trash.Category = TrashType.Category.Glass;
        }

        obj.AddComponent<BoxCollider>();
        obj.AddComponent<Rigidbody>();
        obj.AddComponent<XRGrabInteractable>();

        AddForce movement = obj.AddComponent<AddForce>();
        movement.trashManager = trashManager;
    }
}
