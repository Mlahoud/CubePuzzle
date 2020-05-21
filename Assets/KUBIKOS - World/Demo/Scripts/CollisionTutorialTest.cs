
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollisionTutorialTest : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {
        CubeDictionary.aT_blocks.Add(collisionInfo.collider.gameObject.name);
    }
     
}
