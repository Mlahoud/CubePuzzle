using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/* Instantiator for character, goal and obstacles of the cube world.
 * The enumeration of the blocks is important and is given in the documentation.
 * CharacterPos and GoalPos are priority so if they are not defined or bad defined 
 * an error is going to be displayed in the console of editor.
 * Obstacles are set after. If an obstacle is defined in the place of the character or
 * goal, it is ignored (give priority to the character and goal position).
 */
//Code by Mlahod
public class PuzzleCreator : MonoBehaviour
{
    //Define Enum of possible elements that can be within the squares.
    public enum Object{Empty = 0, Rock = 1, Fire = 2, Crystal = 3, Tree = 4};
    //Make a list of all squares
    private const int COUNT = 9;
    [SerializeField]
    public Object[] Face_1 = new Object[COUNT];
    public Object[] Face_2 = new Object[COUNT];
    public Object[] Face_3 = new Object[COUNT];
    public Object[] Face_4 = new Object[COUNT];
    public Object[] Face_5 = new Object[COUNT];
    public Object[] Face_6 = new Object[COUNT];
    
    /* The function CreatePuzzle should appears in the inspector of the cube component.
     * Each time it is selected: The previous puzzle (if exists) is destroyed and then
     * the CharacterPos, GoalPosition and obstacles are instantiated. 
     * Start is called before the first frame update
     */
    public GameObject Player;
    public GameObject Goal;
    public GameObject Empty;
    public GameObject Rock;
    public GameObject Fire;
    public GameObject Crystal;
    public GameObject Tree;
    public Transform ParentPos;
    private const int ch_p = 1;
    private const int g_p = 9;
    [SerializeField]
    public int CharacterPos = ch_p;
    public int GoalPos = g_p;
    [ContextMenu("CreateWorld")]
    void CreateWorld()
    {
        destroyAllChildren();
        if (CharacterPos < 1 || CharacterPos > 9)
            Debug.Log("Please set a Character Position between 1 and 9");
        else if (GoalPos < 1 || GoalPos > 9)
            Debug.Log("Please set a Goal Position between 1 and 9");
            else
            {
            CharacterInstantiation();
            GoalInstantiation();
            FaceInstantiation(1, Face_1, new Vector3( 0.0f,1.0f, 0.0f), new Vector3( 0.0f, 0.0f,  0.0f), new int[] {  1, 2, 3, 4, 5, 6, 7, 8, 9 });
            FaceInstantiation(2, Face_2, new Vector3( 0.5f,0.5f, 0.0f), new Vector3( 0.0f, 0.0f,-90.0f), new int[] {  7, 8, 9,16,17,18,25,26,27 });
            FaceInstantiation(3, Face_3, new Vector3( 0.0f,0.5f, 0.5f), new Vector3(90.0f, 0.0f,  0.0f), new int[] {  3, 6, 9,12,15,18,21,24,27 });
            FaceInstantiation(4, Face_4, new Vector3(-0.5f,0.5f, 0.0f), new Vector3( 0.0f, 0.0f, 90.0f), new int[] {  1, 2, 3,10,11,12,19,20,21 });
            FaceInstantiation(5, Face_5, new Vector3( 0.0f,0.5f,-0.5f), new Vector3(0.0f,-90.0f, 90.0f), new int[] {  1, 4, 7,10,13,16,19,22,25 });
            FaceInstantiation(6, Face_6, new Vector3( 0.0f,0.0f, 0.0f), new Vector3(0.0f,  0.0f,180.0f), new int[] { 19,20,21,22,23,24,25,26,27 });
            Debug.Log("World Created!!");
            }
    }
    [ContextMenu("destroyAllChildren")]
    void destroyAllChildren()
    {
        //Search for all obstacles or blocks childrens and destroy them
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject goal = GameObject.FindGameObjectWithTag("Goal");
        GameObject[] paths = GameObject.FindGameObjectsWithTag("Path");

        foreach (GameObject obstacle in obstacles)
        {
            DestroyImmediate(obstacle);
        }
        DestroyImmediate(player);
        DestroyImmediate(goal);
        foreach (GameObject path in paths)
        {
            DestroyImmediate(path);
        }

    }
    
