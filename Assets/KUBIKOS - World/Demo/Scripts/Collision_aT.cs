using System.Collections;
using UnityEngine;

public class Collision_aT : MonoBehaviour
{
    GameObject go;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.gameObject.name.Contains("Block"))
            CubeDictionary.aT_blocks.Add(collisionInfo.collider.name);
    }
     
    void OnCollisionExit(Collision collisionInfo)
    {
        CubeDictionary.aT_blocks.Remove(collisionInfo.collider.gameObject.name);
    }
}
