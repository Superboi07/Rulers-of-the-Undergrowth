using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ChooseAnimatoin : MonoBehaviour
{
    // calls my data objects
    public SpawnDeckList SpawnDeckList;
    public SpawnManagerScriptableObject SpawnManagerScriptableObject;

    // vanity stuff
    public SpriteRenderer spriteRenderer;
    public Animator Anim;

    public int CardListNumber;

    void Awake()
    {
        CardListNumber += 1;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = SpawnManagerScriptableObject.CardList[CardListNumber].Image;
        Anim = gameObject.GetComponent<Animator>();
        Anim.runtimeAnimatorController = SpawnManagerScriptableObject.CardList[CardListNumber].RulerImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
