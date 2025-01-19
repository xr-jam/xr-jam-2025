using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    [SerializeField]
    GameObject iconParent;

    [SerializeField]
    GameObject button;

    [SerializeField]
    TrashManager manager;

    public void SubtractHp()
    {
        for (int i = iconParent.transform.childCount - 1; i >= 0; i--)
        {
            GameObject child = iconParent.transform.GetChild(i).gameObject;

            RawImage image = child.GetComponent<RawImage>();
                
            if (image && image.color == Color.white)
            {
                image.color = Color.black;
                if(i <= 0)
                {
                    ReloadScene();
                }
                break;
            }
        }
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
