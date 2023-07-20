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

[AddComponentMenu("NGUI/Examples/Load Save")]
public class LoadSave : MonoBehaviour
{
    public string levelName;

    void OnClick()
    {
        if (!string.IsNullOrEmpty(levelName))
        {
#if UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2
			Application.LoadLevel(levelName);
#else
            FileStream fs = new FileStream(Application.dataPath + "/save.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            levelName = sr.ReadLine();
            UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
#endif
        }
    }

}
