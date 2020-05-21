using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDictionary 
{
    public static bool GameOver = false;
    public static bool rotationPermission = false;
    public static bool rotationAsked = false;
    public static bool blockInputs = false;
    public static bool directionChoosed = false;
    public static int swipeDirection = 1;
    public static int playerSpeed = 1;
    public static List<string> aT_blocks = new List<string>();
    public static List<string> aM_blocks = new List<string>();
    public static List<string> aB_blocks = new List<string>();
    public static List<string> bM_blocks = new List<string>();
    public static List<string> bL_blocks = new List<string>();
    public static List<string> bR_blocks = new List<string>();

    public static GameObject Pos1;
    public static GameObject Pos2;
    public static GameObject Pos3;
    public static GameObject Pos4;
    public static GameObject Pos5;
    public static GameObject Pos6;
    public static GameObject Pos7;
    public static GameObject Pos8;
    public static GameObject Pos9;
    
}
