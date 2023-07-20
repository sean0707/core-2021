using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RemoveTest();
    }




    public void RemoveTest()
    {
        List<Component> comList = new List<Component>();
        foreach (var component in gameObject.GetComponents<Component>())
        {
            comList.Add(component);
            print(component.GetType());
        }
        foreach (Component item in comList)
        {


            Destroy(item);
        }
    }
}
