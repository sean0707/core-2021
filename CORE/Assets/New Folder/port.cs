using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class port : MonoBehaviour
{
    public Transform b;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                other.transform.position = b.transform.position;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            move.manager.stay = false;
        }

    }
}
