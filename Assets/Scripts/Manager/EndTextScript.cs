using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTextScript : MonoBehaviour
{
    public Text WinInfo;
    public Text RulerInfo;
    string P1;
    string P2;

    // Start is called before the first frame update
    void Start()
    {
        P1 = TweenSceneManager.P1Deck;
        P2 = TweenSceneManager.P2Deck;
        if (TweenSceneManager.Winner == 0)
        {
            WinInfo.text = "It's a tie!";
            RulerInfo.text = "That's wicked!";
        }
        else if (TweenSceneManager.Winner == 1)
        {
            WinInfo.text = "Player 1 Wins!!!";
            RulerInfo.text = "Good job " + P1 + " for beating " + P2 + "!";
        }
        else if (TweenSceneManager.Winner == 2)
        {
            WinInfo.text = "Player 2 Wins!!!";
            RulerInfo.text = "Good job " + P2 + " for beating " + P1 + "!";
        }
        else
        {
            Debug.Log("TweenSceneManager.Winner != 0 || 1 || 2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
