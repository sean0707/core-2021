using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nw : MonoBehaviour
{
    public float t;
    public Rigidbody rigidbody;
    public float speed;
    public float turn;
    public Transform line;
    public float checkline = 1;
    public float MAXANGLE = 45;
    Vector3 hitline;
    Vector3 move;
    //  public CharacterController characterController;
    private AnimatorStateInfo info;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")).normalized;
        move = newPos * speed * Time.deltaTime;
        Quaternion target = Quaternion.FromToRotation(transform.forward, newPos)*transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, target, turn * Time.deltaTime);
        rigidbody.MovePosition(rigidbody.position + move);
        // info = animator.GetCurrentAnimatorStateInfo(0); Input.GetAxis("Jump")
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (t < 2)
            {
                t++;
            }

        }

        if (Check())
        {
            newPos = Vector3.ProjectOnPlane(newPos, hitline);
        }
         rigidbody.AddForce(Vector3.down * 10);
    }
    bool Check()
    {
        Ray ray = new Ray(line.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, checkline))
        {
            hitline = hit.normal;
            float slopeangle = Vector3.Angle(hit.normal, Vector3.up);
            if(slopeangle <= MAXANGLE)
            {
                return true;
            }
        }
        return false;
    }
}
