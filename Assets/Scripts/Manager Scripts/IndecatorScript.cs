using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndecatorScript : MonoBehaviour
{
    void RemoveReady()
    {
        if (this.gameObject.name == "Ready Glow(Clone)")
        {
            Destroy(this.gameObject);
        }
    }

    void RemoveAll()
    {
        Destroy(this.gameObject);
    }

    // *REMEMBER* Awake is when the object is inzlied, so DIFFERENT from Start
    void Awake()
    {
        if (this.gameObject.name == "Ready Glow(Clone)")
        {
            SendMessageUpwards("CheckIfZero");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
