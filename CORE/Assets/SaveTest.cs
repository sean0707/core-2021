using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour 
{
    //存檔資料結構
    public SaveData data;
	// Use this for initialization
	void Start () {
        //讀取恢復資料
        data = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString("SaveData"));
        data.playerName = "NoName";
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Data Set");
           // data.level += 1;
           // data.money += 100;
            //Debug.Log(data.playerName + ":" + data.level + "/" + data.money);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("Data Save");
            Debug.Log(JsonUtility.ToJson(data));
            //儲存資料
            PlayerPrefs.SetString("SaveData", JsonUtility.ToJson(data));
        }
	}
}


