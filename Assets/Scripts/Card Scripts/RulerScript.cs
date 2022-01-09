using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RulerScript : MonoBehaviour
{
    public int ID;
    int HeP;
    string Deck;
    

    // calls my text boxes
    public Text CurentCard;
    public Text Cost;
    public Text HP;

    // varibles for stats
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


    // *REMEMBER* Awake is when the object is inzlied, so DIFFERENT from Start
    void Awake()
    {
        #region code here to decide what decks are chosen
        if (ID == -1)
        {
            #region P1Deck
            if (TweenSceneManager.P1Deck == "Spindle")
            {
                Deck = "Spindle";
                HeP = 1;
            }
            #endregion
        }
        else if (ID == -2)
        {
            #region P2Deck
            if (TweenSceneManager.P2Deck == "Spindle")
            {
                Deck = "Spindle";
                HeP = 1;
            }
            #endregion
        }
        else
        {
            Debug.Log("I forgot to assine an ID to a ruler");
        }
        #endregion

    }

    // Update is called once per frame
    void Update()
    {
        if (HeP == 0)
        {
            SceneManager.LoadScene("End", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Battle");
        }
    }

    void OnMouseOver()
    {
        CurentCard.text = "Current Card: " + "\n" + Deck;
        if (ID == 0)
        {

        }
        if (ID == 1)
        {

        }
        Cost.text = "Bio Cost: " + "n/a" + "\n" + "Geo Cost: " + "n/a";
        HP.text = "HP: " + HeP;
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
                Debug.Log("Ruler " + Deck + " is not open to being a/e ffected by the ability, use the ability before doing ANYTING else");
            }
        }
        #endregion
    }

    #region Abiblites
    void SubtractHealth(int[] Stats)
    {
        HealthChange = Stats;
        OpenToAttack = true;
    }
    #endregion
}
