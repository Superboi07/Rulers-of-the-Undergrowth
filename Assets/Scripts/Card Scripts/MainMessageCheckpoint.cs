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
            P1Passed = false;
            P2Passed = false;
        }

        if (P1Passed == true && Turn == 1)
        {
            Turn = 2;
            Debug.Log("P1 Passed, and must learn to face the coniquenises");
            PlayerTurn.text = "Player " + Turn + "'s Turn";
            BroadcastMessage("Turn", Turn);
        }

        if (P2Passed == true && Turn == 2)
        {
            Turn = 1;
            Debug.Log("P2 Passed, and must learn to face the coniquenises");
            PlayerTurn.text = "Player " + Turn + "'s Turn";
            BroadcastMessage("Turn", Turn);
        }

        if (Input.GetKeyDown("return"))
        {
            if (AreThouSure == 0)
            {
                Debug.Log("Are thou sure?");
                Debug.Log("This will make it player " + Turn + "'s turn no longer");
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
            }
            else
            {
                Debug.Log("Turn != 1 && Turn != 0, Woof");
            }
            BroadcastMessage("Turn", Turn);
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
                PassTurn(ArrayTurn);
            }
            else if (P1Bio < 10)
            {
                Debug.Log("yuo do not have enough bio");
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
                PassTurn(ArrayTurn);
            }
            else if (P2Bio < 10)
            {
                Debug.Log("yuo do not have enough bio");
            }
            else
            {
                Debug.Log("how is your bio nither >= 10 nor < 10????????????");
            }
        }
        else
        {
            Debug.Log("It is not player 1 turn yet not player 2 turn");
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
            P2BioGeo.text = "P1 Bio: " + P2Bio + "\n" + "Geo: " + P2Geo;
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
            P2BioGeo.text = "P1 Bio: " + P2Bio + "\n" + "Geo: " + P2Geo;
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
            Debug.Log("PassTurn was sent, but they forgot to dicide player");
        }
    }
    #endregion

    #region Abiblites
    void SendClosed()
    {
        BroadcastMessage("Closed");
        PassTurn(ArrayTurn);
        HammerTime = false;
    }
    void MinusHealth(int[] Stats)
    {
        HammerTime = true;
        BroadcastMessage("SubtractHealth", Stats);
    }
    #endregion

    void LazyPassTurn()
    {
        PassTurn(ArrayTurn);
    }
}
