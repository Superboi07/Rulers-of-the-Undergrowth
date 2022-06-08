using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Restart()
    {
        TweenSceneManager.Restart();
        RulerScript.Restart();
        DeckChooser.Restart();
        MainMessageCheckpoint.Restart();
        Player1MessageCheckpoint.Restart();
        Player1MessageCheckpoint.Restart();
        SceneManager.LoadScene("TweenScene");
    }
}
