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
    int[] PlayerAndID = new int[2];
    int Player = 1;

    // varibles for Abilites
    int AbilityStats;
    bool LeftClicked;
    bool Wait = true;
    bool Prompt;
    bool Open; // I don't know what this does, there isn't a error, and I fear the consiquences of removing it

    // varibles for stats
    bool BlockBool;
    int OriginID;
    int CardListNumber = 0;
    int HeP = -1;
    #region abilities
    int[] HealthChange;
    int DamAbsorb;
    #endregion
    #region traits
    bool HasStealth;
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
            // It is important abilities goes first so that Rush Works
            Abilities();
            Class();
            Species();
            Traits();
        }
    }

    void OnMouseDown()
    {
        #region Abilites
        if (MainMessageCheckpoint.HammerTime == true)
        {
            if (OpenToAttack == true)
            {
                #region Triats that effect a card's capability of being attacked
                bool IHateThis = false;
                if (BlockBool == false && IHateThis == false)
                {
                    if (HasStealth == true)
                    {
                        Debug.Log("Sorry mate, but you cant see this card");
                    }
                    else if (1 == 0)
                    {
                        // placeholder
                    }
                    else
                    {
                        IHateThis = true;
                    }
                }
                else 
                {
                    IHateThis = true;
                }
                #endregion
                if (IHateThis == true)
                {
                    if (BlockBool == true)
                    {
                        if (OriginID == id)
                        {
                            Debug.Log("You cant block with the same card, if you misclicked [y], too bad, so sad");
                        }
                        else
                        {
                            Wait = false;
                        }
                    }
                    if (Wait == true)
                    {
                        Debug.Log("Do you want to block using another card? [Y] [N] ps. if you click another card, I think everything will break, so please don't");
                        Prompt = true;
                    }
                    else if (Wait == false)
                    {
                        string God = "alive";
                        #region things that adjust damage caulculation
                        if (HealthChange[1] > DamAbsorb && DamAbsorb != 0)
                        {
                            HealthChange[1] -= DamAbsorb;
                            God = "dead";
                        }
                        else if (DamAbsorb != 0)
                        {
                            DamAbsorb = HealthChange[1];
                            HealthChange[1] = 0;
                            God = "very dead";
                        }

                        if (God == "dead" || God == "very dead" && DamAbsorb != 0)
                        {
                            HeP -= HealthChange[1];
                            HeP += DamAbsorb;

                            if (HeP <= 0)
                            {
                                HeP = 0;
                            }

                            if (God == "very dead")
                            {
                                Debug.Log("The damge was less than the attacked card's AbsorbDam, loser");
                            }
                        }
                        #endregion
                        if (HeP <= HealthChange[1] && God == "alive")
                        {
                            HeP = 0;
                        }
                        else if (God != "dead" || God != "very dead")
                        {
                            HeP -= HealthChange[1];
                        }
                        SendMessageUpwards("SendClosed");
                        Wait = true;
                    }
                    else
                    {
                        Debug.Log("Can a bool be nither true nor false? if you are seeing this, then it can");
                    }
                }
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
            int[] PlayerAndStatsAndCooldown = new int[3];
            if (Input.GetKeyDown("1") && SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 1)
            {
                PlayerAndStats[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[0];
                PlayerAndStatsAndCooldown[0] = PlayerAndStats[0];
                PlayerAndStatsAndCooldown[1] = PlayerAndStats[1];
                PlayerAndStatsAndCooldown[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[0];
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[0], PlayerAndStatsAndCooldown);
            }
            else if (Input.GetKeyDown("1"))
            {
                Debug.Log(SpawnManagerScriptableObject.CardList[CardListNumber].Name + " has no Abilities or Robert forgot to add them, that idiot");
            }

            if (Input.GetKeyDown("2") && SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 2)
            {
                PlayerAndStats[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[1];
                PlayerAndStatsAndCooldown[0] = PlayerAndStats[0];
                PlayerAndStatsAndCooldown[1] = PlayerAndStats[1];
                PlayerAndStatsAndCooldown[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[1];
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[1], PlayerAndStatsAndCooldown);
            }
            else if (Input.GetKeyDown("2"))
            {
                Debug.Log(SpawnManagerScriptableObject.CardList[CardListNumber].Name + " has only 1 Ability or Robert forgot to add the rest, that idiot");
            }

            if (Input.GetKeyDown("3") && SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 3)
            {
                PlayerAndStats[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[2];
                PlayerAndStatsAndCooldown[0] = PlayerAndStats[0];
                PlayerAndStatsAndCooldown[1] = PlayerAndStats[1];
                PlayerAndStatsAndCooldown[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[2];
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[2], PlayerAndStatsAndCooldown);
            }
            else if (Input.GetKeyDown("3"))
            {
                Debug.Log(SpawnManagerScriptableObject.CardList[CardListNumber].Name + " has only 2 Abilities or Robert forgot to add the rest, that idiot");
            }

            if (Input.GetKeyDown("4") && SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 4)
            {
                PlayerAndStats[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[3];
                PlayerAndStatsAndCooldown[0] = PlayerAndStats[0];
                PlayerAndStatsAndCooldown[1] = PlayerAndStats[1];
                PlayerAndStatsAndCooldown[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[3];
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[3], PlayerAndStatsAndCooldown);
            }
            else if (Input.GetKeyDown("4"))
            {
                Debug.Log(SpawnManagerScriptableObject.CardList[CardListNumber].Name + " has only 3 Abilities or Robert forgot to add the rest, that idiot");
            }
        }
    }

    void Class()
    {
        SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Class, PlayerAndID);
    }

    void Species()
    {
        SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Species, PlayerAndID);
    }

    #region Abiblites (sans Abiblites)
    void SubtractHealth(int[] Stats)
    {
        HealthChange = Stats;
        OpenToAttack = true;
    }

    void AbsorbDam(int[] Stats)
    {
        DamAbsorb = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[Stats[1]];
    }
    #endregion

    void Abilities()
    {
        #region the tower
        int[] Temp = new int[3];
        Temp[0] = -1;
        if (SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 1)
        {
            Temp[1] = 0;
            Temp[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[0];
            SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[0], Temp);

            if (SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 2)
            {
                Temp[1] = 1;
                Temp[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[1];
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[1], Temp);

                if (SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 3)
                {
                    Temp[1] = 2;
                    Temp[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[2];
                    SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[2], Temp);

                    if (SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 4)
                    {
                        Temp[1] = 3;
                        Temp[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[3];
                        SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[3], Temp);

                        if (SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 5)
                        {
                            Debug.Log("this card has too many abilities");
                        }
                    }
                }
            }
        }
        #endregion
    }

    #region Traits (sans Traits)
    void Stealth()
    {
        HasStealth = true;
    }
    #endregion

    void Traits()
    {
        #region the tower
        if (SpawnManagerScriptableObject.CardList[CardListNumber].Traits.Length >= 1)
        {
            SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Traits[0], PlayerAndID);

            if (SpawnManagerScriptableObject.CardList[CardListNumber].Traits.Length >= 2)
            {
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Traits[1], PlayerAndID);

                if (SpawnManagerScriptableObject.CardList[CardListNumber].Traits.Length >= 3)
                {
                    SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Traits[2], PlayerAndID);

                    if (SpawnManagerScriptableObject.CardList[CardListNumber].Traits.Length >= 4)
                    {
                        SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Traits[3], PlayerAndID);

                        if (SpawnManagerScriptableObject.CardList[CardListNumber].Traits.Length >= 5)
                        {
                            Debug.Log("this card has too many triats");
                        }
                    }
                }
            }
        }
        #endregion
    }

    void Block(int Originid)
    {
        BlockBool = true;
        OriginID = Originid;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerAndID[1] = id;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 3 == 1)
        {
            PlayerAndStats[0] = Player;
            PlayerAndID[0] = Player;
        }

        if (HeP > SpawnManagerScriptableObject.CardList[CardListNumber].HealthPoints)
        {
            HeP = SpawnManagerScriptableObject.CardList[CardListNumber].HealthPoints;
        }

        if (Prompt == true)
        { 
            if (Input.GetKeyDown("y"))
            {
                Debug.Log("Click the card you want to block with");
                SendMessageUpwards("SendBlock", id);
            }
            if (Input.GetKeyDown("n"))
            {
                Wait = false;
                Prompt = false;
                Debug.Log("click on the card again to procide");
            }
        }

        if (HeP == 0)
        {
            CardListNumber = 0;
            SendMessageUpwards("Player2NotFull", id);
            HeP = -1;
        }
    }
}