    [ContextMenu("CharacterInstantiation")]
    void CharacterInstantiation()
    {
        Vector3 pos = new Vector3( 0.0f,1.0f,0.0f);
        Vector3 rot = new Vector3(0.0f,0.0f,0.0f);
        Vector3 initpos = pos;
        GameObject character;
        GameObject floor;
        for (int i = 1; i < 10; i++)
        {
            if (i == CharacterPos)
            {
            GameObject block = GameObject.Find("Block ("+CharacterPos+")");
            character = Instantiate(Player, pos, Quaternion.Euler(rot)) as GameObject;
            character.transform.localPosition = block.transform.localPosition + pos;
            character.transform.parent = block.transform ;
            character.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            character.tag = "Player";
            floor = Instantiate(Empty, pos, Quaternion.Euler(rot)) as GameObject;
            floor.transform.localPosition = block.transform.localPosition + pos;
            floor.transform.parent = block.transform ;
            floor.tag = "Path";
            }
            if (i == 4)
            {
                pos.z = initpos.z;
                
            }
        }
    }
    [ContextMenu("GoalInstantiation")]
    void GoalInstantiation()
    {
        Vector3 pos = new Vector3( 0.0f,1.5f,0.0f);
        Vector3 rot = new Vector3(0.0f,0.0f,0.0f);
        Vector3 pos_floor = new Vector3( 0.0f,1.0f,0.0f);
        GameObject goal;
        GameObject floor;
        Vector3 initpos = pos;
        for (int i = 1; i < 10; i++)
        {
            if (i == GoalPos)
            {
            GameObject block = GameObject.Find("Block ("+GoalPos+")");
            goal = Instantiate(Goal, pos, Quaternion.Euler(rot)) as GameObject;
            goal.transform.localPosition = block.transform.localPosition + pos;
            goal.transform.parent = block.transform ;
            goal.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            goal.tag = "Goal";
            floor = Instantiate(Empty, pos_floor, Quaternion.Euler(rot)) as GameObject;
            floor.transform.localPosition = block.transform.localPosition + pos_floor;
            floor.transform.parent = block.transform ;
            floor.tag = "Path";
            }
            if (i == 4)
            {
                pos.z = initpos.z;
            }
        }
    }
    void FaceInstantiation(int idx, Object[] face, Vector3 pos, Vector3 rot, int[] n_block)
    {
        Vector3 initpos = pos;
        GameObject obstacle;
        GameObject type;
        int i = 1;
        int j = 1;
        GameObject block;
        foreach (Object squares in face){
            if (face == Face_1 && (j == CharacterPos || j == GoalPos))
                print("Ignored obstacle at " + j + " pos.");
            else
            switch(squares)
            {
                case Object.Empty:{
                    type = Empty;
                    block = GameObject.Find("Block ("+n_block[j-1]+")");
                    //obstacle = Instantiate(type) as GameObject;
                    obstacle = Instantiate(type, pos, Quaternion.Euler(rot)) as GameObject;
                    obstacle.transform.localPosition = block.transform.localPosition + pos;
                    obstacle.transform.parent = block.transform ;
                    obstacle.name = "Path" + idx;
                    obstacle.tag = "Path";
                    obstacle.isStatic = false;
                    foreach (Transform child in obstacle.transform){
                        child.gameObject.isStatic = false;
                    }
                break;
                }
                case Object.Rock:{
                    type = Rock;
                    block = GameObject.Find("Block ("+n_block[j-1]+")");
                    //obstacle = Instantiate(type) as GameObject;
                    obstacle = Instantiate(type, pos, Quaternion.Euler(rot)) as GameObject;
                    obstacle.transform.localPosition = block.transform.localPosition + pos;
                    obstacle.transform.parent = block.transform ;
                    obstacle.name = "Obstacle" + idx;
                    obstacle.tag = "Obstacle";
                    obstacle.isStatic = false;
                    foreach (Transform child in obstacle.transform){
                        child.gameObject.isStatic = false;
                    }
                break;
                }
                case Object.Fire:{
                    type = Fire;
                    block = GameObject.Find("Block ("+n_block[j-1]+")");
                    obstacle = Instantiate(type, pos, Quaternion.Euler(rot)) as GameObject;
                    obstacle.transform.localPosition = block.transform.localPosition + pos;
                    obstacle.transform.parent = block.transform ;
                    obstacle.name = "Obstacle" + idx;
                    obstacle.tag = "Obstacle";
                    obstacle.isStatic = false;
                    foreach (Transform child in obstacle.transform){
                        child.gameObject.isStatic = false;
                    }
                break;
                }
                case Object.Crystal:{
                    type = Crystal;
                    block = GameObject.Find("Block ("+n_block[j-1]+")");
                    obstacle = Instantiate(type, pos, Quaternion.Euler(rot)) as GameObject;
                    obstacle.transform.localPosition = block.transform.localPosition + pos;
                    obstacle.transform.parent = block.transform ;
                    obstacle.name = "Obstacle" + idx;
                    obstacle.tag = "Obstacle";
                    obstacle.isStatic = false;
                    foreach (Transform child in obstacle.transform){
                        child.gameObject.isStatic = false;
                    }
                break;
                }
                case Object.Tree:{
                    type = Tree;
                    block = GameObject.Find("Block ("+n_block[j-1]+")");
                    obstacle = Instantiate(type, pos, Quaternion.Euler(rot)) as GameObject;
                    obstacle.transform.localPosition = block.transform.localPosition + pos;
                    obstacle.transform.parent = block.transform ;
                    obstacle.name = "Obstacle" + idx;
                    obstacle.tag = "Obstacle";
                    obstacle.isStatic = false;
                    foreach (Transform child in obstacle.transform){
                        child.gameObject.isStatic = false;
                    }
                break;
                }
            }
            i++;
            j++;
            if (i == 4)
            {
                pos.z = initpos.z;
                i = 1;
            }
        }
    }
}   