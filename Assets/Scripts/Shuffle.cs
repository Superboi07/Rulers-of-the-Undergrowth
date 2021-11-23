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
    int eine = 1;

    // varibles for deck sorting
    int TopCard = 0;
    int GooEmpty = 5;

    // varibles for messanging
    int[] TempStorage = new int[2];
    public bool[] GooCard = new bool[5];

    // varibles for shuffling
    int[] ShuffledDeck;

    // *REMEMBER* Awake is when the object is inzlied, so DIFFERENT from Start
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

        ShuffledDeck = Deck;
    }

    // Update is called once per frame
    void Update()
    {
        for (int one = eine; one == 1; one -= 1)
        {
            for (int i = GooEmpty; i > 0; i -= 0)
            {
                Debug.Log("The card id being sent is " + ShuffledDeck[TopCard] + " plus 1 (I gave up adding inside Debug.Log)");
                Debug.Log("The top card id in ShuffledDeck is " + ShuffledDeck[TopCard]);
                Debug.Log("The card id being sent means " + SpawnManagerScriptableObject.CardList[ShuffledDeck[TopCard] + 1].Name);
                MakeCard(ShuffledDeck[TopCard] + 1);
                TopCard += 1;
                GooEmpty -= 1;
                i -= 1;
            }
            Debug.Log("TopCard (how many cards have been sent to the Goo) is " + TopCard);
            Debug.Log("GooEmpty (the amount of GooCards empty) is " + GooEmpty);
            eine -= 1;
        }
    }

    // make the card with the stats
    void MakeCard(int CardID)
    {
        TempStorage[1] = CardID;

        if (1 == 1)
        {
            if (GooCard[0] == false)
            {
                TempStorage[0] = 0;
            }
            else if (GooCard[1] == false)
            {
                TempStorage[0] = 1;
            }
            else if (GooCard[2] == false)
            {
                TempStorage[0] = 2;
            }
            else if (GooCard[3] == false)
            {
                TempStorage[0] = 3;
            }
            else if (GooCard[4] == false)
            {
                TempStorage[0] = 4;
            }
            else
            {
                Debug.LogError("<color=red>Error:</color> Either all GooCards are full and the GooEmpty was mistakenly called, or at least one of the GooCards are listed as full when they aren�t");
            }
        }

        BroadcastMessage("ReciveStats", TempStorage);
    }

    // updates which GooCards are empty
    void GooFull(int ID)
    {
        GooCard[ID] = true;
        Debug.Log("GooCard " + ID + " is full");
    }

    void GooNotFull(int ID)
    {
        GooCard[ID] = false;
        Debug.Log("GooCard " + ID + " is empty");
        GooEmpty += 1;
        eine += 1;
    }

}
