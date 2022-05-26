using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TweenSceneManager : MonoBehaviour
{
    public static string P1Deck;
    public static string P2Deck;
    public static int Loser;
    bool once = false;

    public AudioSource TempIntroMusic;
    public AudioSource TempChooseMusic;
    public AudioSource TempBattleMusic;
    public AudioSource TempEndingMusic;
    public static AudioSource IntroMusic;
    public static AudioSource ChooseMusic;
    public static AudioSource BattleMusic;
    public static AudioSource EndingMusic;
    public static int MusicLevel = 0;

    public static void Restart()
    {
        P1Deck = "";
        P2Deck = "";
        Loser = 0;
        MusicLevel = 0;
    }

    void Awake()
    {
        SceneManager.LoadScene("Start", LoadSceneMode.Additive);
    }

    // Start is called before the first frame update
    void Start()
    {
        IntroMusic = TempIntroMusic;
        // ChooseMusic = TempChooseMusic;
        BattleMusic = TempBattleMusic;
        EndingMusic = TempEndingMusic;
        IntroMusic.Play();
    }

    public static void AdvanceMusic()
    {
        MusicLevel += 1;
        if (MusicLevel == 1)
        {
            //IntroMusic.Stop();
            //ChooseMusic.Play();
        }
        else if (MusicLevel == 2)
        {
            IntroMusic.Stop();
            //ChooseMusic.Stop();
            BattleMusic.Play();
            P1Deck = DeckChooser.P1Deck;
            P2Deck = DeckChooser.P2Deck;
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

    public static void PauseMusic()
    {
        if (MusicLevel == 0)
        {
            IntroMusic.Pause();
        }
        else if (MusicLevel == 1)
        {
            //ChooseMusic.Pause();
        }
        else if (MusicLevel == 2)
        {
            BattleMusic.Pause();
        }
        else if (MusicLevel == 3)
        {
            EndingMusic.Pause();
        }
        else
        {
            Debug.Log("MusicLevel == " + MusicLevel);
        }
    }

    public static void ResumeMusic()
    {
        if (MusicLevel == 0)
        {
            IntroMusic.UnPause();
        }
        else if (MusicLevel == 1)
        {
            //ChooseMusic.UnPause();
        }
        else if (MusicLevel == 2)
        {
            BattleMusic.UnPause();
        }
        else if (MusicLevel == 3)
        {
            EndingMusic.UnPause();
        }
        else
        {
            Debug.Log("MusicLevel == " + MusicLevel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (RulerScript.P1Lost == true)
        {
            if (RulerScript.P2Lost == true)
            {
                Loser = 0;
            }
            else 
            {
                Loser = 1;
            }

            if (once == false)
            {
                AdvanceMusic();
                SceneManager.LoadScene("End", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("Battle");
                once = true;
            }

        }
        else if (RulerScript.P2Lost == true)
        {
            Loser = 2;
            if (once == false)
            {
                AdvanceMusic();
                SceneManager.LoadScene("End", LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync("Battle");
                once = true;
            }
        }
    }
}
