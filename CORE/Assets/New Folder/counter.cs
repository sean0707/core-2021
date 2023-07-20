using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class counter : MonoBehaviour
{
   // public static counter manager;
    public TextMeshProUGUI Text;
   // public int t1 = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(item.manager.T1 >= 0)
        {
            Text.text = "" + item.manager.T1 + "";
        }
    }
    /*public void getctrl(int value)
    {
        t1 += value;
    }*/
}
