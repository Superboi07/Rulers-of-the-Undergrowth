using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Card
{
    public int BioCost;
    public int GeoCost;
    public string Name;
    public string Class;
    public string Speices;
    public int Duration;
    public int HealthPoints;
    public string[] Abilities;
    public int[] AbilityPower;
    public int[] AbilityRefresh; 
    public string[] Traits;
    public Sprite Image;
}

public class Shuffle : MonoBehaviour
{
    // the decks
    public int[] SpindleDeck;
    public int[] AnnahDeck;

    void Awake()
    {
        // code here to decide what decks are chosen

        // merging the decks the plays choose into Deck
        int[] Deck = new int[SpindleDeck.Length + SpindleDeck.Length];
        Array.Copy(SpindleDeck, Deck, SpindleDeck.Length);
        Array.Copy(SpindleDeck, 0, Deck, SpindleDeck.Length, SpindleDeck.Length);

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
        Debug.Log("first card that appears is number" + Deck[0]);

    }
}