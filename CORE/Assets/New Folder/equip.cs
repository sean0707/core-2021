using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "equip", menuName = "MY/new equip")]
public class equip : ScriptableObject
{
    public string 名稱;
    public Sprite 圖示;
    public int 數量;
    public GameObject 物件;
    public int atk;
    public int def;
    public int spd;
}
