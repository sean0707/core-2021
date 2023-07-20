using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript9 : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.transform.position = target.position - offset;
        }
    }
}
