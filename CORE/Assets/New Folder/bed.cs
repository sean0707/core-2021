using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bed : MonoBehaviour
{

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
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if (other.tag == "Player")
            {
                if (savedata.heal)
                {
                    HP.manager.currentHealth = 100;
                    savedata.heal = !savedata.heal;
                }
            }
        }
    }
}
