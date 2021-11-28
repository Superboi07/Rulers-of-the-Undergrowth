using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GooCardScript : MonoBehaviour
{
    // calls my data objects
    public SpawnDeckList SpawnDeckList;
    public SpawnManagerScriptableObject SpawnManagerScriptableObject;

    // calls my text boxes
    public Text CurentCard;

    // temp variables
    public int Player = 1;

    // varibles for messaging
    int[] TempStorage = new int[2];
    public bool[] Player1Card = new bool[120];
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        // temp variable definations
    }

    // Update is called once per frame
    void Update()
    {

    }

    // message funtions
    void ReciveStats(int[] Stats)
    {
        if (Stats[0] == id)
        {
            TempStorage[1] = Stats[1];
            SendMessageUpwards("GooFull", id);
            // insert code to apply sprite and cost
            Debug.Log("GooCard " + id + " tryed to send message upwards");
            Debug.Log("GooCard " + id + " BioCost is " + SpawnManagerScriptableObject.CardList[Stats[1]].BioCost);
            Debug.Log("GooCard " + id + " BioCost is " + SpawnManagerScriptableObject.CardList[Stats[1]].GeoCost);
        }
    }

    void Player1Full(int ID)
    {
        Player1Card[ID] = true;
        Debug.Log("GooCard " + ID + " is full");
    }

    void OnMouseDown()
    {
        if (Player == 1)
        {
            SendMessageUpwards("SendApplyStatsP1", TempStorage);
        }
        if (Player == 2)
        {
            SendMessageUpwards("SendApplyStatsP2", TempStorage);
        }

        SendMessageUpwards("GooNotFull", id);
    }

    void OnMouseOver()
    {
        CurentCard.text = "Card: " + "\n" + SpawnManagerScriptableObject.CardList[TempStorage[1]].Name;
    }
}