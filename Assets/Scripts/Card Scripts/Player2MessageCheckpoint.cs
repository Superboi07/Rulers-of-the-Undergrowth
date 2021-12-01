using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2MessageCheckpoint : MonoBehaviour
{
    public bool[] Player2Card = new bool[120];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Player2NotFull(int ID)
    {
        Player2Card[ID] = false;
        Debug.Log("Player2Card " + ID + " is not full");
    }

    void ApplyStatsP2(int[] TempStorage)
    {
        for (int i = 0; i <= 119; i++)
        {
            if (Player2Card[i] == false)
            {
                TempStorage[0] = i;
            }
            else if (i == 119)
            {
                Debug.LogError("<color=red>Error:</color> Either I messed up the script or you somehow have 120 cards on one side and you want more");
            }
        }

        Player2Card[TempStorage[0]] = true;

        BroadcastMessage("ReciveGooStats", TempStorage);
    }
}