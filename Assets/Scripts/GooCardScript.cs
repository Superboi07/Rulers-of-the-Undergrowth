using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooCardScript : MonoBehaviour
{
    // calls my data objects
    public SpawnDeckList SpawnDeckList;
    public SpawnManagerScriptableObject SpawnManagerScriptableObject;

    // temp variables
    public bool[] Player1Card = new bool[5];
    public int Player = 1;

    // varibles for messaging
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        // temp variable definations
    }

    void ReciveStats(int[] Stats)
    {
        if (Stats[0] == id)
        {
            SendMessageUpwards("GooFull", id);
            // insert code to apply sprite and cost
            Debug.Log("GooCard " + id + " tryed to send message upwards");
            Debug.Log("GooCard " + id + " BioCost is " + SpawnManagerScriptableObject.CardList[Stats[1]].BioCost);
            Debug.Log("GooCard " + id + " BioCost is " + SpawnManagerScriptableObject.CardList[Stats[1]].GeoCost);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Player == 1)
            {
                if (Player1Card[0] == false)
                {
                    // insert code to message Player1Card1 with the stats
                }
                else if (Player1Card[1] == false) 
                {
                    // insert code to message Player1Card2 with the stats
                }
                else if (Player1Card[2] == false) 
                {
                    // insert code to message Player1Card3 with the info
                }
                else
                {
                    Debug.LogError("<color=red>Error:</color> Either I messed up the script or you somehow have 120 cards on one side and you want more, if the ladder is true, I quit");
                }
            }
        }
    }
}
