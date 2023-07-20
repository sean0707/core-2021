using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class over : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            end();
        }

    }
    void end()
    {
        Application.Quit();
    }

}
