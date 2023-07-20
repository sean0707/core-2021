using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public bool N;
    public int  C;
    public int pt;
    public TextAsset a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TMP.ctrl.p < C)
        {
            GetComponent<Collider>().enabled = false;
            N = true;
        }
        else
        {
            GetComponent<Collider>().enabled = true;
            N = false;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            TMP.ctrl.s = pt;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
        }
    }
}
