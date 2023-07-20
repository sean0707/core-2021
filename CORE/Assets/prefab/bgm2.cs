using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm2 : MonoBehaviour
{
    public static bgm2 manager;
    public GameObject w1;
    public GameObject w2;
    public GameObject w3;
    public GameObject w4;
    public GameObject w5;
    public GameObject w6;
    public GameObject w7;
    public GameObject w8;
    //  public bool B;
    // Start is called before the first frame update
    void Start()
    {
        if (manager == null)
        {
            manager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Mouse0))
        {



            //   B = !B;
        }*/
        /*  if (B)
          {
              gameObject.GetComponent<AudioSource>().enabled = true;

          }
          else
          {
              gameObject.GetComponent<AudioSource>().enabled = false;
          }*/
    }
    void delay()
    {
        if (wepon.w == 8)
        {
            w8.gameObject.GetComponent<AudioSource>().enabled = false;
            w8.gameObject.GetComponent<AudioSource>().enabled = true;
        }
        if (wepon.w == 3)
        {
            w3.gameObject.GetComponent<AudioSource>().enabled = false;
            w3.gameObject.GetComponent<AudioSource>().enabled = true;
        }

    }
   public void fire()
    {
        if (Time.timeScale != 0)
        {
            if (wepon.w == 1)
            {
                w1.gameObject.GetComponent<AudioSource>().enabled = false;
                w1.gameObject.GetComponent<AudioSource>().enabled = true;
            }
            if (wepon.w == 2)
            {
                w2.gameObject.GetComponent<AudioSource>().enabled = false;
                w2.gameObject.GetComponent<AudioSource>().enabled = true;
            }
            if (wepon.w == 3)
            {
                Invoke("delay", 1);
            }
            if (wepon.w == 4)
            {
                w4.gameObject.GetComponent<AudioSource>().enabled = false;
                w4.gameObject.GetComponent<AudioSource>().enabled = true;

            }
            if (wepon.w == 6)
            {
                w6.gameObject.GetComponent<AudioSource>().enabled = false;
                w6.gameObject.GetComponent<AudioSource>().enabled = true;
            }
            if (wepon.w == 5)
            {
                w5.gameObject.GetComponent<AudioSource>().enabled = false;
                w5.gameObject.GetComponent<AudioSource>().enabled = true;
            }
            if (wepon.w == 7)
            {
                w7.gameObject.GetComponent<AudioSource>().enabled = false;
                w7.gameObject.GetComponent<AudioSource>().enabled = true;
            }
            if (wepon.w == 8)
            {
                Invoke("delay", 0.3f);
            }
        }
    }
}
