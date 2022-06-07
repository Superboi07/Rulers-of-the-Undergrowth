using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ExtrasButtonsScript : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Text ReadMe;
    public Button Tut;
    public Button Vid;
    public Button Me;
    bool TextOnScreen = false;

    // Start is called before the first frame update
    void Start()
    {
        ReadMe.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Return()
    {
        if (TextOnScreen == false)
        {
            TweenSceneManager.ResumeMusic();
            SceneManager.LoadScene("Start", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Extras");
        }
        else
        {
            TextOnScreen = false;
            ReadMe.gameObject.SetActive(false);
            Tut.gameObject.SetActive(true);
            Vid.gameObject.SetActive(true);
            Me.gameObject.SetActive(true);
        }
    }

    void READ()
    {
        ReadMe.gameObject.SetActive(true);
        Tut.gameObject.SetActive(false);
        Vid.gameObject.SetActive(false);
        Me.gameObject.SetActive(false);
        TextOnScreen = true;
    }

    void Video()
    {
        videoPlayer.Play();
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.UnloadSceneAsync("Extras");
        SceneManager.LoadScene("Extras", LoadSceneMode.Additive);
    }
}
