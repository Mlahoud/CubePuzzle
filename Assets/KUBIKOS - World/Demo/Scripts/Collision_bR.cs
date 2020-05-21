using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_bR : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.gameObject.name.Contains("Block"))
            CubeDictionary.bR_blocks.Add(collisionInfo.collider.gameObject.name);
    }
     
    void OnCollisionExit(Collision collisionInfo)
    {
        CubeDictionary.bR_blocks.Remove(collisionInfo.collider.gameObject.name);
    }
}
