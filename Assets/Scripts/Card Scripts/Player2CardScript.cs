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
    public Text HP;

    // varibles for messaging
    public int id;
    int[] PlayerAndStats = new int[2];
    int Player = 1;

    // varibles for Abilites
    int AbilityStats;
    bool LeftClicked;
    bool Open; // I don't know what this does, there isn't a error, and I fear the consiquences of removing it

    // varibles for stats
    int CardListNumber;
    int HeP = -1;
    #region abilities
    int[] HealthChange;
    #endregion
    #region ability OpenTo___
    bool OpenToAttack;
    #endregion

    void Closed()
    {
        // set all varibles in ability OpenTo___ to false
        OpenToAttack = false;
    }

    void Turn(int turn)
    {
        Player = turn;
    }

    void ReciveGooStats(int[] Stats)
    {
        if (Stats[0] == id)
        {
            // insert code to apply sprite
            Debug.Log("Player2Card (" + id + ") is " + SpawnManagerScriptableObject.CardList[Stats[1]].Name);
            CardListNumber = Stats[1];
            HeP = SpawnManagerScriptableObject.CardList[Stats[1]].HealthPoints;
        }
    }

    void OnMouseDown()
    {
        #region Abilites
        if (MainMessageCheckpoint.HammerTime == true)
        {
            if (OpenToAttack == true)
            {
                if (HeP <= HealthChange[1])
                {
                    HeP = 0;
                }
                else
                {
                    HeP -= HealthChange[1];
                }
                SendMessageUpwards("SendClosed");
            }
            else if (1 == 0)
            {
                // placeholder
            }
            else
            {
                Debug.Log("Card " + id + " is not open to being a/e ffected by the ability, use the ability before doing ANYTING else");
            }
        }
        #endregion
        else if (Player == 2)
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
        else
        {
            Debug.Log("It is not player 2's turn, it is player " + Player + "'s turn; if that just so happened to be a 2, god help me");
        }
    }

    void OnMouseOver()
    {
        CurentCard.text = "Current Card: " + "\n" + SpawnManagerScriptableObject.CardList[CardListNumber].Name;
        HP.text = "HP: " + HeP;

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

    #region Abiblites
    void SubtractHealth(int[] Stats)
    {
        HealthChange = Stats;
        OpenToAttack = true;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        PlayerAndStats[0] = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (HeP == 0)
        {
            CardListNumber = 0;
            SendMessageUpwards("Player2NotFull", id);
            HeP = -1;
        }
    }
}