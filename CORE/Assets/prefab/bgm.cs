using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm : MonoBehaviour
{
    public float D = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, D);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
