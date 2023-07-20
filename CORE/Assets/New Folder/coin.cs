using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="coin",menuName ="MY/new coin")]
public class coin : ScriptableObject
{
    public string 名稱;
    public GameObject 物件;
    public int 數量;
}
