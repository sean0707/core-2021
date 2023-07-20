using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class item : MonoBehaviour
{
    public static item manager;
    public int T1;
    public coin coin;
    public GameObject x1;
    public GameObject x2;
    public GameObject player;
    public GameObject hef;
    public GameObject pow;
    // Start is called before the first frame update
    void Start()
    {
        if (manager == null)
        {
            manager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(T1 > 0)
        {
            x1.GetComponent<CanvasGroup>().alpha = 1;
        }
        if(T1 <= 0)
        {
            x1.GetComponent<CanvasGroup>().alpha = 0;
        }
        if (coin.數量 > 0)
        {
            x2.SetActive(true);
        }
        if (coin.數量 <= 0)
        {
            x2.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (T1 > 0)
            {
                T1 = T1 - 1;
                HP.manager.getitem(1);
                move.manager.getscore(1);
                player.GetComponent<Animation>().Play("heal");
                hef.gameObject.GetComponent<ParticleSystem>().Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (coin.數量 > 0)
            {
                coin.數量 = coin.數量 - 1;
                move.manager.getscore(1);
                move.manager.powup(40);
                player.GetComponent<Animation>().Play("heal");
                pow.gameObject.GetComponent<ParticleSystem>().Play();
            }
        }
    }
    public void getT1(int value)
    {
        T1 += value;
      //  counter.manager.getctrl(1);
    }
}
