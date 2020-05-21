using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_bL : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.gameObject.name.Contains("Block"))
            CubeDictionary.bL_blocks.Add(collisionInfo.collider.gameObject.name);
    }
     
    void OnCollisionExit(Collision collisionInfo)
    {
        CubeDictionary.bL_blocks.Remove(collisionInfo.collider.gameObject.name);
    }
}
