using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMessageCheckpoint : MonoBehaviour
{
    // calls my text boxes
    public Text P1BioGeo;
    public Text P2BioGeo;
    public Text PlayerTurn;
    public Text TimeText;
    public Text Misc1Text;
    string Misc1Words;
    public Text Misc2Text;
    string Misc2Words;
    string[] MiscWords = new string[255];
    int CurrentLogCount;
    int CurrentLogShowing;

    // global variables
    public int StartingBio;
    public int StartingGeo;
    public static int P1Bio;
    public static int P1Geo;
    public static int P2Bio;
    public static int P2Geo;
    public static int Turn = 1;
    public static int[] ArrayTurn = new int[1]; // for when turn needs to be an array
    public static int Hour = 12;
    public static bool HammerTime;

    // variables for turn passing
    int AreThouSure;
    bool P1Passed;
    bool P2Passed;
    int TempInt1 = 0;

    #region Trait vars
    bool HasReaching;
    bool HasRange;
    bool HasOverkill;
    bool HasUnblocking;
    bool HasMultiHit;
    int MultiHitInt;
    bool HasUnphased;
    #endregion


    public static void Restart()
    {
        P1Bio = 0;
        P1Geo = 0;
        P2Bio = 0;
        P2Geo = 0;
        Turn = 1;
        ArrayTurn[0] = 1;
        Hour = 12;
        HammerTime = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        P1Bio = StartingBio;
        P1Geo = StartingGeo;
        P2Bio = StartingBio;
        P2Geo = StartingGeo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 3 == 0)
        {
            ArrayTurn[0] = Turn;
        }

        if (P1Passed == true && P2Passed == true)
        {
            Hour += 1;

            if (Hour >= 25)
            {
                Hour = 1;
            }

            TimeText.text = "It is " + Hour + "'o Clock";
            TempInt1 += 1;
            Debug.Log("Time has passed " + TempInt1 + " times");
            P1Passed = false;
            P2Passed = false;
            BroadcastMessage("TimePassing");
        }

        if (P1Passed == true && Turn == 1)
        {
            SendClosed();
            Debug.Log("P1 Passed, and must learn to face the coniquenises");
            MiscText("P1 Passed, and must learn to face the consequences");
            PlayerTurn.text = "Player " + Turn + "'s Turn";
        }

        if (P2Passed == true && Turn == 2)
        {
            SendClosed();
            Debug.Log("P2 Passed, and must learn to face the coniquenises");
            MiscText("P2 Passed, and must learn to face the consequences");
            PlayerTurn.text = "Player " + Turn + "'s Turn";
        }

        if (Input.GetKeyDown("return"))
        {
            if (AreThouSure == 0)
            {
                Debug.Log("Are thou sure?");
                MiscText("Are thou sure?");
                Debug.Log("This will make it player " + Turn + "'s turn no longer");
                MiscText("This will make it player " + Turn + "'s turn no longer");
                AreThouSure = 1;
            }
            else if (AreThouSure == 1)
            {
                if (Turn == 1)
                {
                    P1Passed = true;
                }
                else if (Turn == 2)
                {
                    P2Passed = true;
                }
                else
                {
                    Debug.Log("Turn != 1 && Turn != 0, Yet AreThouSure == 1, BIG Woof");
                }

                TimeText.text = "It is " + Hour + "'o Clock";
                AreThouSure = 0;
                SendClosed();
            }
            else
            {
                Debug.Log("Turn != 1 && Turn != 0, Woof");
            }
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Change(-1);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Change(1);
        }
    }

    #region Making Cards
    void SendApplyStatsP2(int[] TempStorage)
    {
        BroadcastMessage("ApplyStatsP2", TempStorage);
    }

    void SendApplyStatsP1(int[] TempStorage)
    {
        BroadcastMessage("ApplyStatsP1", TempStorage);
    }

    void Exchange()
    {
        if (Turn == 1)
        {
            if (P1Bio >= 10)
            {
                P1Bio -= 10;
                P1Geo += 1;
                P1BioGeo.text = "P1 Bio: " + P1Bio + "\n" + "Geo: " + P1Geo;
                SendClosed();
            }
            else if (P1Bio < 10)
            {
                Debug.Log("yuo do not have enough bio");
                MiscText("You do not have enough bio");
            }
            else
            {
                Debug.Log("how is your bio nither >= 10 nor < 10????????????");
            }
        }
        else if (Turn == 2)
        {
            if (P2Bio >= 10)
            {
                P2Bio -= 10;
                P2Geo += 1;
                P2BioGeo.text = "P2 Bio: " + P2Bio + "\n" + "Geo: " + P2Geo;
                SendClosed();
            }
            else if (P2Bio < 10)
            {
                Debug.Log("yuo do not have enough bio");
                MiscText("You do not have enough bio");
            }
            else
            {
                Debug.Log("how is your bio nither >= 10 nor < 10????????????");
            }
        }
        else
        {
            Debug.Log("It is not player 1 turn nor player 2 turn");
            MiscText("It is not player 1 turn nor player 2 turn");
        }
    }

    void ChangeGeo(int[] change)
    {
        if (change[0] == 1)
        {
            P1Geo += change[1];
            P1BioGeo.text = "P1 Bio: " + P1Bio + "\n" + "Geo: " + P1Geo;
        }
        else if (change[0] == 2)
        {
            P2Geo += change[1];
            P2BioGeo.text = "P2 Bio: " + P2Bio + "\n" + "Geo: " + P2Geo;
        }
        else
        {
            Debug.Log("ChangeGeo was sent, but they forgot to dicide player");
        }
    }

    void ChangeBio(int[] change)
    {
        if (change[0] == 1)
        {
            P1Bio += change[1];
            P1BioGeo.text = "P1 Bio: " + P1Bio + "\n" + "Geo: " + P1Geo;
        }
        else if (change[0] == 2)
        {
            P2Bio += change[1];
            P2BioGeo.text = "P2 Bio: " + P2Bio + "\n" + "Geo: " + P2Geo;
        }
        else
        {
            Debug.Log("ChangeBio was sent, but they forgot to dicide player");
        }
    }
    
    void PassTurn(int[] change)
    {
        if (change[0] == 1)
        {
            Turn = 2;
            PlayerTurn.text = "Player " + Turn + "'s Turn";
            BroadcastMessage("Turn", Turn);
        }
        else if (change[0] == 2)
        {
            Turn = 1;
            PlayerTurn.text = "Player " + Turn + "'s Turn";
            BroadcastMessage("Turn", Turn);
        }
        else
        {
            Debug.Log("PassTurn was sent, but player was not 1 or 2");
        }
    }
    #endregion

    #region Add___
    void AddReaching(int Player)
    {
        HasReaching = true;
    }

    void AddRange(int Player)
    {
        HasRange = true;
    }

    void AddOverkill(int Player)
    {
        HasOverkill = true;
    }

    void AddUnblocking(int Player)
    {
        HasUnblocking = true;
    }

    void AddMultiHit(int Stats)
    {
        Debug.Log("Hello Word");
        HasMultiHit = true;
        MultiHitInt = Stats;
    }
    
    void AddUnphased(int Player)
    {
        HasUnphased = true;
    }
    #endregion

    #region Abiblites
    void SendClosed()
    {
        BroadcastMessage("Closed");
        PassTurn(ArrayTurn);
        HammerTime = false;
    }

    void LazyPassTurn() // Legacy code
    {
        SendClosed();
    }

    void Again(int Stats)
    {
        int[] tempppp = new int[2];
        tempppp[1] = Stats;
        BroadcastMessage("SubtractHealth", tempppp);
    }

    void MinusHealth(int[] Stats)
    {
        if (HasReaching == true)
        {
            BroadcastMessage("AdddReaching", Stats[0]);
            HasReaching = false;
        }
        if (HasRange == true)
        {
            BroadcastMessage("AdddRange", Stats[0]);
            HasRange = false;
        }
        if (HasOverkill == true)
        {
            BroadcastMessage("AdddOverkill", Stats[0]);
            HasOverkill = false;
        }
        if (HasUnblocking == true)
        {
            BroadcastMessage("AdddUnblocking", Stats[0]);
            HasUnblocking = false;
        }
        if (HasMultiHit == true)
        {
            BroadcastMessage("AdddMultiHit", MultiHitInt);
            MultiHitInt = 0;
        }
        if (HasUnphased == true)
        {
            BroadcastMessage("AdddUnphased", Stats[0]);
            HasUnphased = false;
        }
        HammerTime = true;
        BroadcastMessage("SubtractHealth", Stats);
    }

    void Inhabit___(int id)
    {
        HammerTime = true;
    }

    void SendRetalDam(int Stats)
    {
        BroadcastMessage("RetalDam", Stats);
    }
    
    void SendRetalStun(int Stats)
    {
        BroadcastMessage("RetaliationStun", Stats);
    }

    void SendVenom(int[] Stats)
    {
        BroadcastMessage("AgressivePoison", Stats);
        HammerTime = true;
    }

    void SendPoison(int[] Stats)
    {
        // 1 is 2 and 2 is 1 because 1 means that is coming from 1 and going to 2 and vice versa
        // and if you are reading this and wondering why I lettered the letters in the order I did, A-H is in the order I made it, then I-P is just A-H but off set by 8. I dont know where G whent
        if (Stats[3] == 1)
        {
            Debug.Log("Poison Dur F = " + Stats[1]);
            BroadcastMessage("RetaliationPoison2", Stats);
        }
        else if (Stats[3] == 2)
        {
            Debug.Log("Poison Dur O = " + Stats[1]);
            BroadcastMessage("RetaliationPoison1", Stats);
        }
    }

    void SendSpot(int[] Stats)
    {
        HammerTime = true;
        BroadcastMessage("Sspot", Stats);
    }

    void ReduceHits(int HitAmount)
    {
        HasMultiHit = true;
        MultiHitInt = HitAmount - 1;
        Debug.Log("Attacks left: " + MultiHitInt);
        MiscText("Attacks left: " + MultiHitInt);
        BroadcastMessage("AdddMultiHit", MultiHitInt);
        MultiHitInt = 0;
    }

    void SendStun(int[] Stats)
    {
        HammerTime = true;
        BroadcastMessage("Sstun", Stats);
    }

    void SendPatience(int[] Stats)
    {
        HammerTime = true;
        BroadcastMessage("Ppatience", Stats);
    }

    void Ccannibalize()
    {
        HammerTime = true;
    }

    void SendHeal(int[] Stats)
    {
        BroadcastMessage("Hheal", Stats);
        HammerTime = true;
    }
    #endregion

    void MiscText(string Words)
    {
        Misc2Words = Misc1Words;
        Misc1Words = Words;
        MiscWords[CurrentLogCount] = Words;
        Misc1Text.text = Misc1Words;
        Misc2Text.text = Misc2Words;
        CurrentLogCount += 1;
        CurrentLogShowing = CurrentLogCount;
    }
    
    void Change(int temp)
    {
        if (CurrentLogShowing == 0 && temp == -1)
        {
            Debug.Log("Can't go under 0");
        }
        else
        {
            CurrentLogShowing += temp;
        }
        
        Misc2Words = MiscWords[CurrentLogShowing + 1];
        Misc1Words = MiscWords[CurrentLogShowing];
        Misc1Text.text = Misc1Words;
        Misc2Text.text = Misc2Words;
    }
}
