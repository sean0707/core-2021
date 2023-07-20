using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getitem : MonoBehaviour
{
    public coin item;
    public equip equip;
    public bool t;
    public bool E;
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
                if (t)
                {
                    if (!TMP.ctrl.bag.itemlist.Contains(item))
                    {
                        TMP.ctrl.bag.itemlist.Add(item);
                    }
                    item.數量++;
                    t = false;
                }
                if (E)
                {
                    if (!equipment.manager.bag.equiplist.Contains(equip))
                    {
                        equipment.manager.get(equip);
                    }
                }
            }
        }
    }
}
