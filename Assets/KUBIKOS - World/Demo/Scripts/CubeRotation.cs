using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CubeRotation : MonoBehaviour
{
    // Rotation speed for layers
    public float Speed = 0.0f;
    public GameObject parent;
    void Rotate(float Speed){
        transform.Rotate(Speed,Speed,Speed);
    }
    //public GameObject objectToRotate; it depends on the clicked button
    private bool rotating ;
    public static int swipeDirection;//swipe direction
    public static bool isRotated = false;
    
    private IEnumerator Rotate( Vector3 angles, float duration, GameObject objectToRotate )
    {
        rotating = true ;
        Quaternion startRotation = objectToRotate.transform.localRotation ;
        Quaternion endRotation = Quaternion.Euler( angles ) * startRotation ;

        for( float t = 0 ; t < duration ; t+= Time.deltaTime )
        {
            objectToRotate.transform.rotation = Quaternion.Lerp( startRotation, endRotation, t / duration ) ;
            //objectToRotate.transform.localRotation = Quaternion.Lerp( startRotation,endRotation,t / duration);
            yield return null;
        }
        objectToRotate.transform.localRotation = endRotation  ;
        rotating = false;
    }
    
    public void StartRotation(GameObject objectToRotate, int dir, int orientation = 0)
    {
        // dir =  1        -> positive direction
        // dir = -1        -> negative direction
        // orientation = 0 -> horizontal
        // orientation = 1 -> vertical
        if( !rotating )
        {
            if (orientation == 0)
                StartCoroutine( Rotate( new Vector3(-dir*180,0,0), Speed, objectToRotate ) ) ;
            if (orientation == 1)
                StartCoroutine( Rotate( new Vector3(0, -dir*180,0), Speed, objectToRotate ) ) ;
        
        }
    }
    public void OnButtonClick()
    {
        var go = EventSystem.current.currentSelectedGameObject;
        CubeDictionary.rotationAsked = true;
        Text info = GameObject.Find("InfoText").GetComponent<Text>();
        info.text = "Swipe!";
        blockInputs();
        if (go != null)
        {
            //Depending on the clicked button...
            switch (go.name)
            {
                case "X":
                    //Rotate in the X direction
                    StartCoroutine(OnSwipeEvent(parent));
                    if (!isRotated)
                        isRotated = true;
                    else
                        isRotated = false;
                    //StartRotation(parent,1);
                break;
                case "Y":
                    //rotate in Y direction
                    StartCoroutine(OnSwipeEvent(parent,1));
                    //StartRotation(parent,1,1);
                break;
            }
        }
        else
            Debug.Log("currentSelectedGameObject is null");
    }
    void blockInputs(){
        
        Button Layer_Rotation = GameObject.Find("LayerRotation").GetComponent<Button>();
        Button Cube_RotatioPU = GameObject.Find("CubeRotation").GetComponent<Button>();

        Layer_Rotation.enabled = (false);
        Cube_RotatioPU.enabled = (false);
    }
    void releaseInputs(){
        
        Button Layer_Rotation = GameObject.Find("LayerRotation").GetComponent<Button>();
        Button Cube_RotatioPU = GameObject.Find("CubeRotation").GetComponent<Button>();

        Layer_Rotation.enabled = (true);
        Cube_RotatioPU.enabled = (true);
    }
    IEnumerator OnSwipeEvent(GameObject layers, int orientation = 0)
    {
        //Waiting for swipe...
        yield return new WaitUntil(() => CubeDictionary.rotationPermission);
        yield return new WaitUntil(() => CubeDictionary.directionChoosed);
        
        StartRotation(layers,swipeDirection, orientation);
        releaseInputs();
        //Phone was swiped!
        CubeDictionary.rotationPermission = false;
        CubeDictionary.rotationAsked = false;
        CubeDictionary.directionChoosed = false;
        
        Text info = GameObject.Find("InfoText").GetComponent<Text>();
        info.text = "0 Route!";
    }
}
