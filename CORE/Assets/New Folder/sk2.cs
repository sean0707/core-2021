using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sk2 : MonoBehaviour
{
    public float rc;
    public float time;
    public float pow;
    public bool r;
    public GameObject skill;
    public GameObject hit;
    // Start is called before the first frame update
    void Start()
    {
        time = rc;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.C))
        {
            if (time >= rc)
            {
                skill.SetActive(true);
                time = 0;
                r = false;
            }
        }
        if (time < rc)
        {
            time = time + Time.deltaTime;
        }
        else
        {
            skill.SetActive(false);
            r = true;
        }
        GetComponent<CanvasGroup>().alpha = time/rc;
        if (time < 0.05f)
        {
            HP.manager.cut = pow;
        }
        if (time > (0.95f * rc))
        {
            HP.manager.cut = 0;
        }
    }

}
