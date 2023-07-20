using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open : MonoBehaviour
{
    public Animator animator;
    public bool on;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
                on = !on;
                animator.SetBool("open",on);
                Debug.Log(other);
            }
        }
    }
}
