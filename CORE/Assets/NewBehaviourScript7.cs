using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript7 : MonoBehaviour
{
    public SkinnedMeshRenderer meshRenderer;
    public MeshCollider coll;
    void Start()
    {

    }
    void Update()
    {
        for (int i = 0; i < 1; i++)
        {
            Mesh colliderMesh = new Mesh();
            meshRenderer.BakeMesh(colliderMesh); //更新mesh
            coll.sharedMesh = null;
            coll.sharedMesh = colliderMesh; //将新的mesh赋给meshcollider
        }

    }
}
