using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool <A> where A : MonoBehaviour
{
    public Queue<A> Q;
    public GameObject B;
    private static pool<A> ssd = null;
    public static pool<A> Instance
    {
        get {
            if (ssd == null)
             {
                ssd = new pool<A>();
             }
            return ssd;
           }
    }
    public int queueCount
    {
        get
        {
            return Q.Count;
        }
    }
    public void initpool(GameObject D)
    {
        B = D;
        Q = new Queue<A>();
    }
    public A Spawn(Vector3 position, Quaternion quaternion, Transform parent)
    {
        if (B == null)
        {
            return default(A);
        }
        if (queueCount <= 0)
        {
            GameObject g = Object.Instantiate(B, position, quaternion, parent);
            A t = g.GetComponent<A>();
            if (t == null)
            {
                return default(A);
            }
            Q.Enqueue(t);
        }
        A obj = Q.Dequeue();
        obj.gameObject.transform.position = position;
        obj.gameObject.transform.rotation = quaternion;
        obj.gameObject.transform.parent = parent;
        obj.gameObject.SetActive(true);
        return obj;
    }
    public void Recycle(A obj)
    {
        Q.Enqueue(obj);
        obj.gameObject.SetActive(false);
    }
}
