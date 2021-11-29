using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulerScript : MonoBehaviour
{
    public int ID;
    int HeP;
    string Deck;

    // calls my text boxes
    public Text CurentCard;
    public Text Cost;
    public Text HP;


    // *REMEMBER* Awake is when the object is inzlied, so DIFFERENT from Start
    void Awake()
    {
        #region code here to decide what decks are chosen
        if (ID == 0)
        {
            #region P1Deck
            if (TweenSceneManager.P1Deck == "Spindle")
            {
                Deck = "Spindle";
                HeP = 1;
            }
            #endregion
        }
        else if (ID == 1)
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

    }

    void OnMouseOver()
    {
        CurentCard.text = "Current Card: " + "\n" + Deck;
        if (ID == 0)
        {
            Debug.Log("And the ruler picked is " + TweenSceneManager.P1Deck + " I hope to god that they are the same");
        }
        if (ID == 1)
        {
            Debug.Log("And the ruler picked is " + TweenSceneManager.P2Deck + " I hope to god that they are the same");
        }
        Cost.text = "Bio Cost: " + "n/a" + "\n" + "Geo Cost: " + "n/a";
        HP.text = "HP: " + HeP;
    }
}