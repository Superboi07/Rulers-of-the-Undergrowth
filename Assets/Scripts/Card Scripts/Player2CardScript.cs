using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2CardScript : MonoBehaviour
{
    // calls my data objects
    public SpawnDeckList SpawnDeckList;
    public SpawnManagerScriptableObject SpawnManagerScriptableObject;

    // calls my text boxes
    public Text CurentCard;

    // varibles for messaging
    public int id;
    int[] PlayerAndStats = new int[2];

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
            Debug.Log("Player2Card (" + id + ") is " + SpawnManagerScriptableObject.CardList[Stats[1]].Name);
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
                PlayerAndStats[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[0];
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[0], PlayerAndStats);
            }
            else if (Input.GetKeyDown("1"))
            {
                Debug.Log(SpawnManagerScriptableObject.CardList[CardListNumber].Name + " has no Abilities or Robert forgot to add them, that idiot");
            }

            if (Input.GetKeyDown("2") && SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 2)
            {
                PlayerAndStats[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[1];
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[1], PlayerAndStats);
            }
            else if (Input.GetKeyDown("2"))
            {
                Debug.Log(SpawnManagerScriptableObject.CardList[CardListNumber].Name + " has only 1 Ability or Robert forgot to add the rest, that idiot");
            }

            if (Input.GetKeyDown("3") && SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 3)
            {
                PlayerAndStats[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[2];
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[2], PlayerAndStats);
            }
            else if (Input.GetKeyDown("3"))
            {
                Debug.Log(SpawnManagerScriptableObject.CardList[CardListNumber].Name + " has only 2 Abilities or Robert forgot to add the rest, that idiot");
            }

            if (Input.GetKeyDown("4") && SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 4)
            {
                PlayerAndStats[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[3];
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[3], PlayerAndStats);
            }
            else if (Input.GetKeyDown("4"))
            {
                Debug.Log(SpawnManagerScriptableObject.CardList[CardListNumber].Name + " has only 3 Abilities or Robert forgot to add the rest, that idiot");
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerAndStats[0] = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
