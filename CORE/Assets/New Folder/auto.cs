using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using System.Text;


public class auto : MonoBehaviour
{
    public int hp;
    public int ep;
    public int A;
    public int B;
    public int C;
    public int D;
    public static auto manager;
    public bool check;
    public GameObject player;
    public GameObject deta;
    public string levelName;
    // Start is called before the first frame update
    void Start()
    {
        if (manager == null)
        {
            manager = this;
        }
        if (savedata.check)
        {
            FileStream fs = new FileStream(Application.dataPath + "/save.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            levelName = sr.ReadLine();
            player.gameObject.transform.position = new Vector3(float.Parse(sr.ReadLine()), float.Parse(sr.ReadLine()), float.Parse(sr.ReadLine()));
            hp = int.Parse(sr.ReadLine());
            ep = int.Parse(sr.ReadLine());
            A = int.Parse(sr.ReadLine());
            B = int.Parse(sr.ReadLine());
            C = int.Parse(sr.ReadLine());
            D = int.Parse(sr.ReadLine());
            TMP.ctrl.m = (sr.ReadLine());
            TMP.ctrl.p = int.Parse(sr.ReadLine());
            TMP.ctrl.x = int.Parse(sr.ReadLine());
            TMP.ctrl.y = int.Parse(sr.ReadLine());
            TMP.ctrl.getscore(0);
            //deta.gameObject.transform.position = new Vector3(float.Parse(sr.ReadLine()), float.Parse(sr.ReadLine()), float.Parse(sr.ReadLine()));
            check = false;
        }
        else
        {
            levelName = "003";
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
