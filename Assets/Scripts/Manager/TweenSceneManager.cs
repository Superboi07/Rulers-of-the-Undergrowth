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

    public AudioSource IntroMusic;
    public AudioSource ChooseMusic;
    public AudioSource BattleMusic;
    public AudioSource EndingMusic;
    int MusicLevel = 0;
    bool onceonce = false;
    bool onceonceonce = false;


    // Start is called before the first frame update
    void Start()
    {
        IntroMusic.Play();
    }

    void AdvanceMusic()
    {
        MusicLevel += 1;
        if (MusicLevel == 1)
        {
            IntroMusic.Stop();
            ChooseMusic.Play();
        }
        else if (MusicLevel == 2)
        {
            ChooseMusic.Stop();
            BattleMusic.Play();
        }
        else if (MusicLevel == 3)
        {
            BattleMusic.Stop();
            EndingMusic.Play();
        }
        else 
        {
            Debug.Log("MusicLevel == " + MusicLevel);
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (StartButtonScript.onceonce == true)
        {
            if (onceonce == false)
            {
                AdvanceMusic();
                onceonce = true;
            }
        }

        if (DeckChooser.onceonceonce == true)
        {
            if (onceonceonce == false)
            {
                AdvanceMusic();
                onceonceonce = true;
            }
        }

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
                AdvanceMusic();
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
                AdvanceMusic();
                SceneManager.LoadScene("End", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("Battle");
                once = true;
            }
            Winner = 2;
        }
    }
}
