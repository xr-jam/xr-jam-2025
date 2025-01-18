using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    [SerializeField]
    public TrashType.Category Category;

    [SerializeField]

    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Trash>(out var trash))
        {
            if (trash.Category == Category)
            {
                audioManager.PlayRightSelectionSound();
            }
            else audioManager.PlayWrongSelectionSound();
        }
        else Debug.Log("not trash");
    }
}
