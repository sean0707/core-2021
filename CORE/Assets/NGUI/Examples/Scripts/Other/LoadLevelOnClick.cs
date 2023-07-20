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

[AddComponentMenu("NGUI/Examples/Load Level On Click")]
public class LoadLevelOnClick : MonoBehaviour
{
	public string levelName;
  /*  [SerializeField]
    Text text;
    [SerializeField]
    PlayerData data;
    [System.Serializable]
    public class PlayerData
    {
        public string name;
        public int hp;
        public int exp;
        public GameObject gameObject;
        // public float X;
        //  public float Y;
        //   public float Z;
    }*/
    void OnClick ()
	{
		if (!string.IsNullOrEmpty(levelName))
		{
#if UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2
			Application.LoadLevel(levelName);
#else
			UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
#endif
		}
	}
    public void save()
    {
        /*   FileStream fs = new FileStream(Application.dataPath + "/save.txt", FileMode.Create);
           StreamWriter sw = new StreamWriter(fs);
           sw.WriteLine(data.name);
           sw.WriteLine(transform.position.x);
           sw.WriteLine(transform.position.y);
           sw.WriteLine(transform.position.z);
           sw.WriteLine(data.hp);
           sw.WriteLine(data.exp);
           sw.WriteLine(11);
           sw.WriteLine(11);
           sw.WriteLine(11);
           sw.Close();
           fs.Close();*/
        savedata.check = true;
    }
    public void start()
    {
        savedata.check = false;
    }
}
