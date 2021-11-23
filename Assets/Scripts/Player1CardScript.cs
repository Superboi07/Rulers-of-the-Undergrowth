using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1CardScript : MonoBehaviour
{
    // calls my data objects
    public SpawnDeckList SpawnDeckList;
    public SpawnManagerScriptableObject SpawnManagerScriptableObject;

    // calls my text boxes
    public Text CurentCard;

    // varibles for messaging
    public int id;

    // varibles for Abilites
    int AbilityStats;
    bool LeftClicked;

    // varibles for stats
    int CardListNumber;

    void ReciveGooStats(int[] Stats)
    {
        if (Stats[0] == id)
        {
            // insert code to apply sprite
            Debug.Log("Player1Card (" + id + ") is " + SpawnManagerScriptableObject.CardList[Stats[1]].Name);
            CardListNumber = Stats[1];
        }
    }

    void OnMouseDown()
    {
        if (SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length > 0)
        {
            LeftClicked = true;
        }
        else
        {
            Debug.Log(SpawnManagerScriptableObject.CardList[CardListNumber].Name + " has no Abilities or Robert forgot to add them, that idiot");
        }
    }

    void OnMouseOver()
    {
        CurentCard.text = "Card: " + "\n" + SpawnManagerScriptableObject.CardList[CardListNumber].Name;

        if (LeftClicked == true)
        {
            if (Input.GetKeyDown("1") && SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 1)
            {
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[0], SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[0]);
            }

            if (Input.GetKeyDown("2") && SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 2)
            {
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[1], SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[1]);
            }

            if (Input.GetKeyDown("3") && SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 3)
            {
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[2], SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[2]);
            }

            if (Input.GetKeyDown("4") && SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 4)
            {
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[3], SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[3]);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
