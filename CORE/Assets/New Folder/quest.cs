using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quest : MonoBehaviour
{
    public static quest ctrl;
    public bool Q;
    public bool M;
    public bool O;
    public GameObject myObjArray;
    public GameObject 提示;
    public TextAsset a;
    public talk Talk;


    private void Awake()
    {
        ctrl = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!M)
        {
            提示.gameObject.GetComponent<ParticleSystem>().Play();
        }

    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "npc")
        {
            Q = true;
            M = true;
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                myObjArray = other.gameObject;
                TMP.ctrl.m = myObjArray.name;
                a = myObjArray.GetComponent<NPC>().a;
                Talk.gettext(a);
            }
        }
        if (other.tag == "mob")
        {
            M = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "npc")
        {
            Q = false;
            M = false;
            myObjArray = default;

        }
        if (other.tag == "mob")
        {
            M = false;
        }
    }
}
