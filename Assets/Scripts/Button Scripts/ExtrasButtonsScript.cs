using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ExtrasButtonsScript : MonoBehaviour
{
    public Button StartSongButt;
    public Button BattleSongButt;
    public Button EndSongButt;
    public Button StopSongsButt;
    public Text ReadMe;
    public Text Rob;
    public Button RobIm;
    public GameObject RobDebug1;
    public GameObject RobDebug2;
    public GameObject RobDebug3;
    public Button RobVidButt;
    public VideoPlayer RobVid;
    public Text Dom;
    public Button DomIm;
    public GameObject DomDebug1;
    public GameObject DomDebug2;
    public GameObject DomDebug3;
    public Button DomVidButt;
    public VideoPlayer DomVid;
    public Text Carl;
    public Button CarlIm;
    public GameObject CarlDebug1;
    public GameObject CarlDebug2;
    public GameObject CarlDebug3;
    public Button CarlVidButt;
    public VideoPlayer CarlVid;
    public Button Me;
    bool TextOnScreen = false;
    bool ShowingIm = false;
    bool PlayingVid = false;

    // Start is called before the first frame update
    void Start()
    {
        HideMost();
        StopSongsButt.gameObject.SetActive(false);
        ShowImport();
    }

    void HideMost()
    {
        TextOnScreen = false; 
        ShowingIm = false;
        PlayingVid = false;
        ReadMe.gameObject.SetActive(false);
        RobIm.gameObject.SetActive(false);
        RobDebug1.gameObject.SetActive(false);
        RobDebug2.gameObject.SetActive(false);
        RobDebug3.gameObject.SetActive(false);
        RobVidButt.gameObject.SetActive(false);
        Dom.gameObject.SetActive(false);
        DomIm.gameObject.SetActive(false);
        DomDebug1.gameObject.SetActive(false);
        DomDebug2.gameObject.SetActive(false);
        DomDebug3.gameObject.SetActive(false);
        DomVidButt.gameObject.SetActive(false);
        Carl.gameObject.SetActive(false);
        CarlIm.gameObject.SetActive(false);
        CarlDebug1.gameObject.SetActive(false);
        CarlDebug2.gameObject.SetActive(false);
        CarlDebug3.gameObject.SetActive(false);
        CarlVidButt.gameObject.SetActive(false);
        Rob.gameObject.SetActive(false);
        Me.gameObject.SetActive(false);
    }

    void ShowImport()
    {
        Rob.gameObject.SetActive(true);
        RobIm.gameObject.SetActive(true);
        RobVidButt.gameObject.SetActive(true);
        Dom.gameObject.SetActive(true);
        DomIm.gameObject.SetActive(true);
        DomVidButt.gameObject.SetActive(true);
        Carl.gameObject.SetActive(true);
        CarlIm.gameObject.SetActive(true);
        CarlVidButt.gameObject.SetActive(true);
        Me.gameObject.SetActive(true);
    }

    void Return()
    {
        if (TextOnScreen == false && ShowingIm == false)
        {
            TweenSceneManager.ResumeMusic();
            SceneManager.LoadScene("Start", LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("Extras");
        }
        else
        {
            HideMost();
            ShowImport();
        }
    }

    void READ()
    {
        HideMost();
        TextOnScreen = true;
        ReadMe.gameObject.SetActive(true);
    }

    void PlayRobVid()
    {
        SendStop();
        PlayingVid = true;
        RobVid.Play();
        RobVid.loopPointReached += EndReached;
    }

    void PlayDomVid()
    {
        SendStop();
        PlayingVid = true;
        DomVid.Play();
        DomVid.loopPointReached += EndReached;
    }

    void PlayCarlVid()
    {
        SendStop();
        PlayingVid = true;
        CarlVid.Play();
        CarlVid.loopPointReached += EndReached;
    }

    void ShowRobIm()
    {
        HideMost();
        ShowingIm = true;
        RobDebug1.gameObject.SetActive(true);
        RobDebug2.gameObject.SetActive(true);
        RobDebug3.gameObject.SetActive(true);
    }

    void ShowDomIm()
    {
        HideMost();
        ShowingIm = true;
        DomDebug1.gameObject.SetActive(true);
        DomDebug2.gameObject.SetActive(true);
        DomDebug3.gameObject.SetActive(true);
    }

    void ShowCarlIm()
    {
        HideMost();
        ShowingIm = true;
        CarlDebug1.gameObject.SetActive(true);
        CarlDebug2.gameObject.SetActive(true);
        CarlDebug3.gameObject.SetActive(true);
    }

    void PlayStartSong()
    {
        StartSongButt.gameObject.SetActive(false);
        BattleSongButt.gameObject.SetActive(true);
        EndSongButt.gameObject.SetActive(true);
        StopSongsButt.gameObject.SetActive(true);
        StopSongsButt.transform.position = new Vector3(-176, 151, 0);
        TweenSceneManager.PlayStart();
    }

    void PlayBattleSong()
    {
        StartSongButt.gameObject.SetActive(true);
        BattleSongButt.gameObject.SetActive(false);
        EndSongButt.gameObject.SetActive(true);
        StopSongsButt.gameObject.SetActive(true);
        StopSongsButt.transform.position = new Vector3(-128, 151, 0);
        TweenSceneManager.PlayBattle();
    }

    void PlayEndSong()
    {
        StartSongButt.gameObject.SetActive(true);
        BattleSongButt.gameObject.SetActive(true);
        EndSongButt.gameObject.SetActive(false);
        StopSongsButt.gameObject.SetActive(true);
        StopSongsButt.transform.position = new Vector3(-80, 151, 0);
        TweenSceneManager.PlayEnd();
    }

    void SendStop()
    {
        StartSongButt.gameObject.SetActive(true);
        BattleSongButt.gameObject.SetActive(true);
        EndSongButt.gameObject.SetActive(true);
        StopSongsButt.gameObject.SetActive(false);
        TweenSceneManager.StopMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayingVid == true && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.UnloadSceneAsync("Extras");
            SceneManager.LoadScene("Extras", LoadSceneMode.Additive);
        }
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.UnloadSceneAsync("Extras");
        SceneManager.LoadScene("Extras", LoadSceneMode.Additive);
    }
}
