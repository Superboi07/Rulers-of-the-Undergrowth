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

    void henlo()
    {
        onceonce = true;
        SceneManager.LoadScene("Choose", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Start");
    }
}
