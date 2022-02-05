using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voids : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        SendMessageUpwards("MiscText", " ");
        SendMessageUpwards("MiscText", " ");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
