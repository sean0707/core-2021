using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sk1 : MonoBehaviour
{
    public float rc;
    public float time;
    public bool r;
    public GameObject skill;
    public GameObject hit;
    // Start is called before the first frame update
    void Start()
    {
        time = rc;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            if (time >= rc)
            {
                skill.gameObject.GetComponent<ParticleSystem>().Play();
                hit.gameObject.GetComponent<MeshCollider>().enabled = true;
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
            
            r = true;
        }
        GetComponent<CanvasGroup>().alpha = time/rc;
        if (time > 0.8f)
        {
            hit.gameObject.GetComponent<MeshCollider>().enabled = false;
        }
    }

}
