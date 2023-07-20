using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float t;
    public float c;
    public GameObject w4;
    public GameObject w5;
    public GameObject w6;
    public GameObject w7;
    public GameObject sp;
    //   public GameObject bb;
    //   public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        t = c;
        // Vector3 pp = bb.transform.position;
        // transform.LookAt(pp);
        // rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        t = t - Time.deltaTime;
        //   Vector3 newPos = new Vector3();
        //   newPos.x = gameObject.transform.position.x;
        //    newPos.y = gameObject.transform.position.y;
        //  newPos.z = gameObject.transform.position.z + 5;
        //   gameObject.transform.SetPositionAndRotation(newPos, gameObject.transform.rotation);
         // transform.position += transform.forward *5;
        transform.Translate(Vector3.forward * Time.deltaTime * 400);
        if (t < 0)
        {
            pool<bullet>.Instance.Recycle(this);
            t = c;
        }
        if (wepon.w == 4)
        {
            w4.SetActive(true);
            w5.SetActive(false);
            w6.SetActive(false);
            w7.SetActive(false);
        }
        if (wepon.w == 5)
        {
            w4.SetActive(false);
            w5.SetActive(true);
            w6.SetActive(false);
            w7.SetActive(false);
        }
        if (wepon.w == 6)
        {
            w4.SetActive(true);
            w5.SetActive(false);
            w7.SetActive(false);
            w6.SetActive(true);
        }
        if (wepon.w == 7)
        {
            w4.SetActive(false);
            w5.SetActive(false);
            w6.SetActive(false);
            w7.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            t = c;
            pool<bullet>.Instance.Recycle(this);
            Instantiate(sp, transform.position, transform.rotation);//特效
        }
    }
}
