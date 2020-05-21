using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_aM : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.gameObject.name.Contains("Block"))
            CubeDictionary.aM_blocks.Add(collisionInfo.collider.gameObject.name);
    }
     
    void OnCollisionExit(Collision collisionInfo)
    {
        CubeDictionary.aM_blocks.Remove(collisionInfo.collider.gameObject.name);
    }
}
