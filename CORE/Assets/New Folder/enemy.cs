using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
 //   public static enemy manager;
    public GameObject[] e;
    public GameObject d;
    private pool<ai2> ep;
    private pool<ai> ap;
    public GameObject[] s;
    public bool c;
    // Start is called before the first frame update
    void Start()
    {
        ap = pool<ai>.Instance;
        ep = pool<ai2>.Instance;
        ep.initpool(e[0]);
        ap.initpool(e[1]);
        InvokeRepeating("rec", 1, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void rec()
    {
        //int point = Random.Range(0, s.Length);
       // GetComponent<CapsuleCollider>().enabled = true;
        if (!d.activeInHierarchy)
        {
            ai2 e = ep.Spawn(s[0].transform.position, this.transform.rotation, s[0].transform.parent);
            ai a = ap.Spawn(s[1].transform.position, this.transform.rotation, s[1].transform.parent);
            ai2 v = ep.Spawn(s[2].transform.position, this.transform.rotation, s[2].transform.parent);
        }


    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "enemy")
        {
            d = other.gameObject;
        }
    }
}
