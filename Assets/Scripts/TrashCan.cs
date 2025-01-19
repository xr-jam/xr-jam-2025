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
    ScreenFlash flash;

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
                flash.OnRightChoice();
            }
            else
            {
                audioManager.PlayWrongSelectionSound();
                flash.OnWrongChoice();
            }

            Destroy(other.gameObject);
        }
        else Debug.Log("not trash");
    }
}
