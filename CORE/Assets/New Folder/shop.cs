using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public bool N;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            N = true;
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                BUY();
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            N = false;

        }
    }
    void BUY()
    {
        if(TMP.ctrl.coin.數量 >= 50)
        {
            TMP.ctrl.getcoin(-50);
            item.manager.getT1(1);
        }
    }
}
