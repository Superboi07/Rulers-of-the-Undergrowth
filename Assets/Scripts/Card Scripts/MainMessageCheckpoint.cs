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
    public Text Time;

    // global variables
    int P1Bio;
    int P1Geo;
    int P2Bio;
    int P2Geo;
    int Turn = 1;
    int Hour = 12;
    int AreThouSure;
    bool P1Passed;
    bool P2Passed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (P1Passed == true && P2Passed == true)
        {
            Hour += 1;

            if (Hour >= 25)
            {
                Hour = 1;
            }

            Time.text = "It is " + Hour + "'o Clock";
            P1Passed = false;
            P2Passed = false;
        }

        if (P1Passed == true && Turn == 1)
        {
            Turn = 2;
            Debug.Log("P1 Passed, and must learn to face the coniquenises");
            PlayerTurn.text = "Player " + Turn + "'s Turn";
        }

        if (P2Passed == true && Turn == 2)
        {
            Turn = 1;
            Debug.Log("P2 Passed, and must learn to face the coniquenises");
            PlayerTurn.text = "Player " + Turn + "'s Turn";
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

                Time.text = "It is " + Hour + "'o Clock";
                AreThouSure = 0;
            }
            else
            {
                Debug.Log("Turn != 1 && Turn != 0, Woof");
            }
        }
    }

    void SendApplyStatsP2(int[] TempStorage)
    {
        BroadcastMessage("ApplyStatsP2", TempStorage);
    }

    void SendApplyStatsP1(int[] TempStorage)
    {
        BroadcastMessage("ApplyStatsP1", TempStorage);
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
        }
        else if (change[0] == 2)
        {
            Turn = 1;
            PlayerTurn.text = "Player " + Turn + "'s Turn";
        }
        else
        {
            Debug.Log("PassTurn was sent, but they forgot to dicide player");
        }
    }
}
