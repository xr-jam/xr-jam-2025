using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    [SerializeField]
    public TrashType.Category Category;

    [SerializeField]
    AudioManager audioManager;

    [SerializeField]
    HpManager hpManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Trash>(out var trash))
        {
            if (trash.Category == Category)
            {
                audioManager.PlayRightSelectionSound();
            }
            else 
            {
                hpManager.SubtractHp();
                audioManager.PlayWrongSelectionSound();
            }
        }
        else Debug.Log("not trash");
    }
}
