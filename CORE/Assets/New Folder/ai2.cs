using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class ai2 : MonoBehaviour
{
    public CharacterController characterController;
    public GameObject bgm;
    private Rigidbody rb;
    public GameObject area2;
    public GameObject att;
    public TextMeshProUGUI dame;
    private int Rnd;
    public bool attack;
    public bool bg;
    public float a = 3;
    public float t = 1;
    public float hp = 150;
    public const int STATE_STAND = 0;
    public const int STATE_WALK = 1;
    public const int STATE_RUN = 1;
    public float j;
    public bool check;
    public bool dead;
    public float n;
    public Animator animator;
    //怪物当前状态
    private int NowState;
    //游戏角色
    public GameObject player;
    //怪物思考时间
    public const int AI_THINK_TIME = 2;
    //触发怪物攻击的临界距离
    public const int AI_ATTACT_DISTANCE = 250;
    public const int AI_ATTACT = 58;
    public const int AI_SREACH = 70;
    //上一次思考的时间
    public float LastThinkTime;
    public int S;
    Vector3 velocity = Vector3.zero;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("00");
    }

    void Update()
    {
        Vector3 pp = player.transform.position;
        pp.y = j;
        j = GetComponent<Transform>().position.y;
        if (!dead)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                t = 1;
            }
            /*  if (Input.GetKey(KeyCode.Space))
              {
                  check = false;
              }
              else
              {
                  check = true;
              }
              if(check)
              {
                  pp.y = j;
                  j = GetComponent<Transform>().position.y;
              }
              else
              {
                  pp.y = move.manager.j;
              }*/
            if (Vector3.Distance(transform.position, player.transform.position) <= AI_ATTACT)
            {
                a = a - Time.deltaTime;
                if (a <= 0)
                {
                    attack = true;
                  //  this.GetComponent<Animation>().Play("ea 002");
                    a = Random.Range(5, 6);
                    animator.SetBool("attack", true);
                    mode();
                }
                else
                {

                    if (animator.GetCurrentAnimatorStateInfo(0).IsTag("a"))//判定播放動畫
                    {
                        if(Rnd == 2)
                        {
                            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.3f)
                            {
                                characterController.Move(transform.forward * 7);
                            }
                        }
                        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f) //判定動畫結束
                        {
                            animator.SetBool("attack", false);
                            attack = false;
                        }

                    }
                }

            }
            else
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsTag("a"))//判定播放動畫
                {
                    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f) //判定動畫結束
                    {
                        animator.SetBool("attack", false);
                        attack = false;
                    }

                }
            }
            if (!attack)
            {
                area2.GetComponent<BoxCollider>().enabled = false;
                //当敌人与怪物间的距离小于攻击范围半径的时候
                if (Vector3.Distance(transform.position, player.transform.position) < AI_ATTACT_DISTANCE)
                {

                    if (Vector3.Distance(transform.position, player.transform.position) > AI_ATTACT)
                    {
                        //敌人开始奔跑
                        animator.SetBool("walk", true);
                      //  this.GetComponent<Animation>().Play("ew 002");
                        //敌人进入奔跑状态
                        NowState = STATE_RUN;
                        //使敌人面向角色
                        transform.LookAt(pp);
                        //向玩家靠近
                        //transform.Translate(Vector3.forward * Time.deltaTime * S);
                        // rb.AddForce(transform.forward * S);
                        var move = transform.forward * S;
                        characterController.Move(move);

                    }
                    else
                    {
                        animator.SetBool("walk", false);

                    }
                    if (!bg)
                    {
                        Instantiate(bgm, transform.position, Quaternion.identity);
                        bg = true;
                    }
                }
                else
                {
                    animator.SetBool("walk", false);
                }
                //  else
                //   {
                //当当前时间与上一次思考时间的差值大于怪物的思考时间时怪物开始思考
              /*     if (Time.time - LastThinkTime > AI_THINK_TIME)
                   {
                //开始思考
                      LastThinkTime = Time.time;
                //获取0-1之间的随机数字
                        int Rnd = Random.Range(0, 2);
                //根据随机数值为怪物赋予不同的状态行为
                       switch (Rnd)
                        {
                            case 0:
                            //站立状态
                         
                //               this.GetComponent<Animation>().Play("idol");
                //                NowState = STATE_STAND;
                                break;

                             case 1:
                          // Vector3 rp = transform.position + new Vector3(1,0, 1);
                            //行走状态
                            //使怪物旋转以完成行走动作
                            //  Quaternion mRotation = Quaternion.Euler(0, Random.Range(1, 5) * 90, 0);
                            //  transform.rotation = Quaternion.Slerp(transform.rotation, mRotation, Time.deltaTime * 1000);
                            //播放动画
                           // animator.SetBool("walk", true);
                            //              this.GetComponent<Animation>().Play("STOP1");
                            //改变位置
                          // transform.LookAt(rp);
                          //  transform.Translate(Vector3.forward * Time.deltaTime * 150);
                //             NowState = STATE_WALK;
                             break;

                        //  case 2:
                //奔跑状态
                //             this.GetComponent<Animation>().Play("run");
                //              transform.Translate(Vector3.forward * Time.deltaTime * 20);
                //              NowState = STATE_RUN;
                           //  break;

                       }
                   }
                //    }*/
            }
            if (attack)
            {
                    area2.GetComponent<BoxCollider>().enabled = true;
            }


        }
        velocity.y = -100;// * Time.deltaTime;
        characterController.Move(velocity);
        //rb.AddForce(Vector3.down * 50000);
        if (dame.GetComponent<CanvasGroup>().alpha > 0)
        {
            int r = Random.Range(-3, 3);
            dame.GetComponent<CanvasGroup>().alpha -= 0.01f;
            dame.transform.Translate(Vector3.up * r * Time.deltaTime);
        }
    }
    void Damage(float damagevalue)
    {
        hp -= damagevalue;
        dame.text = "" + damagevalue;
        dame.GetComponent<CanvasGroup>().alpha = 1;
        Instantiate(dame, transform.position, transform.rotation);//特效
        if (!dead)
        {
            Instantiate(att, transform.position, transform.rotation);//特效
            if (hp <= 0)
            {
                if (TMP.ctrl.m == "a")
                {
                    TMP.ctrl.getscore(1);
                }
                Invoke("death", 1);
                animator.SetBool("death", true);
               // this.GetComponent<Animation>().Play("ed 002");
                dead = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {


    }
    void OnTriggerEnter(Collider other)
    {
        if (t >= 1)
        {
            if (other.tag == "wepon")
            {
                Damage(NewBehaviourScript1.manager.c + move.manager.damege + equipment.manager.amor.atk);
            }
           /* if (other.name == "w01")
            {
                Damage(15 + NewBehaviourScript1.manager.c + move.manager.damege + equipment.manager.amor.atk);
             
            }
            if (other.name == "w02")
            {
                Damage(5 + NewBehaviourScript1.manager.c + move.manager.damege + equipment.manager.amor.atk);

            }
            if (other.name == "w03")
            {
                Damage(35 + NewBehaviourScript1.manager.c + move.manager.damege + equipment.manager.amor.atk);

            }
            if (other.name == "w08")
            {
                Damage(25 + NewBehaviourScript1.manager.c + move.manager.damege + equipment.manager.amor.atk);

            }*/

            t = t - Time.deltaTime;
        }
        if (other.tag == "effect")
        {
            Damage(50);
        }
        if (other.tag == "bullet")
        {
            Damage(NewBehaviourScript1.manager.b);
        }
    }
        void death()
        {
            exp.manager.getscore(50);
            // enemy.manager.rebirth(1);
            pool<ai2>.Instance.Recycle(this);
            dame.text = null;
        }
        void OnEnable()
        {
            attack = false;
           // animator.SetBool("death", false);
            dead = false;
            hp = 150;
            //this.GetComponent<Animation>().Play("er 002");
        }
    public void mode()
    {
        Rnd = Random.Range(1, 3);
        switch (Rnd)
        {
            case 1:
                //站立状态
                animator.SetInteger("mode", 1);
                break;
            case 2:
                //站立状态
                //               this.GetComponent<Animation>().Play("idol");
                //                NowState = STATE_STAND;
                animator.SetInteger("mode", 2);

                break;
        }
    }

}
