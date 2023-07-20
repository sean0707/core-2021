using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class ai : MonoBehaviour
{
    public GameObject bgm;
    private Rigidbody rb;
    public GameObject area;
    public GameObject att;
    public TextMeshProUGUI dame;
    public bool attack;
    public bool b;
    public float a = 2;
    public float t = 1;
    public float hp = 100;
    public const int STATE_STAND = 0;
    public const int STATE_WALK = 1;
    public const int STATE_RUN = 2;
    public float j;
    public bool dead;
  //  public bool check;

    //怪物当前状态
    private int NowState;
    //游戏角色
    public GameObject player;
    //怪物思考时间
    public const int AI_THINK_TIME = 2;
    //触发怪物攻击的临界距离
    public const int AI_ATTACT_DISTANCE = 200;
    public const int AI_ATTACT = 30;
    //上一次思考的时间
    public float LastThinkTime;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("00");
    }

    void Update()
    {
        Vector3 pp = player.transform.position;
        pp.y = j;
        j = GetComponent<Transform>().position.y;
        if(!dead){
        if (Input.GetKeyDown(KeyCode.Mouse0))
              {
            t = 1;
              }
        if (Vector3.Distance(transform.position, player.transform.position) <= AI_ATTACT)
        {
            a = a - Time.deltaTime;
            if (a <= 0)
            {
                attack = true;
                this.GetComponent<Animation>().Play("ea 001");
                 a = Random.Range(2, 4);

            }else 
            {  
                attack = false;
            }
           
        }
       /* if (Input.GetKey(KeyCode.Space))
        {
            check = false;
        }
        else
        {
            check = true;
        }
        if (check)
        {
            pp.y = j;
            j = GetComponent<Transform>().position.y;
        }
        else
        {
            pp.y = move.manager.j;
        }*/
        if (!attack)
        {
            area.GetComponent<BoxCollider>().enabled = false;
        }
        if (attack)
        {
            area.GetComponent<BoxCollider>().enabled = true;
        }

        //当敌人与怪物间的距离小于攻击范围半径的时候
        if (Vector3.Distance(transform.position, player.transform.position) < AI_ATTACT_DISTANCE)
        {
            if (Vector3.Distance(transform.position, player.transform.position) > AI_ATTACT)
            {
             //敌人开始奔跑
                this.GetComponent<Animation>().Play("ew 001");
            //敌人进入奔跑状态
            NowState = STATE_RUN;
            //使敌人面向角色
            transform.LookAt(pp);
            //向玩家靠近
            transform.Translate(Vector3.forward * Time.deltaTime * 50);
            }
              
            if (!b)
            {
             Instantiate(bgm, transform.position, Quaternion.identity);
                b = true;
            }
        }
        if (Vector3.Distance(transform.position, player.transform.position) > AI_ATTACT)
        {  

        }
            //  else
            //   {
            //当当前时间与上一次思考时间的差值大于怪物的思考时间时怪物开始思考
            //     if (Time.time - LastThinkTime > AI_THINK_TIME)
            //   {
            //开始思考
            //     LastThinkTime = Time.time;
            //获取0-3之间的随机数字
            //        int Rnd = Random.Range(0, 2);
            //根据随机数值为怪物赋予不同的状态行为
            //       switch (Rnd)
            //        {
            //            case 0:
            //站立状态
            //               this.GetComponent<Animation>().Play("idol");
            //                NowState = STATE_STAND;
            //                break;

            //             case 1:
            //行走状态
            //使怪物旋转以完成行走动作
            //               Quaternion mRotation = Quaternion.Euler(0, Random.Range(1, 5) * 90, 0);
            //              transform.rotation = Quaternion.Slerp(transform.rotation, mRotation, Time.deltaTime * 1000);
            //播放动画
            //              this.GetComponent<Animation>().Play("STOP1");
            //改变位置
            //           transform.Translate(Vector3.forward * Time.deltaTime * 15);
            //             NowState = STATE_WALK;
            //             break;

            //          case 2:
            //奔跑状态
            //             this.GetComponent<Animation>().Play("run");
            //              transform.Translate(Vector3.forward * Time.deltaTime * 20);
            //              NowState = STATE_RUN;
            //             break;

            //  }
            //   }
            //    }
        }
        rb.AddForce(Vector3.down * 50000);
        dame.GetComponent<CanvasGroup>().alpha -= 0.01f;
    }
    void Damage(float damagevalue)
    {
        hp -= damagevalue;
        dame.text = "" + damagevalue;
        dame.GetComponent<CanvasGroup>().alpha = 1;
        if (hp <= 0)
        {
            if (TMP.ctrl.m == "a")
            {
                TMP.ctrl.getscore(1);
            }
            // Destroy(this.gameObject,2);
            Invoke("death", 2);
            this.GetComponent<Animation>().Play("ed 001");
            dead = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (t >= 1)
        {
            if (other.name == "w01")
            {
                Damage(15 + NewBehaviourScript1.manager.c + move.manager.damege + equipment.manager.amor.atk);
                Instantiate(att, transform.position, transform.rotation);//特效
            }
            if (other.name == "w02")
            {
                Damage(5 + NewBehaviourScript1.manager.c + move.manager.damege + equipment.manager.amor.atk);
                Instantiate(att, transform.position, transform.rotation);//特效
            }
            if (other.name == "w03")
            {
                Damage(20 + NewBehaviourScript1.manager.c + move.manager.damege + equipment.manager.amor.atk);
                Instantiate(att, transform.position, transform.rotation);//特效
            }
            if (other.name == "w08")
            {
                Damage(25 + NewBehaviourScript1.manager.c + move.manager.damege + equipment.manager.amor.atk);
                Instantiate(att, transform.position, transform.rotation);//特效
            }

            t = t - Time.deltaTime;
        }
        if (other.tag == "effect")
        {
            Damage(50);
            Instantiate(att, transform.position, transform.rotation);//特效
        }
        if (other.tag == "bullet")
        {
            Damage(NewBehaviourScript1.manager.b);
            Instantiate(att, transform.position, transform.rotation);//特效
        }
    }
    void death()
    {
        exp.manager.getscore(20);
        pool<ai>.Instance.Recycle(this);
        dame.text = null;
    }
    void OnEnable()
    {
        dead = false;
        hp = 100;
        this.GetComponent<Animation>().Play("er 001");

    }

}