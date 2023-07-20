using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exp : MonoBehaviour
{
    public static exp manager;
    public int score;
    public RectTransform a, b;
    // Start is called before the first frame update
    void Start()
    {
        if (manager == null)
        {
            manager = this;
        }
        score = auto.manager.ep;
    }

    // Update is called once per frame
    void Update()
    {
        a.sizeDelta = new Vector2(score, a.sizeDelta.y);
        if (b.sizeDelta.x > a.sizeDelta.x)
        {
            b.sizeDelta += new Vector2(1, 0) * Time.deltaTime * 10;
        }
        if(score >= 100)
        {
            score = score - 100;
            NewBehaviourScript1.manager.getd(10);
            HP.manager.getLV(1);
        }
    }
    public void getscore(int value)
    {
        score += value;
    }
}
