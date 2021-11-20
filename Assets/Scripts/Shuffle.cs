using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    // calls my data objects
    public SpawnDeckList SpawnDeckList;
    public SpawnManagerScriptableObject SpawnManagerScriptableObject;

    // temp variables
    public bool[] GooCard = new bool[5];

    // varibles for deck sorting
    int TopCard = 0;
    int GooEmpty = 5;

    // Start is called before the first frame update
    void Awake()
    {
        // temp variable definations
        GooCard[0] = true;
        GooCard[1] = true;
        GooCard[2] = true;
        GooCard[3] = true;
        GooCard[4] = true;

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
	    if (GooCard[0] == false)
	    {
	    	// insert code to message GooCard1 with the info
	    }
	    else if (GooCard[1] == false)
	    {
	    	// insert code to message GooCard2 with the info
	    }
	    else if (GooCard[2] == false)
    	{
    		// insert code to message GooCard3 with the info
    	}
    	else if (GooCard[3] == false)
    	{
    		// insert code to message GooCard4 with the info
    	}
    	else if (GooCard[4] == false)
    	{
    		// insert code to message GooCard5 with the info
    	}
    	else
    	{
    		Debug.LogError("<color=red>Error:</color> Either all GooCards are full and the GooEmpty was mistakenly called, or at least one of the GooCards are listed as full when they aren’t");
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
