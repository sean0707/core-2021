﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle3 : MonoBehaviour
{
    public GameObject bgm;
    public GameObject weapon;
    public bool attack;
    public float t = 1;
    public float r = 1;
    public bool idol;
    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        // weapon.GetComponent<MeshCollider>().convex = true;
        // weapon.GetComponent<MeshCollider>().isTrigger = true;
        //  weapon.GetComponent<MeshCollider>().convex = false;
        // weapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            move.manager.roll = true;
        }
        if (wepon.w == 3)
        {
            if (t >= -3)
            {
                t = t - Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.F1))
            {
                t = 1;
                attack = true;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GetComponent<Animation>().Play("a3");
                t = 1.5f;
                move.manager.getscore(1.5f);
                bgm2.manager.fire();
                attack = true;
                wepon.manager.a = true;
            }
            else if (t <= 0)
            {
                attack = false;
                wepon.manager.a = false;
            }
        }
        if (!attack)

        {
            weapon.GetComponent<MeshCollider>().enabled = false;
            effect.GetComponent<TrailRenderer>().enabled = false;
            weapon.GetComponent<NewBehaviourScript7>().enabled = false;
            //   weapon.SetActive(false);
            if (move.manager.roll)
            {
                GetComponent<Animation>().Play("roll");
                r = r - Time.deltaTime;
                if (r <= 0)
                {
                    move.manager.roll = false;
                    r = 1;
                }
            }
            else
            {
            if (Input.GetKey(KeyCode.W))
            {
                attack = false;
                t = 2;
                GetComponent<Animation>().Play("run");
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                GetComponent<Animation>().Play("stop");
            }
            if (t <= 0)
            {
                GetComponent<Animation>().Play("idol");
            }
            if (Input.GetKey(KeyCode.A))
            {
                t = 2;
                GetComponent<Animation>().Play("run");
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                GetComponent<Animation>().Play("stop");
            }
            if (Input.GetKey(KeyCode.D))
            {
                t = 2;
                GetComponent<Animation>().Play("run");
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                GetComponent<Animation>().Play("stop");
            }
            if (Input.GetKey(KeyCode.S))
            {
                attack = false;
                t = 2;
                GetComponent<Animation>().Play("run");
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                GetComponent<Animation>().Play("stop");
            }
            }


        }
        if (attack)
        {
            effect.GetComponent<TrailRenderer>().enabled = true;
            if (t < 1)
            {
                weapon.GetComponent<MeshCollider>().enabled = true;
                weapon.GetComponent<NewBehaviourScript7>().enabled = true;
            }
            // weapon.SetActive(true);
        }
    /*    if (t < -3)
        {
            idol = true;
            HP.manager.getbot(1);
          //  t = 0;
        }
        else
        {
            idol = false;
            HP.manager.getbot(0);

        }*/

    }
}
