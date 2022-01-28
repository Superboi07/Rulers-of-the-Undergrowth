using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RulerScript : MonoBehaviour
{
    // calls my data objects
    public SpawnDeckList SpawnDeckList;
    public SpawnManagerScriptableObject SpawnManagerScriptableObject;

    // calls my text boxes
    public Text CurentCard;
    public Text Cost;
    public Text HP;
    public Text ClassSpecies;
    public Text Ability1Text;
    public Text Ability2Text;
    public Text Ability3Text;
    public Text Ability4Text;
    public Text Trait1Text;
    public Text Trait2Text;
    public Text Trait3Text;
    public Text Trait4Text;

    #region varibles for text boxes
    string Ability1;
    string Ability2;
    string Ability3;
    string Ability4;
    object[] AbilityStats1 = new object[2];
    object[] AbilityStats2 = new object[2];
    object[] AbilityStats3 = new object[2];
    object[] AbilityStats4 = new object[2];
    string Trait1;
    string Trait2;
    string Trait3;
    string Trait4;
    #endregion

    // varibles for messaging
    int[] PlayerAndStats = new int[2];
    int[] PlayerAndID = new int[2];
    int Player = 1;
    int TempInt1 = 0;
    public int ID;
    string Deck;
    public static bool P1Lost;
    public static bool P2Lost;

    // Cooldown varibales
    bool CoolDown = true;
    bool CoolDownJr;
    int CoolDownint = MainMessageCheckpoint.Hour + 1;

    // varibles for Abilites
    int AbilityStats;
    bool LeftClicked;
    bool Wait = true;
    bool Prompt;
    bool Prompt2;
    bool Open; // I don't know what this does, there isn't a error, and I fear the consiquences of removing it

    // varibles for stats
    bool BlockBool;
    int OriginID;
    int CardListNumber = 0;
    int HeP = -1;
    #region abilities
    int[] HealthChange;
    int DamAbsorb;
    int ArmorInt;
    bool Inhabiting;
    bool Inhabited;
    int Counter;
    int PoisonDamInt;
    int PoisonDurrationInt;
    int PoisonWeakInt;
    int[] PoisonStats = new int[4];
    int[] HarmPoisonStats = new int[4];
    bool Poisoned;
    bool HasNegateAttack;
    int NegateAttacks;
    bool HasMultiHit;
    int MultiHitInt;
    int AgMultiHitInt;
    int StunDuration;
    int[] TempStats = new int[3];
    bool Cannibalizing;
    int ResID;
    #endregion
    #region ability OpenTo___
    bool OpenToAttack;
    bool OpenToPoison;
    bool OpenToCannibalize;
    bool OpenToRes; // an exception to being in void closed
    #endregion

    void Closed()
    {
        // set all varibles in ability OpenTo___ to false
        OpenToAttack = false;
        OpenToPoison = false;
        OpenToCannibalize = false;
        Cannibalizing = false;
        AgMultiHitInt = 0;
        Prompt = false;
        Prompt2 = false;
        TempStats[0] = 0;
        TempStats[1] = 0;
        TempStats[2] = 0;
    }

    void Turn(int turn)
    {
        Player = turn;
    }


    // *REMEMBER* Awake is when the object is inzlied, so DIFFERENT from Start
    void Awake()
    {
        #region code here to decide what decks are chosen
        if (ID == 1)
        {
            #region P1Deck
            if (TweenSceneManager.P1Deck == "Spindle")
            {
                CardListNumber = 25;
            }
            #endregion
        }
        else if (ID == 2)
        {
            #region P2Deck
            if (TweenSceneManager.P2Deck == "Spindle")
            {
                CardListNumber = 25;
            }
            #endregion
        }
        else
        {
            Debug.Log("I forgot to assine an ID to a ruler");
        }
        #endregion
        CardListNumber += 1;
        Deck = SpawnManagerScriptableObject.CardList[CardListNumber].Name;
        HeP = SpawnManagerScriptableObject.CardList[CardListNumber].HealthPoints;
        Abilities();
        Traits();
    }

    // Update is called once per frame
    void Update()
    {
        if (HeP == 0)
        {
            if (ID == 1)
            {
                P1Lost = true;
            }
            else if (ID == 2)
            {
                P2Lost = true;
            }
        }

        if (Prompt == true)
        {
            if (Input.GetKeyDown("y"))
            {
                Debug.Log("Click the card you want to block with");
                SendMessageUpwards("SendBlock", -1);
            }
            if (Input.GetKeyDown("n"))
            {
                Wait = false;
                Prompt = false;
                Debug.Log("click on the card again to procide");
            }
        }

        if (Prompt2 == true)
        {
            if (Deck == "Spindle")
            {
                if (Input.GetKeyDown("1"))
                {
                    Prompt2 = false;
                    SendMessageUpwards("SendRefresh");
                    SendMessageUpwards("LazyPassTurn");
                }
                if (Input.GetKeyDown("2"))
                {
                    Prompt2 = false;
                    SendMessageUpwards("SendSongOfVenom");
                    SendMessageUpwards("LazyPassTurn");
                }
            }
        }

        if (CoolDownint == MainMessageCheckpoint.Hour)
        {
            CoolDown = false;
        }
    }

    void OnMouseOver()
    {
        CurentCard.text = Deck + " P" + ID;
        Cost.text = "Bio Cost: " + "n/a" + "\n" + "Geo Cost: " + "n/a";
        HP.text = "HP: " + HeP;
        ClassSpecies.text = "Class: " + SpawnManagerScriptableObject.CardList[CardListNumber].Class + "\n" + "Species: " + SpawnManagerScriptableObject.CardList[CardListNumber].Species;
        Ability1Text.text = "Ability1: " + Ability1 + "\n" + "Power: " + AbilityStats1[0] + "\n" + "Cool Down: " + AbilityStats1[1];
        Ability2Text.text = "Ability2: " + Ability2 + "\n" + "Power: " + AbilityStats2[0] + "\n" + "Cool Down: " + AbilityStats2[1];
        Ability3Text.text = "Ability3: " + Ability3 + "\n" + "Power: " + AbilityStats3[0] + "\n" + "Cool Down: " + AbilityStats3[1];
        Ability4Text.text = "Ability4: " + Ability4 + "\n" + "Power: " + AbilityStats4[0] + "\n" + "Cool Down: " + AbilityStats4[1];
        Trait1Text.text = "Trait1: " + Trait1;
        Trait2Text.text = "Trait2: " + Trait2;
        Trait3Text.text = "Trait3: " + Trait3;
        Trait4Text.text = "Trait4: " + Trait4;
    }

    void OnMouseDown()
    {
        #region Abilites
        if (MainMessageCheckpoint.HammerTime == true)
        {
            string normal = "a";
            if (OpenToCannibalize == true)
            {
                Cannibalizing = true;
                SendMessageUpwards("Ccccannibalize");
            }
            else if (OpenToAttack == true)
            {
                if (BlockBool == true)
                {
                    if (OriginID == ID)
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
                    if (HeP <= HealthChange[1])
                    {
                        HeP = 0;
                    }
                    else
                    {
                        HeP -= HealthChange[1];
                    }

                    if (OpenToPoison == true && HeP != 0)
                    {
                        Poisoned = true;
                        normal = "b";
                    }

                    if (AgMultiHitInt > 0)
                    {
                        SendMessageUpwards("ReduceHits", AgMultiHitInt);
                        normal = "c";
                    }

                    if (normal == "a" || normal == "b")
                    {
                        SendMessageUpwards("SendClosed");
                    }
                    else if (normal == "c")
                    {
                        SendMessageUpwards("Again", HealthChange[1]);
                    }
                    Wait = true;
                }
                else
                {
                    Debug.Log("Can a bool be nither true nor false? if you are seeing this, then it can");
                }
            }
            else if (OpenToPoison == true)
            {
                Poisoned = true;
                SendMessageUpwards("SendClosed");
            }
            else if (1 == 0)
            {
                // placeholder
            }
            else
            {
                Debug.Log("Card " + Deck + " is not open to being a/e ffected by the ability, use the ability before doing ANYTING else");
            }
        }
        #endregion
        else 
        {
            if (CoolDown == true)
            {
                Debug.Log("sorry bretheren, but you have made the fatal error of forgeting cool down timage");
            }
            else if (Deck == "Spindle")
            {
                Prompt2 = true;
                Debug.Log("Press [1] to play the Song of Vallor or press [2] to play the Song of Venom");
            }
            else if (1 == 0)
            {
                //placeholder
            }
            else
            {
                Debug.Log("Add another Deck ==");
            }

            if (CoolDown == false)
            {
                CoolDownint = MainMessageCheckpoint.Hour - 1;
                CoolDown = true;
            }
        }
    }

    #region Abiblites (sans Abiblites)
    void SubtractHealth(int[] Stats)
    {
        HealthChange = Stats;
        OpenToAttack = true;
    }

    void AgressivePoison(int[] Stats)
    {
        Debug.Log("POG");
        OpenToPoison = true;
        HarmPoisonStats = Stats;
    }

    void Cccannibalize()
    {
        OpenToCannibalize = true;
    }

    void Cccccannibalize()
    {
        OpenToCannibalize = false;
    }

    void Cccccccannibalize(int temp)
    {
        if (Cannibalizing == true)
        {
            GainHeP(temp);
            Cannibalizing = false;
            SendMessageUpwards("LazyPassTurn");
        }
    }

    void GainHeP(int temp)
    {
        HeP += temp;
    }
    #endregion

    #region Addd___    
    void AdddMultiHit(int HitAmount)
    {
        AgMultiHitInt = HitAmount;
    }

    #endregion

    void TimePassing()
    {
        if (Poisoned == true && HarmPoisonStats[1] != 0)
        {
            Debug.Log("Dur P = " + HarmPoisonStats[1]);
            if (Poisoned == true && HarmPoisonStats[1] != 0)
            {
                Debug.Log("Dur I = " + HarmPoisonStats[1]);
                HeP -= HarmPoisonStats[0];
                if (HeP < 0)
                {
                    HeP = 0;
                }
                HarmPoisonStats[1] -= 1;
                if (HeP == 0)
                {
                    Poisoned = false;
                    HarmPoisonStats[1] = 0;
                }
                Debug.Log("Dur J = " + HarmPoisonStats[1]);
            }
            // Word of note: I dont know why, but somehow all of this Debug.Log nonsence fixed a bug. so you cant remove it or poison breaks
            TempInt1 += 1;
            Debug.Log("This scprit has run " + TempInt1 + " times");
        }
    }

    void Block(int Originid)
    {
        BlockBool = true;
        OriginID = Originid;
    }

    void Abilities()
    {
        #region the tower
        int[] Temp = new int[3];
        Temp[0] = -1;
        if (SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 1)
        {
            Temp[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[0];
            Temp[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[0];
            Ability1 = SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[0];
            AbilityStats1[0] = Temp[1];
            AbilityStats1[1] = Temp[2];

            if (SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 2)
            {
                Temp[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[1];
                Temp[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[1];
                Ability2 = SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[1];
                AbilityStats2[0] = Temp[1];
                AbilityStats2[1] = Temp[2];

                if (SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 3)
                {
                    Temp[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[2];
                    Temp[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[2];
                    Ability3 = SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[2];
                    AbilityStats3[0] = Temp[1];
                    AbilityStats3[1] = Temp[2];

                    if (SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 4)
                    {
                        Temp[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[3];
                        Temp[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[3];
                        SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[3], Temp);
                        Ability4 = SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[3];
                        AbilityStats4[0] = Temp[1];
                        AbilityStats4[1] = Temp[2];

                        if (SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 5)
                        {
                            Debug.Log(SpawnManagerScriptableObject.CardList[CardListNumber].Name + " has too many abilities");
                        }
                    }
                    else
                    {
                        Ability4 = "n/a";
                        AbilityStats4[0] = "n/a";
                        AbilityStats4[1] = "n/a";
                    }
                }
                else
                {
                    Ability3 = "n/a";
                    Ability4 = "n/a";
                    AbilityStats3[0] = "n/a";
                    AbilityStats3[1] = "n/a";
                    AbilityStats4[0] = "n/a";
                    AbilityStats4[1] = "n/a";
                }
            }
            else
            {
                Ability2 = "n/a";
                Ability3 = "n/a";
                Ability4 = "n/a";
                AbilityStats2[0] = "n/a";
                AbilityStats2[1] = "n/a";
                AbilityStats3[0] = "n/a";
                AbilityStats3[1] = "n/a";
                AbilityStats4[0] = "n/a";
                AbilityStats4[1] = "n/a";
            }
        }
        else
        {
            Debug.Log("why does " + SpawnManagerScriptableObject.CardList[CardListNumber].Name + " have no abilities?");
            Ability1 = "n/a";
            Ability2 = "n/a";
            Ability3 = "n/a";
            Ability4 = "n/a";
            AbilityStats1[0] = "n/a";
            AbilityStats1[1] = "n/a";
            AbilityStats2[0] = "n/a";
            AbilityStats2[1] = "n/a";
            AbilityStats3[0] = "n/a";
            AbilityStats3[1] = "n/a";
            AbilityStats4[0] = "n/a";
            AbilityStats4[1] = "n/a";
        }
        #endregion
    }

    void Traits()
    {
        #region the tower
        if (SpawnManagerScriptableObject.CardList[CardListNumber].Traits.Length >= 1)
        {
            Trait1 = SpawnManagerScriptableObject.CardList[CardListNumber].Traits[0];

            if (SpawnManagerScriptableObject.CardList[CardListNumber].Traits.Length >= 2)
            {
                Trait2 = SpawnManagerScriptableObject.CardList[CardListNumber].Traits[1];

                if (SpawnManagerScriptableObject.CardList[CardListNumber].Traits.Length >= 3)
                {
                    Trait3 = SpawnManagerScriptableObject.CardList[CardListNumber].Traits[2];

                    if (SpawnManagerScriptableObject.CardList[CardListNumber].Traits.Length >= 4)
                    {
                        Trait4 = SpawnManagerScriptableObject.CardList[CardListNumber].Traits[3];

                        if (SpawnManagerScriptableObject.CardList[CardListNumber].Traits.Length >= 5)
                        {
                            Debug.Log("this card has too many triats");
                        }
                    }
                    else
                    {
                        Trait4 = "n/a";
                    }
                }
                else
                {
                    Trait3 = "n/a";
                    Trait4 = "n/a";
                }
            }
            else
            {
                Trait2 = "n/a";
                Trait3 = "n/a";
                Trait4 = "n/a";
            }
        }
        else
        {
            Debug.Log("why does " + SpawnManagerScriptableObject.CardList[CardListNumber].Name + " have no traits?");
            Trait1 = "n/a";
            Trait2 = "n/a";
            Trait3 = "n/a";
            Trait4 = "n/a";
        }
        #endregion
    }

}
