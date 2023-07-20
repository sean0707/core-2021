using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class newcout : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public coin coin;
    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = "" + coin.數量 + "";
    }
}
