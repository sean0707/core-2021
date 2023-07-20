using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript4 : MonoBehaviour
{
    enum Mode
    { move, attack, tallk }
    public float t = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mode mode = Mode.move;
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mode = mode + 1;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            mode = mode + 2;
        }
        switch (mode)
        {
            case Mode.move:
         if (Input.GetKey(KeyCode.W))
        {
            t = 3;
            GetComponent<Animation>().Play("RUN");
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            GetComponent<Animation>().Play("STOP");
        }
        if (t <= 0)
        {
            GetComponent<Animation>().Play("idol");
        }
        if (Input.GetKey(KeyCode.A))
        {
            t = 3;
            GetComponent<Animation>().Play("RUN");
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<Animation>().Play("STOP");
        }
        if (Input.GetKey(KeyCode.D))
        {
            t = 3;
            GetComponent<Animation>().Play("RUN");
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<Animation>().Play("STOP");
        }
                break;
            case Mode.attack:
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    GetComponent<Animation>().Play("STOP1");
                    t = 1.5f;
                }
                    break;
            case Mode.tallk:
                Debug.Log("C");
                break;
            default:
                Debug.Log("D");
                break;
        }
        t = t - Time.deltaTime;
     if (t < -2)
        {
            t = 0;
        }
    }
}
