using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using TMPro;


public class TMP : MonoBehaviour
{
    public static TMP ctrl;
    // TextMeshPro Text;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI pt;
    public TextMeshProUGUI money;
    public bag bag;
    public coin coin;
    public string m;
    string Str;
    string Name;
    string[] strs;
    public int x;
    public int y;
    public int p;
    public int s;
    public bool clear;
    public GameObject effect;
    private void Awake()
    {
        ctrl = this;
    }
    void Start()

    {
        Text = gameObject.GetComponent<TextMeshProUGUI>();
        //   Name = "C";
        //   getscore(0);
    }


    void Update()
    {
        money.text = "$"+coin.數量;
        pt.text = "" + p;

        if (m == "b")
        {
            y = 1;
        }
        if (m == "a")
        {
            y = 2;
        }
        if (m == "c")
        {
            y = 1;
        }
        if (!clear)
        {
            if (x >= y)
            {
                //   clear = true;
                Invoke("Clear", 0);
                clear = true;
            }
            else
            {
                //  clear = false;
            }
        }
        if (quest.ctrl.Q && m != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                x = 0;
                Text.text = Resources.Load<TextAsset>(m).text + "(" + x + "/" + y + ")";
                clear = false;
            }


        }
    }
    void ReadFile(string Name)
    {
        strs = File.ReadAllLines(Name);
        for (int i = 0; i < strs.Length; i++)
        {
            Str += strs[i];
            Str += "\n";
        }
    }
    public void getscore(int value)
    {
        x += value;
        Text.text = Resources.Load<TextAsset>(m).text + "(" + x + "/" + y + ")";
    }
    void Clear()
    {
        if (m == "a")
        {
            exp.manager.getscore(100);
            p = p + s;
        }
        if (m == "b")
        {
            p = p + s;
            getcoin(100);
        }
        if (m == "c")
        {
            p = p + s;
            exp.manager.getscore(50);
            getcoin(150);
        }
        effect.gameObject.GetComponent<ParticleSystem>().Play();
       // x = 0;
        Text.text = Resources.Load<TextAsset>(m).text + "(" + x + "/" + y + ")";
    }
    public void getcoin(int value)
    {
        if (!bag.itemlist.Contains(coin))
        {
            bag.itemlist.Add(coin);
        }
            coin.數量 += value;
    }
}