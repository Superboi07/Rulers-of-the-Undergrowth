using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMessageCheckpoint : MonoBehaviour
{
    // calls my text boxes
    public Text CurentCard;

    // global variables
    int P1Bio;
    int P1Geo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SendApplyStatsP2(int[] TempStorage)
    {
        BroadcastMessage("ApplyStatsP2", TempStorage);
    }

    void SendApplyStatsP1(int[] TempStorage)
    {
        BroadcastMessage("ApplyStatsP1", TempStorage);
    }

    void ChangeP1Geo(int change)
    {
        P1Geo += change;
        CurentCard.text = "P1 Bio: " + P1Bio + "\n" + "Geo: " + P1Geo;
    }

    void ChangeP1Bio(int change)
    {
        P1Bio += change;
        CurentCard.text = "P1 Bio: " + P1Bio + "\n" + "Geo: " + P1Geo;
    }
}
