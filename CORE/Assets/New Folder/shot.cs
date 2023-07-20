using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    public Transform target;
    public GameObject c;
    public GameObject s;
    public GameObject b;
    public GameObject m;
    private pool<bullet> bp;
    public bool attack;
    public float t = 1;
    // Start is called before the first frame update
    void Start()
    {
        bp = pool<bullet>.Instance;
        bp.initpool(b);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = new Vector3(100 + NewBehaviourScript1.manager.b * 20, 1, 100 + NewBehaviourScript1.manager.b * 20);
        if (t >= -1)
        {
            t = t - Time.deltaTime;
        }
        if (wepon.w == 4)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                t = 1.1f;
                attack = true;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && !attack)
            {
                bullet b = bp.Spawn(this.transform.position, this.transform.rotation, this.transform.parent);
                t = 0.3f;
                bgm2.manager.fire();
                attack = true;
            }
            else if (t <= 0)
            {
                attack = false;
            }
                    this.gameObject.GetComponent<SphereCollider>().enabled = true;
        }
        if (wepon.w == 5)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                t = 1.1f;
                attack = true;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && !attack)
            {
                bullet b = bp.Spawn(this.transform.position, this.transform.rotation, this.transform.parent);
                t = 1;
                bgm2.manager.fire();
                attack = true;
            }
            else if (t <= 0)
            {
                attack = false;
            }
            this.gameObject.GetComponent<SphereCollider>().enabled = true;
        }
        if (wepon.w == 6)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                t = 1.1f;
                attack = true;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && !attack)
            {
                bullet b = bp.Spawn(this.transform.position, this.transform.rotation, this.transform.parent);
                // t = 0.15f;
                bgm2.manager.fire();
                attack = true;
            }
            else if (t <= 0)
            {
                attack = false;
            }
            this.gameObject.GetComponent<SphereCollider>().enabled = true;
        }
        if (wepon.w == 7)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                t = 1.1f;
                attack = true;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && !attack)
            {
                bullet b = bp.Spawn(this.transform.position, this.transform.rotation, this.transform.parent);
                t = 1;
                bgm2.manager.fire();
                attack = true;
                m.transform.LookAt(target);
            }
            else if (t <= 0)
            {
                attack = false;
            }
            this.gameObject.GetComponent<SphereCollider>().enabled = true;
        }
        if (target == default)
        {
            s.SetActive(false);
            transform.LookAt(c.transform);
        }
        target = null;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "enemy")
        {
            target = other.transform;
            s.SetActive(true);
            s.transform.position = target.transform.position;
             if(Input.GetKeyDown(KeyCode.Mouse0) && wepon.w > 3 && wepon.w < 8)
             {
                m.transform.LookAt(target);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "enemy")
        {
            s.SetActive(false);
        }
    }

}
