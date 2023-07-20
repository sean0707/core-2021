using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "bag", menuName = "MY/new bag")]
public class bag : ScriptableObject
{
    public List<coin> itemlist = new List<coin>();
    public List<equip> equiplist = new List<equip>();
}
