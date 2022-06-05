using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeckChooser : MonoBehaviour
{
    public Text PlayerInfo;
    public static string P1Deck;
    public static string P2Deck;
    int Player = 1;
    public static bool onceonceonce = false;
    public GameObject AreYouSure;
    public GameObject Warning;
    public GameObject ContinueButton;
    public GameObject ReturnButton;

    public static void Restart()
    {
        P1Deck = "";
        P2Deck = "";
        onceonceonce = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        AreYouSure.gameObject.SetActive(false);
        Warning.gameObject.SetActive(false);
        ContinueButton.gameObject.SetActive(false);
        ReturnButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInfo.text = "Player " + Player + ": choose your Ruler";
        if (Player == 3)
        {
            TweenSceneManager.AdvanceMusic();
            SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Choose");
        }

    }

    #region Decks
    void Spindle()
    {
        if (Player == 1)
        {
            P1Deck = "Spindle";
            Player += 1;
        }
        else if (Player == 2)
        {
            P2Deck = "Spindle";
            Player += 1;
        }
        else
        {
            Debug.Log("Why and how did you choose a deck when it was nither player 1's turn nor player 2's?");
        }
    }
    
    void Tyrnell()
    {
        if (Player == 1)
        {
            P1Deck = "Tyrnell";
            Player += 1;
        }
        else if (Player == 2)
        {
            P2Deck = "Tyrnell";
            Player += 1;
        }
        else
        {
            Debug.Log("Why and how did you choose a deck when it was nither player 1's turn nor player 2's?");
        }
    }

    void TyrnellWait()
    {
        AreYouSure.gameObject.SetActive(true);
        Warning.gameObject.SetActive(true);
        ContinueButton.gameObject.SetActive(true);
        ReturnButton.gameObject.SetActive(true);
    }

    void Return()
    {
        AreYouSure.gameObject.SetActive(false);
        Warning.gameObject.SetActive(false);
        ContinueButton.gameObject.SetActive(false);
        ReturnButton.gameObject.SetActive(false);
    }
    #endregion
}
