using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle9 : MonoBehaviour
{

    public GameObject bgm;
    public static int w = 1;
    public GameObject[] weapon;
    public bool attack;
    public float t = 1;
    public float r = 1;
    public bool idol;
    public GameObject effect;
    public Animator animator;
    F mode = F.w1;
    public enum F
    {
        w1 = 1,
        w2 = 2,
        w3 = 3,
        w4 = 4,
        w5 = 5,
        w6 = 6,
        w7 = 7,
        w8 = 8
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // weapon.GetComponent<MeshCollider>().convex = true;
        // weapon.GetComponent<MeshCollider>().isTrigger = true;
        //  weapon.GetComponent<MeshCollider>().convex = false;
        // weapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("run", move.manager.q);
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("attack"))//判定播放動畫
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f) //判定動畫結束
            {
                animator.SetBool("attack", false);
                attack = false;
            }
            else
            {
                attack = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            t = 1;
            attack = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("roll", true);
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("roll"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f) //判定動畫結束
            {
                animator.SetBool("roll", false);
            }
        }

            if (!attack)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetBool("attack", true);
                animator.SetInteger("mode", w);
                move.manager.getscore(1.1f);
                bgm2.manager.fire();
            }
            weapon[w].GetComponent<MeshCollider>().enabled = false;
            effect.GetComponent<TrailRenderer>().enabled = false;
            weapon[w].GetComponent<NewBehaviourScript7>().enabled = false;
            weapons();

            //   weapon.SetActive(false);
        }
        
        if (attack)
        {
            weapon[w].GetComponent<MeshCollider>().enabled = true;
            effect.GetComponent<TrailRenderer>().enabled = true;
            weapon[w].GetComponent<NewBehaviourScript7>().enabled = true;
            // weapon.SetActive(true);
        }
      /*  if(t < -3)
        {
            idol = true;
            HP.manager.getbot(1);
            t = 0;
        }
        else
        {
            idol = false;
            HP.manager.getbot(0);

        }*/
    }
    private void weapons()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (w != 1)
            {
                mode = mode + 1;
            }
            else
            {
                mode = mode + NewBehaviourScript1.manager.mode;
            }
        }
        switch (mode)
        {

            case F.w1:
                weapon[1].SetActive(true);
                weapon[2].SetActive(false);
                weapon[3].SetActive(false);
                weapon[4].SetActive(false);
                weapon[5].SetActive(false);
                weapon[6].SetActive(false);
                weapon[7].SetActive(false);
                weapon[8].SetActive(false);
                w = 1;
                mode = 0;
                break;
            case F.w2:
                weapon[1].SetActive(false);
                weapon[2].SetActive(true);
                weapon[3].SetActive(false);
                weapon[4].SetActive(false);
                weapon[5].SetActive(false);
                weapon[6].SetActive(false);
                weapon[7].SetActive(false);
                weapon[8].SetActive(false);
                w = 2;
                mode = 0;
                break;
            case F.w3:
                weapon[1].SetActive(false);
                weapon[2].SetActive(false);
                weapon[3].SetActive(true);
                weapon[4].SetActive(false);
                weapon[5].SetActive(false);
                weapon[6].SetActive(false);
                weapon[7].SetActive(false);
                weapon[8].SetActive(false);
                w = 3;
                mode = 0;
                break;
            case F.w4:
                weapon[1].SetActive(false);
                weapon[2].SetActive(false);
                weapon[3].SetActive(false);
                weapon[4].SetActive(true);
                weapon[5].SetActive(false);
                weapon[6].SetActive(false);
                weapon[7].SetActive(false);
                weapon[8].SetActive(false);
                w = 4;
                mode = 0;
                break;
            case F.w5:
                weapon[1].SetActive(false);
                weapon[2].SetActive(false);
                weapon[3].SetActive(false);
                weapon[4].SetActive(false);
                weapon[5].SetActive(true);
                weapon[6].SetActive(false);
                weapon[7].SetActive(false);
                weapon[8].SetActive(false);
                w = 5;
                mode = 0;
                break;
            case F.w6:
                weapon[1].SetActive(false);
                weapon[2].SetActive(false);
                weapon[3].SetActive(false);
                weapon[4].SetActive(false);
                weapon[5].SetActive(false);
                weapon[6].SetActive(true);
                weapon[7].SetActive(false);
                weapon[8].SetActive(false);
                w = 6;
                mode = 0;
                break;
            case F.w7:
                weapon[1].SetActive(false);
                weapon[2].SetActive(false);
                weapon[3].SetActive(false);
                weapon[4].SetActive(false);
                weapon[5].SetActive(false);
                weapon[6].SetActive(false);
                weapon[7].SetActive(true);
                weapon[8].SetActive(false);
                w = 7;
                mode = 0;
                break;
            case F.w8:
                weapon[1].SetActive(false);
                weapon[2].SetActive(false);
                weapon[3].SetActive(false);
                weapon[4].SetActive(false);
                weapon[5].SetActive(false);
                weapon[6].SetActive(false);
                weapon[7].SetActive(false);
                weapon[8].SetActive(true);
                w = 8;
                mode = 0;
                break;
        }
    }
}
