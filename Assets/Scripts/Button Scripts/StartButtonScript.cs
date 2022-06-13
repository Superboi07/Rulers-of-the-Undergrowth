using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    public static bool onceonce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Begin()
    {
        TweenSceneManager.AdvanceMusic();
        SceneManager.LoadScene("Choose", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Start");
    }

    void Exit()
    {
        Debug.Log("It quit");
        Application.Quit();
    }

    void Extras()
    {
        TweenSceneManager.StopMusic();
        SceneManager.LoadScene("Extras", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Start");
    }
}
