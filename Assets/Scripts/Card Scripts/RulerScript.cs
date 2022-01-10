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

    // varibles for messaging
    int[] PlayerAndStats = new int[2];
    int[] PlayerAndID = new int[2];
    int Player = 1;
    int TempInt1 = 0;
    public int ID;
    string Deck;

    // varibles for Abilites
    int AbilityStats;
    bool LeftClicked;
    bool Wait = true;
    bool Prompt;
    bool Open; // I don't know what this does, there isn't a error, and I fear the consiquences of removing it

    // varibles for stats
    bool BlockBool;
    int OriginID;
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
        int CardListNumber = 0;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (HeP == 0)
        {
            SceneManager.LoadScene("End", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Battle");
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
    }

    void OnMouseOver()
    {
        CurentCard.text = "Current Card: " + "\n" + Deck + "\n" + "Player: " + ID;
        Cost.text = "Bio Cost: " + "n/a" + "\n" + "Geo Cost: " + "n/a";
        HP.text = "HP: " + HeP;
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
            if (Deck == "Spindle")
            {

            }
            else if (1 == 0)
            {
                //placeholder
            }
            else
            {
                Debug.Log("Add another Deck ==");
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
}
