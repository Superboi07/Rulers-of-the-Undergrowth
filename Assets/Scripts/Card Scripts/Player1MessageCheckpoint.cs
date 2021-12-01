using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1MessageCheckpoint : MonoBehaviour
{
    public bool[] Player1Card = new bool[120];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Player1NotFull(int ID)
    {
        Player1Card[ID] = false;
        Debug.Log("Player1Card " + ID + " is not full");
    }

    void ApplyStatsP1(int[] TempStorage)
    {
        for (int i = 0; i <= 119; i++)
        {
            if (Player1Card[i] == false)
            {
                TempStorage[0] = i;
            }
            else if (i == 119)
            {
                Debug.LogError("<color=red>Error:</color> Either I messed up the script or you somehow have 120 cards on one side and you want more");
            }
        }

        Player1Card[TempStorage[0]] = true;

        BroadcastMessage("ReciveGooStats", TempStorage);
    }
}
