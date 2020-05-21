using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_aB : MonoBehaviour
{

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.gameObject.name.Contains("Block"))
            CubeDictionary.aB_blocks.Add(collisionInfo.collider.gameObject.name);
    }
    void OnCollisionExit(Collision collisionInfo)
    {
        CubeDictionary.aB_blocks.Remove(collisionInfo.collider.gameObject.name);
    }
}

