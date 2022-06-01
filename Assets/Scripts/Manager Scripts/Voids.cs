using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voids : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake() // This is curently the only reason this exists, for some reason / Notes: MiscLogs go in reverse order (players see the bottom message above the first), and the messages are about as long as you can make them without over-flowing.
    {
        SendMessageUpwards("MiscText", "Ask Robert about what keys to press because there is no tutorial yet.");
        SendMessageUpwards("MiscText", "The game has begun! Look here for some useful info after doing stuff.");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
