using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooCardScript : MonoBehaviour
{
    // calls my data objects
    public SpawnDeckList SpawnDeckList;
    public SpawnManagerScriptableObject SpawnManagerScriptableObject;
    private SpawnManagerScriptableObject.Card PersonalStats;

    // temp variables
    public bool[] Card = new bool[5];
    public int Player = 1;

    // Start is called before the first frame update
    void Start()
    {
        // temp variable definations
        Card[1] = true;
        Card[2] = true;
        Card[3] = true;
        Card[4] = true;
    }

    void ReciveStats(SpawnManagerScriptableObject.Card Stats)
    {
        Stats = PersonalStats;
        // insert code to apply sprite and cost
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Player == 1)
            {
                if (Card[0] == false)
                {
                    // insert code to message Card1 with the stats
                }
                else if (Card[1] == false) 
                {
                    // insert code to message Card2 with the stats
                }
                else if (Card[2] == false) 
                {
                    // insert code to message Card3 with the info
                }
                else
                {
                    Debug.LogError("<color=red>Error:</color> Either I messed up the script or you somehow have 120 cards on one side and you want more, if the ladder is true, I quit");
                }
            }
        }
    }
}
