using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class talk : MonoBehaviour
{
    public deta script5;
    public GameObject c;
    public TextMeshProUGUI label;
    public TextAsset a;
    public int index;
    List<string> textlist = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        //gettext(a);
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if (!quest.ctrl.Q | script5.x)
            {
                c.GetComponent<CanvasGroup>().alpha = 0;
            }
            else
            {
                c.GetComponent<CanvasGroup>().alpha = 0.7f;
                label.text = textlist[index];
                index++;
                if (index == textlist.Count)
                {
                    index = 0;
                }
            }
        }

    }
    public void gettext(TextAsset file)
    {
        if (a != file)
        {
            a = file;
            textlist.Clear();
            index = 0;
        }
        var linedata = file.text.Split('\n');
        foreach (var line in linedata)
        {
            textlist.Add(line);
        }
    }
}