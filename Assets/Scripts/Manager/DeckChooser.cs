using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeckChooser : MonoBehaviour
{
    public static string P1Deck;
    public static string P2Deck;
    int Player = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player == 3)
        {
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
    #endregion
}
