using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    private Vector2 fp;   //First touch position
    private Vector2 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
 
    void Start()
    {
        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
    }
 
    void Update()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0);      // get the touch
             // get the click
            if (touch.phase == TouchPhase.Began)  //check for the first touch or first click
            {
                if (touch.phase == TouchPhase.Began){
                    fp = touch.position;
                    lp = touch.position;
                }
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                if (touch.phase == TouchPhase.Ended)
                    lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                if (CubeDictionary.rotationAsked)
                {
                        CubeDictionary.rotationPermission = true;
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            if (!CubeRotation.isRotated)
                                LayerRotation.swipeDirection = -1;
                            else
                                LayerRotation.swipeDirection = 1;
                            CubeDictionary.directionChoosed = true;
                        }
                        else
                        {   //Left swipe
                            if (!CubeRotation.isRotated)
                                LayerRotation.swipeDirection = 1;
                            else
                                LayerRotation.swipeDirection = -1;   
                            CubeDictionary.directionChoosed = true;
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            Debug.Log("Up Swipe");
                            CubeRotation.swipeDirection = -1;
                            CubeDictionary.directionChoosed = true;
                        }
                        else
                        {   //Down swipe
                            Debug.Log("Down Swipe");
                            CubeRotation.swipeDirection = 1;
                            CubeDictionary.directionChoosed = true;
                        }
                    }
                    //CubeDictionary.rotationPermission = false;}
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }
        }
    }
}
}