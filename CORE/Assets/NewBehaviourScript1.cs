using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    public static NewBehaviourScript1 manager;
    public int a ;
    public int b ;
    public int c ;
    public int d;
    public int mode;
    // Start is called before the first frame update
    void Start()
    {
        if (manager == null)
        {
            manager = this;
        }
        if (savedata.check)
        {
         a = auto.manager.A;
         b = auto.manager.B;
         c = auto.manager.C;
         d = auto.manager.D;
          gameObject.transform.position += new Vector3((11-a)*3, (b - 11)*1.5f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (b > c && c > a)
        {
            mode = 7;
        }
        if (a > c && c > b)
        {
            mode = 2;
        }
        if (a > b && b > c)
        {
            mode = 3;
        }
        if (c > b && b > a)
        {
            mode = 6;
        }
        if (b > a && a > c)
        {
            mode = 5;
        }
        if (c > a && a > b)
        {
            mode = 8;
        }
        if (a < 17 && b < 17 && c < 17)
        {
            mode = 4;
        }

    }
    public void  Red()
    {
    
        if (d > 0 & a < 22 & b > 0 & c > 0)
        {
          a = a + 2;
          b = b - 1;
          c = c - 1;
          d = d - 1;
         gameObject.transform.position += new Vector3(-3,-1.5f);
        }
    }
    public void Blue()
    {
        if (d > 0 & a > 0 & b < 22 & c > 0)
        {
         a = a - 1;
         b = b + 2;
         c = c - 1;
         d = d - 1;
            gameObject.transform.position += new Vector3(0, 3);
        }   
    }
    public void Yellow()
    {
        if (d > 0 & a > 0 & b > 0 & c < 22)
        {
         a = a - 1;
         b = b - 1;
         c = c + 2;
         d = d - 1;
            gameObject.transform.position += new Vector3(3, -1.5f);
        }
    }
    public void getd(int value)
    {
        d += value;
    }
}
