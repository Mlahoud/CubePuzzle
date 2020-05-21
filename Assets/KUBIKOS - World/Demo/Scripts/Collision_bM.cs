using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_bM : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.gameObject.name.Contains("Block"))
            CubeDictionary.bM_blocks.Add(collisionInfo.collider.gameObject.name);
    }
     
    void OnCollisionExit(Collision collisionInfo)
    {
        CubeDictionary.bM_blocks.Remove(collisionInfo.collider.gameObject.name);
    }
}
