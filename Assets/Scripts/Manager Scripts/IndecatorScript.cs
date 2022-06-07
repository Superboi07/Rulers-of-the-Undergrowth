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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
