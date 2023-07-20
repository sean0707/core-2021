    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class equipment : MonoBehaviour
{
    public static equipment manager;
    public GameObject[] a;
    public GameObject b;
    public bag bag;
    public equip amor;
    public bool x;
    // public equip Equip;

    // Start is called before the first frame update
    void Start()
    {
        if (manager == null)
        {
            manager = this;
        }
        x = false;
        // gameObject.GetComponent<CanvasGroup>().alpha = 0;
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        for (int i = 1; i < bag.equiplist.Count; i++)
        {
            recheck(bag.equiplist[i]);
        }
    }

    // Update is called once per frame
    public void get(equip value)
    {
        //amor = value;
        //  amor = equip;
        if (!bag.equiplist.Contains(value))
        {
            bag.equiplist.Add(value);
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].GetComponent<Image>().sprite == null)
                {
                    if(a[i].GetComponent<Image>().sprite != value.圖示)
                    {
                        a[i].GetComponent<Image>().sprite = value.圖示;
                    }
                    return;
                }

            }
        }
        
    }
    public void recheck(equip value)
    {
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i].GetComponent<Image>().sprite == null)
            {
                if (a[i].GetComponent<Image>().sprite != value.圖示)
                {
                    a[i].GetComponent<Image>().sprite = value.圖示;
                }
                return;
            }

        }
    }
    public void switchup(int value)
    {
        amor = bag.equiplist[value];
        b.GetComponent<Image>().sprite = amor.圖示;
    }
}
