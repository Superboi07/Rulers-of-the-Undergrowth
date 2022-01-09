using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamra : MonoBehaviour
{
    [SerializeField]
    private GameObject Gameobject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Gameobject.transform.position;
        pos.y += Input.mouseScrollDelta.y * 2;
        Gameobject.transform.position = pos;
    }
}
