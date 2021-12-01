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
    public Text Cost;
    public Text HP;

    // temp variables

    // varibles for messaging
    int[] TempStorage = new int[2];
    int[] TempResourceStorage = new int[2];
    public bool[] Player1Card = new bool[120];
    public bool[] Player2Card = new bool[120];
    public int id;
    public int Player = 1;
    int[] one = new int[1];
    int[] two = new int[1];

    // Start is called before the first frame update
    void Start()
    {
        // temp variable definations

        // message variable definations
        TempResourceStorage[0] = 1;
        one[0] = 1; // I need these as an array
        two[0] = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Turn(int turn)
    {
        Player = turn;
        TempResourceStorage[0] = turn;
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

    void OnMouseDown()
    {
        if (Player == 1)
        {
            if (MainMessageCheckpoint.P1Bio >= SpawnManagerScriptableObject.CardList[TempStorage[1]].BioCost)
            {
                if (MainMessageCheckpoint.P1Geo >= SpawnManagerScriptableObject.CardList[TempStorage[1]].GeoCost)
                {
                    SendMessageUpwards("SendApplyStatsP1", TempStorage);
                    SendMessageUpwards("GooNotFull", id);
                    TempResourceStorage[1] = -SpawnManagerScriptableObject.CardList[TempStorage[1]].BioCost;
                    SendMessageUpwards("ChangeBio", TempResourceStorage);
                    TempResourceStorage[1] = -SpawnManagerScriptableObject.CardList[TempStorage[1]].GeoCost;
                    SendMessageUpwards("ChangeGeo", TempResourceStorage);
                    SendMessageUpwards("PassTurn", one);
                }
                else
                {
                    Debug.Log("Player " + Player + " does not have enough Geo; if it is player 2's turn, I am going to cry");
                }
            }
            else
            {
                Debug.Log("Player " + Player + " does not have enough Bio; if it is player 2's turn, I am going to cry");
            }
        }
        else if (Player == 2)
        {
            if (MainMessageCheckpoint.P2Bio >= SpawnManagerScriptableObject.CardList[TempStorage[1]].BioCost)
            {
                if (MainMessageCheckpoint.P2Geo >= SpawnManagerScriptableObject.CardList[TempStorage[1]].GeoCost)
                {
                    SendMessageUpwards("SendApplyStatsP2", TempStorage);
                    SendMessageUpwards("GooNotFull", id);
                    TempResourceStorage[1] = -SpawnManagerScriptableObject.CardList[TempStorage[1]].BioCost;
                    SendMessageUpwards("ChangeBio", TempResourceStorage);
                    TempResourceStorage[1] = -SpawnManagerScriptableObject.CardList[TempStorage[1]].GeoCost;
                    SendMessageUpwards("ChangeGeo", TempResourceStorage);
                    SendMessageUpwards("PassTurn", two);
                }
                else
                {
                    Debug.Log("Player " + Player + " does not have enough Geo; if it is player 1's turn, I am going to cry");
                }
            }
            else
            {
                Debug.Log("Player " + Player + " does not have enough Bio; if it is player 1's turn, I am going to cry");
            }
        }
        else
        {
            Debug.Log("Player != 1 && Player != 2, Player = " + Player);
        }
    }

    void OnMouseOver()
    {
        CurentCard.text = "Current Card: " + "\n" + SpawnManagerScriptableObject.CardList[TempStorage[1]].Name;
        Cost.text = "Bio Cost: " + SpawnManagerScriptableObject.CardList[TempStorage[1]].BioCost + "\n" + "Geo Cost: "  + SpawnManagerScriptableObject.CardList[TempStorage[1]].GeoCost;
        HP.text = "HP: " + SpawnManagerScriptableObject.CardList[TempStorage[1]].HealthPoints;
    }
}