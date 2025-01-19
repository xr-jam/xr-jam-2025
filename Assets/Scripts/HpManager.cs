using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    [SerializeField]
    GameObject iconParent;

    public void SubtractHp()
    {
        for (int i = iconParent.transform.childCount - 1; i >= 0; i--)
        {
            GameObject child = iconParent.transform.GetChild(i).gameObject;

            RawImage image = child.GetComponent<RawImage>();
                
            if (image.color == Color.white)
            {
                image.color = Color.black;
                break;
            }
        }
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
