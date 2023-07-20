using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript2 : MonoBehaviour
{

    public float t = 1;
    public Transform target;
    public Vector3 offset1;
    public Vector3 offset2;
 //   public Vector3 offset3;
    public bool e;
    public bool a;
    public bool b;
    //  public static bool s;
    public float x;
    public float y;
    public float d;
    public int cx;
    public int cy;
    void Start()
    {

       // transform.LookAt(target.position + offset1);
        DontDestroyOnLoad(gameObject);
       // offset = target.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     /*   float rotationX = transform.localEulerAngles.x + Input.GetAxis("Mouse Y");
        float rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X");
        rotationX = Mathf.Clamp(rotationX, 1, 10);
        if (rotationY > 180)
        {
            rotationY -= 360f;
        }
        rotationY = Mathf.Clamp(rotationY, -20, 20);
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);*/
           if (e)
           {
               // this.transform.position = target.position - offset ;
               //   transform.rotation = Quaternion.Euler(25, 0, 0);
               if (a)
               {
                   transform.position = (target.position) + Quaternion.Euler(cy, cx, 0) * (Vector3.back * d) + offset1;
               }
               if (b)
               {
                   transform.rotation = Quaternion.Euler(cy, cx, 0);
               }
               else
               {
                   transform.rotation = Quaternion.Euler(0, cx, 0);
               }
           }
           else
           {
               t = t - Time.deltaTime;
               transform.position = (target.position) + Quaternion.Euler(-5, y, 0) * (Vector3.forward * 50) + offset2;
               transform.LookAt(target.position + offset2);
           }
        /*   if (s)
           {
               transform.position = (target.position) + Quaternion.Euler(-x, y, 0) * (Vector3.forward * 50) + offset3;
               transform.LookAt(target.position + offset3);
           }*/

        if (Input.GetKeyDown(KeyCode.G))
        {
            e = !e;
        }
        if (Input.GetKey(KeyCode.H))
        {
            cx--;
        }
        if (Input.GetKey(KeyCode.K))
        {
            cx++;
        }
        if (Input.GetKey(KeyCode.U))
        {
            cy--;
        }
        if (Input.GetKey(KeyCode.J))
        {
            cy++;
        }
        /*    if (Input.GetKeyDown(KeyCode.S))
            {
                s = true;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                s = false;
            }*/
        if (t <= 0)
        {
            e = !e;
            t = 1;
        }
    }
   
}
