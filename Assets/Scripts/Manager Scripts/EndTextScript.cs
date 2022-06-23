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
        if (TweenSceneManager.Loser == 0) // this doesn't work, and I am in no mood to fix it
        {
            RulerInfo.text = "It's a tie!";
            WinInfo.text = "That's wicked!";
        }
        else if (TweenSceneManager.Loser == 1)
        {
            RulerInfo.text = P2 + " has defeated " + P1 + "!";
            WinInfo.text = "Congradulations to player 2!";
        }
        else if (TweenSceneManager.Loser == 2)
        {
            RulerInfo.text = P1 + " has defeated " + P2 + "!";
            WinInfo.text = "Congradulations to player 1!";
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
