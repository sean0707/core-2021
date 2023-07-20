using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//考題類型1：請寫一個可以儲存HP的整數簡單類型
//考題類型2：請寫一個可以儲存時間的浮點數簡單類型
//考題類型3：請寫一個可以儲存角色是否死亡的布林值簡單類型
//考題類型4：請寫一個可以儲存玩家姓名的字串簡單類型
//考題類型5：請寫出簡單類型運算後最後的結果(出考題請同學用寫的)
//考題類型6：請寫一個可以儲存武器類型的列舉型別，宣告並賦值

//寫程式的時候，請預設要接你程式的是一個知道你地址的變態殺人魔

//如何問問題
//1. 請以"沒人欠你，你也沒欠別人"的態度問問題、互動
//2. 人不是全知全能的，"理性的"人都是用手邊既有的資訊來做判斷和分析
//3. 當要問問題的時候，請先整理出你手邊既有的可以使用的資訊(條列式)，和要處理妳問題的人開誠布公的提供資訊
//4. "讓子彈飛一會"
//5. 定下一個討論或追蹤回覆時間
//6. 確認是不是處理完問題或了解吸收
//7. 整理(文字記錄、思考)

//記得存檔

enum weapon
{ 
    sword,
    ward,
    shield,
}

public class GameData : MonoBehaviour
{
    #region 簡單類型
    //關鍵字+空格+你想要關鍵字的名稱+;(分號)(請習慣用英文)= 宣告
    //沒有賦直直接存取會導致錯誤
    //C++ 指標->指標的指標->指標的指標的指標、函式指標
    //c#手動分配記憶體的概念->自動處理
    public int HP;
    //關鍵字+空格+你想要關鍵字的名稱(請習慣用英文)+=+想要賦予的值+;(分號) = 宣告並賦值
    //C#等號的左右類型要一樣，不然容易出問題
    //C#在宣告的時候就要定義類型
    public float time = 0.5f;
    public bool isDead = false;
    public string playerName = "煞氣的嘉明 ";

    weapon playerWeapon = weapon.sword;
    weapon playerleftHandWeapon = weapon.shield;
    //因為這樣的顯示不直覺，除BUG會有困難 int weapontype = 1;
    #endregion

    #region NGUI整合簡單類型
    //UILabel 選單NGUI->Create->Label
    //能夠正常顯示(看不到是因為沒有)
    //public +空格+關鍵字+空格+你想要關鍵字的名稱+;(分號)(請習慣用英文)= 宣告 UNITY會在inspector顯示關鍵字的物件
    //賦值方式 1. 直接在UNITY中拉取(父)物件到inspector顯示關鍵字的物件上  2. 在程式中動態的直接尋找
    public UILabel HPValue;
    //打中文字沒辦法顯示是因為FONT(字型不支援)Arial有支援

    //血量條
    public UISlider HPSlider;

    //圖片物件更換1
    public UISprite PlayerSprite;

    //圖片物件更換2
    public Texture tex01;
    public UITexture mywifeTexture;
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        #region 簡單類型
        int HPMax;
        //賦值
        HP = 100;
        //簡單類型做加減運算
        //運算式，運算子
        //程式會先計算等號右邊的結果，然後把結果丟到等號左邊類型裡面
        //HP = HP - 100;
        //=
        //HP -= 100;

        //HP = HP - 1;
        //=
        //HP--;
        //=
        //HP -= 1;

        //HP = HP + 1;
        //=
        //HP++;
        //=
        //HP += 1;

        //HP = HP * 2;

        //除會比較特別，因為分子整數除的話會有一些數值的例外狀況 分子和分母的簡單類型的差異
        time = 100f / 101f;

        //Debug.Log(time.ToString());

        //playerName = "煞氣的耕倫";
        //playerName = "煞氣的耕倫" + "&" + "煞氣的腐肉";
        //Debug.Log(playerName);
        //Debug.Log(playerName.Replace("煞氣的", ""));
        //Debug.Log(playerName);
        //string weakername = playerName.Replace("煞氣的", "");
        //Debug.Log(weakername);
        isDead = true;
        GameData data = new GameData();

        playerleftHandWeapon = weapon.ward;

        #endregion
        //在程式中動態的直接尋找 賦值
        #region NGUI整合簡單類型
        //HPValue = GameObject.Find("UI Root/Label").GetComponent<UILabel>();
        //去找UILabel的關鍵字 + .text + = + string 關鍵字
        //HPValue.text = playerName;
        //數字要怎麼辦? 先把數字轉成文字 -> 類型關鍵字 + .ToString();
        //要動態更新要寫在Update()函式內
        //HPValue.text = HP.ToString();

        //開啟Example 0 - Control Widgets
        //找到Control - Colored Progress Bar的預製物
        //UISprite可以改變背景和前景

        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        //作用域
        //HPValue.text = time.ToString();
        HPValue.text = isDead.ToString();
        //去找HPSlider的關鍵字 + .value + = + 浮點數
        HPSlider.value = time;

        //去找UISprite的關鍵字 + .spriteName + = + 字串
        PlayerSprite.spriteName = "Button Y";

        //去找UITexture的關鍵字 + .mainTexture + = + Texture
        mywifeTexture.mainTexture = tex01;
    }
}
