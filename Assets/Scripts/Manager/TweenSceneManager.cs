using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenSceneManager : MonoBehaviour
{
    public static string P1Deck;
    public static string P2Deck;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DeckChooser.P1Deck == "Spindle")
        {
            P1Deck = "Spindle";
        }

        if (DeckChooser.P2Deck == "Spindle")
        {
            P2Deck = "Spindle";
        }
    }
}
