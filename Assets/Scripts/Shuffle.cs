using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class Shuffle : MonoBehaviour
{

    // calls my data objects
    public SpawnDeckList SpawnDeckList;
    public SpawnManagerScriptableObject SpawnManagerScriptableObject;

    // temp variables

    // varibles for deck sorting
    int TopCard = 0;
    int GooEmpty = 1;

    // varibles for messanging
    int[] TempStorage = new int[2];
    public bool[] GooCard = new bool[5];

    // Start is called before the first frame update
    void Awake()
    {
        // temp variable definations

        // code here to decide what decks are chosen

        // merging the decks the plays choose into Deck
        int[] Deck = new int[SpawnDeckList.SpindleDeck.Length + SpawnDeckList.SpindleDeck.Length];
        Array.Copy(SpawnDeckList.SpindleDeck, Deck, SpawnDeckList.SpindleDeck.Length);
        Array.Copy(SpawnDeckList.SpindleDeck, 0, Deck, SpawnDeckList.SpindleDeck.Length, SpawnDeckList.SpindleDeck.Length);

        // shuffling Deck
        int tempDeck;
        for (int i = 0; i < Deck.Length; i++)
        {
            int rnd = UnityEngine.Random.Range(0, Deck.Length);
            tempDeck = Deck[rnd];
            Deck[rnd] = Deck[i];
            Deck[i] = tempDeck;
        }

        // making sure nothing is broken
        Debug.Log("first cards that appear in the goo are numbers ");
        for (int i = GooEmpty; i > 0; i -= 0)
        {
            Debug.Log(Deck[TopCard]);
            MakeCard(Deck[TopCard]);
            TopCard += 1;
            GooEmpty -= 1;
            i -= 1;
        }
        Debug.Log("TopCard is " + TopCard);
        Debug.Log("GooEmpty is " + GooEmpty);
    }

    // make the card with the stats
    void MakeCard(int CardID)
    {
        TempStorage[1] = CardID;

	    if (GooCard[0] == false)
	    {
            // insert code to message GooCard with the info
            TempStorage[0] = 0;
            BroadcastMessage("ReciveStats", TempStorage);
        }
	    else if (GooCard[1] == false)
	    {
            // insert code to message GooCard1 with the info
            TempStorage[0] = 1;
            BroadcastMessage("ReciveStats", TempStorage);
        }
	    else if (GooCard[2] == false)
    	{
            // insert code to message GooCard2 with the info
            TempStorage[0] = 2;
            BroadcastMessage("ReciveStats", TempStorage);
        }
    	else if (GooCard[3] == false)
    	{
            // insert code to message GooCard3 with the info
            TempStorage[0] = 3;
            BroadcastMessage("ReciveStats", TempStorage);
        }
    	else if (GooCard[4] == false)
    	{
            // insert code to message GooCard4 with the info
            TempStorage[0] = 4;
            BroadcastMessage("ReciveStats", TempStorage);
        }
    	else
    	{
    		Debug.LogError("<color=red>Error:</color> Either all GooCards are full and the GooEmpty was mistakenly called, or at least one of the GooCards are listed as full when they aren’t");
    	}
    }

    // updates which GooCards are empty
    void GooFull(int ID)
    {
        GooCard[ID] = true;
        Debug.Log("GooCard " + ID + " is full");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
