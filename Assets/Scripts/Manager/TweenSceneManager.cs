using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TweenSceneManager : MonoBehaviour
{
    public static string P1Deck;
    public static string P2Deck;
    public static int Winner;
    bool once = false;

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

        if (RulerScript.P1Lost == true)
        {
            if (once == false)
            {
                SceneManager.LoadScene("End", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("Battle");
                once = true;
            }

            if (RulerScript.P2Lost == true)
            {
                Winner = 0;
            }
            else 
            {
                Winner = 1;
            }
        }
        else if (RulerScript.P2Lost == true)
        {
            if (once == false)
            {
                SceneManager.LoadScene("End", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("Battle");
                once = true;
            }
            Winner = 2;
        }
    }
}
