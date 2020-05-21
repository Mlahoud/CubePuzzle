using UnityEngine;
using System.Collections.Generic;
using System.Reflection;

public class InputHelper : MonoBehaviour
{

Vector2 firstPressPos = new Vector2{};
Vector2 secondPressPos = new Vector2{};
Vector2 currentSwipe = new Vector2{};
public void Swipe()
{

     if(Input.GetMouseButtonDown(1))
     {
         //save began touch 2d point
        firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
     }
     if(Input.GetMouseButtonUp(1))
     {
            //save ended touch 2d point
        secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
       
            //create vector from the two points
        currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
           
        //normalize the 2d vector
        currentSwipe.Normalize();
 
        //swipe upwards
        if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
        {
            //Debug.Log("up swipe");
            CubeRotation.swipeDirection = -1;
            CubeDictionary.directionChoosed = true;
        }
        //swipe down
        if(currentSwipe.y < 0 &&  currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
        {
            //Debug.Log("down swipe");
            CubeRotation.swipeDirection = 1;
            CubeDictionary.directionChoosed = true;
        }
        //swipe left
        if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
        {
            //Debug.Log("left swipe");
            if (!CubeRotation.isRotated)
                LayerRotation.swipeDirection = 1;
            else
                LayerRotation.swipeDirection = -1;   
            CubeDictionary.directionChoosed = true;
        }
        //swipe right
        if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
        {
            //Debug.Log("right swipe");
            if (!CubeRotation.isRotated)
                LayerRotation.swipeDirection = -1;
            else
                LayerRotation.swipeDirection = 1;       
            CubeDictionary.directionChoosed = true;
        }
    }
}
void Update()
    {   
        
        if (CubeDictionary.rotationAsked)
        {
            CubeDictionary.rotationPermission = true;
            Swipe();
        }
    }
}
