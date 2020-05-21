using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class LayerRotation : MonoBehaviour
{
    // Rotation speed for layers
    public float Speed = 0.0f;
    public Transform parent;
    void Rotate(float Speed){
        transform.Rotate(Speed,Speed,Speed);
    }
    //public GameObject objectToRotate; it depends on the clicked button
    public GameObject aT;
    public GameObject aM;
    public GameObject aB;
    public GameObject bL;
    public GameObject bM;
    public GameObject bR;
    public Material std_path;
    public Material fnd_path;
    private bool rotating ;
    GameObject Pos1;
    GameObject Pos2;
    GameObject Pos3;
    GameObject Pos4;
    GameObject Pos5;
    GameObject Pos6;
    GameObject Pos7;
    GameObject Pos8;
    GameObject Pos9;
    bool isPath = false;
    public GameObject pathCanvas;
    public GameObject HighLight_aT;
    public GameObject HighLight_aM;
    public GameObject HighLight_aB;
    public GameObject HighLight_bR;
    public GameObject HighLight_bM;
    public GameObject HighLight_bL;
    //public GameObject Arrow_aT;
    //public GameObject Arrow_aM;
    //public GameObject Arrow_aB;
    //public GameObject Arrow_bR;
    //public GameObject Arrow_bM;
    //public GameObject Arrow_bL;
    public static int swipeDirection;//swipe direction
    private IEnumerator Rotate( Vector3 angles, float duration, GameObject objectToRotate )
    {
        rotating = true ;
        Quaternion startRotation = objectToRotate.transform.localRotation ;
        Quaternion endRotation = Quaternion.Euler( angles ) * startRotation ;

        for( float t = 0 ; t < duration ; t+= Time.deltaTime )
        {
            //objectToRotate.transform.rotation = Quaternion.Lerp( startRotation, endRotation, t / duration ) ;
            objectToRotate.transform.localRotation = Quaternion.Lerp( startRotation,endRotation,t / duration);
            yield return null;
        }
        objectToRotate.transform.localRotation = endRotation  ;
        rotating = false;
    }
    
    public void StartRotation(GameObject objectToRotate, int dir = 1, int orientation = 0)
    {
        // dir =  1        -> positive direction depends on swipe
        // dir = -1        -> negative direction depends on swipe
        // orientation = 0 -> horizontal
        // orientation = 1 -> vertical
        if( !rotating )
        {
            if (orientation == 0)
                StartCoroutine( Rotate( new Vector3(0, dir*90, 0), Speed, objectToRotate ) ) ;
            if (orientation == 1)
                StartCoroutine( Rotate( new Vector3(0, 0, -dir*90), Speed, objectToRotate ) ) ;
        }
    }
    public void group_aT_Blocks()
    {
        foreach(string element in CubeDictionary.aT_blocks)
        {
            //print(element);
            var block = GameObject.Find(element);
            block.transform.SetParent(aT.transform);
        }
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
    public void OnButtonClick()
    {
        var go = EventSystem.current.currentSelectedGameObject;
        CubeDictionary.rotationAsked = true;
        Text info = GameObject.Find("InfoText").GetComponent<Text>();
        info.text = "Swipe!";
        blockInputs();
        if (go != null)
        {
            //Depending on the selected button...
            switch (go.name)
            {
                case "aT":
                    //first put all blocks in corresponding parent
                    foreach(string element in CubeDictionary.aT_blocks)
                    {
                        var block = GameObject.Find(element);
                        block.transform.SetParent(aT.transform);
                    }
                    //rotate parent
                    HighLight_aT.GetComponent<MeshRenderer>().enabled = true;
                    //Arrow_aT.GetComponent<MeshRenderer>().enabled = true;
                    CubeDictionary.blockInputs = true;
                    StartCoroutine(OnSwipeEvent(aT));
                    //StartRotation(aT,1);
                break;
                case "aM":
                    //first put all blocks in corresponding parent
                    foreach(string element in CubeDictionary.aM_blocks)
                    {
                        var block = GameObject.Find(element);
                        block.transform.SetParent(aM.transform);
                    }
                    //rotate parent
                    HighLight_aM.GetComponent<MeshRenderer>().enabled = true;
                    //Arrow_aM.GetComponent<MeshRenderer>().enabled = true;
                    CubeDictionary.blockInputs = true;
                    StartCoroutine(OnSwipeEvent(aM));
                break;
                case "aB":
                    //first put all blocks in corresponding parent
                    foreach(string element in CubeDictionary.aB_blocks)
                    {
                        var block = GameObject.Find(element);
                        block.transform.SetParent(aB.transform);
                    }
                    //rotate parent
                    HighLight_aB.GetComponent<MeshRenderer>().enabled = true;
                    //Arrow_aB.GetComponent<MeshRenderer>().enabled = true;
                    CubeDictionary.blockInputs = true;
                    StartCoroutine(OnSwipeEvent(aB));
                break;
                case "bL":
                    //first put all blocks in corresponding parent
                    foreach(string element in CubeDictionary.bL_blocks)
                    {
                        var block = GameObject.Find(element);
                        block.transform.SetParent(bL.transform);
                    }
                    //rotate parent
                    HighLight_bL.GetComponent<MeshRenderer>().enabled = true;
                    //Arrow_bL.GetComponent<MeshRenderer>().enabled = true;
                    CubeDictionary.blockInputs = true;
                    StartCoroutine(OnSwipeEvent(bL,1));
                break;
                case "bM":
                    //first put all blocks in corresponding parent
                    foreach(string element in CubeDictionary.bM_blocks)
                    {
                        var block = GameObject.Find(element);
                        block.transform.SetParent(bM.transform);
                    }
                    //rotate parent
                    HighLight_bM.GetComponent<MeshRenderer>().enabled = true;
                    //Arrow_bM.GetComponent<MeshRenderer>().enabled = true;
                    CubeDictionary.blockInputs = true;
                    StartCoroutine(OnSwipeEvent(bM,1));
                break;
                case "bR":
                    //first put all blocks in corresponding parent
                    foreach(string element in CubeDictionary.bR_blocks)
                    {
                        var block = GameObject.Find(element);
                        block.transform.SetParent(bR.transform);
                    }
                    //rotate parent
                    HighLight_bR.GetComponent<MeshRenderer>().enabled = true;
                    //Arrow_bR.GetComponent<MeshRenderer>().enabled = true;
                    CubeDictionary.blockInputs = true;
                    StartCoroutine(OnSwipeEvent(bR,1));
                break;
                } 
                ReturnNormalColor();
        }
        else
            Debug.Log("currentSelectedGameObject is null");
    }
    //--------------------------------------------------------------
    //// For finding GameObjects on the face 1
    public List<float> y_pos;   //y position of the GameObject
    float xmax = 0;             //x max position of child
    float ymax = 0;             //y max position of child
    float zmax = 0;             //z max position of child
    GameObject top;             //top GameObject
    public void FindFace1_Objects()
    {     
       foreach(string element in CubeDictionary.aT_blocks)
        {
            var block = GameObject.Find(element);

            foreach (Transform child in block.transform)
            {
                y_pos.Add(child.position.y);
                get_ymax(y_pos,child.gameObject);//gets child with highest y value
            }
            //print(block.name);                                      //block element
            //print("position is: "+ xmax+ " ; "+ ymax+" ; "+zmax);   //max y position <--- not usefull in future
            //print("top gameobject is: " + top);                     //top obstacle/path/goal/player
            y_pos.Clear();
            ymax = 0;
            savePositions(top);
        }
    }
    void get_ymax(List<float> y_pos,GameObject go)
    {
        for (int i = 0; i < y_pos.Count; i++){
            if (y_pos[i] > ymax){
                ymax = y_pos[i];
                xmax = go.transform.position.x;
                zmax = go.transform.position.z;
                top = go;
            }
        }
    }
    void savePositions(GameObject go)
    {
        //Save the position of the top elements
        //This should help to create de path from character to goal
        //passing through path elements.
        if (go.transform.position.x < - 0.5 && go.transform.position.z < -0.5)
            Pos1 = go;
        if ((go.transform.position.x > -0.5 && go.transform.position.x < 0.5) && go.transform.position.z <-0.5)
            Pos2 = go;
        if (go.transform.position.x > 0.5 && go.transform.position.z < -0.5)
            Pos3 = go;

        if (go.transform.position.x < - 0.5 && (go.transform.position.z > -0.5 && go.transform.position.z < 0.5))
            Pos4 = go;
        if ((go.transform.position.x > -0.5 && go.transform.position.x < 0.5) && (go.transform.position.z > -0.5 && go.transform.position.z < 0.5))
            Pos5 = go;
        if (go.transform.position.x > 0.5 && (go.transform.position.z > -0.5 && go.transform.position.z < 0.5))
            Pos6 = go;

        if (go.transform.position.x < - 0.5 && go.transform.position.z > 0.5)
            Pos7 = go;
        if ((go.transform.position.x > -0.5 && go.transform.position.x < 0.5) && go.transform.position.z > 0.5)
            Pos8 = go;
        if (go.transform.position.x > 0.5 && go.transform.position.z > 0.5)
            Pos9 = go;
        
    }
    Renderer rend1;
    Renderer rend2;
    Renderer rend3;
    Renderer rend4;
    Renderer rend5;
    Renderer rend6;
    void Start()
    {
        HighLight_aT = GameObject.Find("aT_highlight");
        HighLight_aM = GameObject.Find("aM_highlight");
        HighLight_aB = GameObject.Find("aB_highlight");
        HighLight_bL = GameObject.Find("bL_highlight");
        HighLight_bM = GameObject.Find("bM_highlight");
        HighLight_bR = GameObject.Find("bR_highlight");
        //Arrow_aT = GameObject.Find("aT_arrow");
        //Arrow_aM = GameObject.Find("aM_arrow");
        //Arrow_aB = GameObject.Find("aB_arrow");
        //Arrow_bL = GameObject.Find("bL_arrow");
        //Arrow_bM = GameObject.Find("bM_arrow");
        //Arrow_bR = GameObject.Find("bR_arrow");
        rend1 = HighLight_aT.GetComponent<Renderer>();
        rend2 = HighLight_aM.GetComponent<Renderer>();
        rend3 = HighLight_aB.GetComponent<Renderer>();
        rend4 = HighLight_bL.GetComponent<Renderer>();
        rend5 = HighLight_bM.GetComponent<Renderer>();
        rend6 = HighLight_bR.GetComponent<Renderer>();
        //rend7 = Arrow_aT.GetComponent<Renderer> ();
        //rend8 = Arrow_aM.GetComponent<Renderer>();
        //rend9 = Arrow_aB.GetComponent<Renderer>();
        //rend10 = Arrow_bR.GetComponent<Renderer>();
        //rend11 = Arrow_bL.GetComponent<Renderer>();
        //rend12 = Arrow_bM.GetComponent<Renderer>();
        //rend.material.shader = Shader.Find("_EmissionColor");
        pathCanvas.SetActive(isActive);
        StartCoroutine(LateStart(0.5f));
    }
    void Update ()
    {
 
        float emission = Mathf.PingPong (Time.time*2, 1.0f);
        Color baseColor = rend1.material.color;
        Color finalColor = baseColor * Mathf.LinearToGammaSpace (emission);
        rend1.material.SetColor ("_EmissionColor", finalColor);
        rend2.material.SetColor ("_EmissionColor", finalColor);
        rend3.material.SetColor ("_EmissionColor", finalColor);
        rend4.material.SetColor ("_EmissionColor", finalColor);
        rend5.material.SetColor ("_EmissionColor", finalColor);
        rend6.material.SetColor ("_EmissionColor", finalColor);
    }
    List<int> path = new List<int> {};
     IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        FindFace1_Objects();
        LookForStartPos();
        LookForGoalPos();
        //ReturnNormalColor();
        SearchPath(StartPos,  GoalPos, out path);
    }
    //---------------------------------------------------
    //Code for pathfinding
    
    int StartPos;
    int GoalPos;
    List<List<int>> childs = new List<List<int>>{};
    List<List<int>> initChilds(){
        List<int> child1 = new List<int> {2,4};
        List<int> child2 = new List<int> {1,3,5};
        List<int> child3 = new List<int> {2,6};
        List<int> child4 = new List<int> {1,5,7};
        List<int> child5 = new List<int> {2,4,6,8};
        List<int> child6 = new List<int> {3,5,9};
        List<int> child7 = new List<int> {4,8};
        List<int> child8 = new List<int> {5,7,9};
        List<int> child9 = new List<int> {6,8};
        
        return childs = new List<List<int>>  {child1, child2, child3, child4, child5, child6, child7, child8, child9};
    }
    
    void RemoveUsedChildren(int children, List<List<int>> childs)
    {
        //initChilds();
        //print("removed: "+children);
        foreach(List<int> element in childs){
            element.Remove(children);
        }
    }
    public void SearchPath(int StartPos,  int GoalPos, out List<int> path )
    {
        List<List<int>> childs = initChilds();
        RemoveChildrenWithObstacles(childs);
        path = new List<int> {};
        findpaths(childs,StartPos,GoalPos,4, out path);
        if (path.Count > 0)
        {
            ChangeColorPath(path);
            isActive = true;
            pathCanvas.SetActive(isActive);
            PathCanvasManager(path);
            Text info = GameObject.Find("InfoText").GetComponent<Text>();
            info.text = "1 Route!";
        }
        else
        {
            isActive = false;
            pathCanvas.SetActive(isActive);
            Text info = GameObject.Find("InfoText").GetComponent<Text>();
            info.text = "0 Route!";
        }
    }
    public void LookForStartPos(){
        bool changed = false;
        List<GameObject> TopFaces = new List<GameObject> {Pos1,
                                                          Pos2,
                                                          Pos3,
                                                          Pos4,
                                                          Pos5,
                                                          Pos6,
                                                          Pos7,
                                                          Pos8,
                                                          Pos9};
        
        for(int i = 0; i < 9; i++)
        {
            if (TopFaces[i].tag == "Player"){
                changed = true;
                StartPos = i+1;
            }
        }
        if (!changed)
            StartPos = 0;
    }
    public void LookForGoalPos(){
        bool changed = false;
        List<GameObject> TopFaces = new List<GameObject> {Pos1,
                                                          Pos2,
                                                          Pos3,
                                                          Pos4,
                                                          Pos5,
                                                          Pos6,
                                                          Pos7,
                                                          Pos8,
                                                          Pos9};
        
        for(int i = 0; i < 9; i++)
        {
            if (TopFaces[i].tag == "Goal"){
                changed = true;
                GoalPos = i+1;
            }
        }
        if (!changed)
            GoalPos = 0;
    }

    public void RemoveChildrenWithObstacles(List<List<int>> childs)
    {
        List<GameObject> TopFaces = new List<GameObject> {Pos1,
                                                          Pos2,
                                                          Pos3,
                                                          Pos4,
                                                          Pos5,
                                                          Pos6,
                                                          Pos7,
                                                          Pos8,
                                                          Pos9};
        for(int i = 0; i < 9; i++)
        {
            if (TopFaces[i].tag == "Obstacle"){
                RemoveUsedChildren(i+1,childs);
            }
        }
    }
    public void ChangeColorPath(List<int> path){
        List<GameObject> TopFaces = new List<GameObject> {Pos1,
                                                          Pos2,
                                                          Pos3,
                                                          Pos4,
                                                          Pos5,
                                                          Pos6,
                                                          Pos7,
                                                          Pos8,
                                                          Pos9};
        for(int i = 0; i < path.Count; i++)
        {
            if (TopFaces[path[i]-1].gameObject.tag=="Path")
            {
                TopFaces[path[i]-1].GetComponent<Renderer>().material = fnd_path;
            }
        }
    }
    public void ReturnNormalColor(){
        GameObject[] paths = GameObject.FindGameObjectsWithTag("Path");
        foreach( GameObject path in paths)
        {
            path.GetComponent<Renderer>().material = std_path;
        }
    }
    bool isActive = false;
    void PathCanvasManager(List<int> path)
    {
        for (int i = 1; i < 10; i++)
        {
            Image images = GameObject.Find("Image_"+i).GetComponent<Image>();
            images.color = Color.blue;
        }
        for (int i = 0; i < path.Count; i++)
        {
            Image images = GameObject.Find("Image_"+path[i]).GetComponent<Image>();
            images.color = Color.green;
        }
    }
    //================================================================
    List<int> savepath(List<int> path) 
    { 
        int size = path.Count; 
        List<int> Path = new List<int> {};
        for (int i = 0; i < size; i++)  
            Path.Add(path[i]);   
        return Path; 
    }
    bool isNotVisited(int x, List<int> path)
    {
    int size = path.Count;
    for (int i = 0; i < size; i++)
        if (path[i] == x)  
            return false;
    return true;
    }
    void findpaths(List<List<int>> g, int src, int dst, int v, out List<int> Path)
    { 
    // create a queue which stores 
    // the paths 
    Queue<List<int>> q = new Queue<List<int>> {}; 
    Path = new List<int> {}; 
    // path vector to store the current path 
    List<int>path = new List<int> {}; 
    
    path.Add(src); 
    q.Enqueue(path); 
        while (q.Count > 0) 
        { 
            path = q.Dequeue();
            int last = path[path.Count - 1]; 

            if (last == dst)
                {
                    Path = savepath(path);
                    break;
                }    
            // traverse to all the nodes connected to  
            // current vertex and push new path to queue 
            for (int i = 0; i < g[last-1].Count; i++) 
            { 
                if (isNotVisited(g[last-1][i], path)) 
                { 
                    List<int> newpath = new List<int>(path); 
                    newpath.Add(g[last-1][i]); 
                    q.Enqueue(newpath); 
                }
            }
        }
    } 
    IEnumerator OnSwipeEvent(GameObject layers, int orientation = 0)
    {
        //Waiting for swipe...
        yield return new WaitUntil(() => CubeDictionary.rotationPermission);
        yield return new WaitUntil(() => CubeDictionary.directionChoosed);
        
        StartRotation(layers,swipeDirection, orientation);
        StartCoroutine(LateStart(0.5f));
        releaseInputs();
        //Phone was swiped!
        CubeDictionary.rotationPermission = false;
        CubeDictionary.rotationAsked = false;
        CubeDictionary.directionChoosed = false;
        HighLight_aT.GetComponent<MeshRenderer>().enabled = false;
        HighLight_aM.GetComponent<MeshRenderer>().enabled = false;
        HighLight_aB.GetComponent<MeshRenderer>().enabled = false;
        HighLight_bL.GetComponent<MeshRenderer>().enabled = false;
        HighLight_bM.GetComponent<MeshRenderer>().enabled = false;
        HighLight_bR.GetComponent<MeshRenderer>().enabled = false;
        //Arrow_aT.GetComponent<MeshRenderer>().enabled = false;
        //Arrow_aM.GetComponent<MeshRenderer>().enabled = false;
        //Arrow_aB.GetComponent<MeshRenderer>().enabled = false;
        //Arrow_bL.GetComponent<MeshRenderer>().enabled = false;
        //Arrow_bM.GetComponent<MeshRenderer>().enabled = false;
        //Arrow_bR.GetComponent<MeshRenderer>().enabled = false;
    }
    public void btn_go()
    {
        List<GameObject> TopFaces = new List<GameObject> {Pos1,
                                                          Pos2,
                                                          Pos3,
                                                          Pos4,
                                                          Pos5,
                                                          Pos6,
                                                          Pos7,
                                                          Pos8,
                                                          Pos9};
        CanvasManager.gamePaused = true;
        GameObject character = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(translate(TopFaces,path,4, character));
        GameObject panel_Path = GameObject.Find("PU_FoundPath");
        panel_Path.SetActive(false);
        Text status = GameObject.Find("InfoText").GetComponent<Text>();
        status.text = "You've Won!";
        Button btn_pause = GameObject.Find("Pause_Play").GetComponent<Button>();
        btn_pause.enabled = false;
        Button btn_lyr = GameObject.Find("LayerRotation").GetComponent<Button>();
        btn_lyr.enabled = false;
        Button btn_rot = GameObject.Find("CubeRotation").GetComponent<Button>();
        btn_rot.enabled = false;
    }
    bool translating;
    private IEnumerator translate( List<GameObject> TopFaces, List<int> path, float duration, GameObject objectToTranslate )
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        translating = true ;
        Vector3 startTranslation = new Vector3{};
        Vector3 endTranslation = new Vector3{};

        for(int i = 1; i < path.Count; i++)
        {
            startTranslation.x = objectToTranslate.transform.position.x;
            startTranslation.y = objectToTranslate.transform.position.y;
            startTranslation.z = objectToTranslate.transform.position.z;
            endTranslation.x = TopFaces[path[i]-1].transform.position.x;
            endTranslation.y = objectToTranslate.transform.position.y;
            endTranslation.z = TopFaces[path[i]-1].transform.position.z;
            int AB_x = Mathf.RoundToInt(endTranslation.x) - Mathf.RoundToInt(startTranslation.x) ;
            int AB_z = Mathf.RoundToInt(endTranslation.z) - Mathf.RoundToInt(startTranslation.z) ;
            float phi = Mathf.Atan2(AB_x,AB_z);
            Quaternion startRotation = objectToTranslate.transform.localRotation;
            Quaternion endRotation =  Quaternion.Euler(0.0f,phi*Mathf.Rad2Deg,0.0f);
            for(float n = 0 ; n < 10 ; n+= Time.deltaTime)
            {
                objectToTranslate.transform.rotation = Quaternion.Lerp( startRotation, endRotation, n ) ;
            }
            for(float t = 0 ; t < (duration/path.Count) ; t+= Time.deltaTime)
            {
                // Player is pointing in z-direction
                Player.GetComponent<Animator>().Play("Walk"); 
                objectToTranslate.transform.position = Vector3.Lerp( startTranslation,endTranslation,t);
                yield return null;
            }
        translating = false;
        }
        GameObject GoalGO = GameObject.FindGameObjectWithTag("Goal");
        Destroy(GoalGO);
        for(float n = 0 ; n < 100 ; n+= Time.deltaTime)
        {
            Player.GetComponent<Animator>().Play("Wave");
        }
    }
}