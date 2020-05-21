using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject LayerRotation;
    public GameObject CubeRotation;
    public GameObject Main;
    public Text timer;
    bool is_LR_Active = false;
    bool is_CR_Active = false;
    public Text Gstate;
    public float gameTimer;
    float g_time;
    public static bool gamePaused = false;
    float minutes, seconds;
    bool isStart = false;
    Text info;
    int playedTimes = 0;
    //public int time;
    private string state = "Pause";
    void Update(){
        if(isStart)
         if(!gamePaused)
         {
            gameTimer -= (Time.deltaTime);
            seconds = Mathf.Round(gameTimer); 
            minutes = Mathf.Floor(seconds/60); // minutes is the integer part of seconds/60
            if (minutes<10)
                timer.text = "0"+minutes.ToString();
            else
                timer.text = minutes.ToString();
            if (seconds>59)
                seconds = seconds%60;
            if (seconds<10)
                timer.text = timer.text + ":0" + seconds.ToString();
            else
                timer.text = timer.text + ":" + seconds.ToString();
            if (gameTimer < 0.0f)
            {
                timer.text = "00:00";
                info.text = "Game Over!";
                GameObject Player = GameObject.FindGameObjectWithTag("Player");
                Player.GetComponent<Animator>().Play("Death");
                Button btn_lyr = GameObject.Find("LayerRotation").GetComponent<Button>();
                btn_lyr.enabled = false;
                Button btn_rot = GameObject.Find("CubeRotation").GetComponent<Button>();
                btn_rot.enabled = false;
                Button btn_pause = GameObject.Find("Pause_Play").GetComponent<Button>();
                btn_pause.enabled = false;
                Main.SetActive(true);
                Text Level_text = GameObject.Find("Start_Retry").GetComponent<Text>();
                Level_text.text = "Retry";
                isStart = false;
            }
        }
    }

    void Start()
    {
        Main.SetActive(true);
        LayerRotation.SetActive(is_LR_Active) ;
        CubeRotation.SetActive(is_CR_Active) ;
        Button btn_lyr = GameObject.Find("LayerRotation").GetComponent<Button>();
        btn_lyr.enabled = false;
        Button btn_rot = GameObject.Find("CubeRotation").GetComponent<Button>();
        btn_rot.enabled = false;
        Button btn_pause = GameObject.Find("Pause_Play").GetComponent<Button>();
        btn_pause.enabled = false;
        g_time = gameTimer;
        info = GameObject.Find("InfoText").GetComponent<Text>();
        CubeDictionary.aT_blocks = new List<string>();
        CubeDictionary.aM_blocks = new List<string>();
        CubeDictionary.aB_blocks = new List<string>();
        CubeDictionary.bM_blocks = new List<string>();
        CubeDictionary.bL_blocks = new List<string>();
        CubeDictionary.bR_blocks = new List<string>();
    }

    public void ActivateLayerRotation(){
        if (!is_LR_Active){
            is_LR_Active = true;
            LayerRotation.SetActive(is_LR_Active) ;
            is_CR_Active = false;
            CubeRotation.SetActive(is_CR_Active) ; 
        }else{
            is_LR_Active = false;
            LayerRotation.SetActive(is_LR_Active) ; 
        }
    }
    public void CloseLayerRotation(){

            is_LR_Active = false;
            LayerRotation.SetActive(is_LR_Active) ; 

    }
    public void ActivateCubeRotation(){
        if (!is_CR_Active){
            is_CR_Active = true;
            CubeRotation.SetActive(is_CR_Active) ;
            is_LR_Active = false;
            LayerRotation.SetActive(is_LR_Active) ; 
        }else{
            is_CR_Active = false;
            CubeRotation.SetActive(is_CR_Active) ; 
        }
    }
    public void CloseCubesRotation(){

            is_CR_Active = false;
            CubeRotation.SetActive(is_CR_Active) ; 

    }
    public void pause_play(){
        Text b_state = Gstate;
        
        if(!gamePaused){
            gamePaused = !gamePaused;
            state = "Play";
            b_state.text = state;
        }
        else{
            gamePaused = !gamePaused;
            state = "Pause";
            b_state.text = state;
        }
    }
    public void start_game()
    {
        //Start counting
        if (playedTimes ==1)
            UnityEngine.SceneManagement.SceneManager.LoadScene("ProtoScene");
        else
        {
            playedTimes = 1;
        }
        isStart = true;
        Main.SetActive(false);
        gameTimer = g_time;
        info.text = "0 Route!";
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<Animator>().Play("Idle");
        Button btn_lyr = GameObject.Find("LayerRotation").GetComponent<Button>();
        btn_lyr.enabled = true;
        Button btn_rot = GameObject.Find("CubeRotation").GetComponent<Button>();
        btn_rot.enabled = true;
        Button btn_pause = GameObject.Find("Pause_Play").GetComponent<Button>();
        btn_pause.enabled = true;
        Main.SetActive(false);
        isStart = true;
    }
    public void quit_game()
    {
        //Quit game
        Application.Quit();
    }
}