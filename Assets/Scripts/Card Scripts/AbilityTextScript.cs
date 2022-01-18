using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityTextScript : MonoBehaviour
{
    public Text Ability1Text;
    public Text Ability2Text;
    public Text Ability3Text;
    public Text Ability4Text;
    public Text Trait1Text;
    public Text Trait2Text;
    public Text Trait3Text;
    public Text Trait4Text;
    int Posishoin = 1;

    // Start is called before the first frame update
    void Start()
    {
        Change();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("left"))
        {
            Posishoin += 1; 
            if (Posishoin == 5)
            {
                Posishoin = 1;
            }
            Change();
        }

        if (Input.GetButtonDown("right"))
        {
            Posishoin -= 1;
            if (Posishoin == 0)
            {
                Posishoin = 4;
            }
            Change();
        }
    }

    void Change()
    {
        if (Posishoin == 1)
        {
            Ability1Text.gameObject.SetActive(true);
            Ability2Text.gameObject.SetActive(false);
            Ability3Text.gameObject.SetActive(false);
            Ability4Text.gameObject.SetActive(false);
            Trait1Text.gameObject.SetActive(true);
            Trait2Text.gameObject.SetActive(false);
            Trait3Text.gameObject.SetActive(false);
            Trait4Text.gameObject.SetActive(false);
        }
        else if (Posishoin == 2)
        {
            Ability1Text.gameObject.SetActive(false);
            Ability2Text.gameObject.SetActive(true);
            Ability3Text.gameObject.SetActive(false);
            Ability4Text.gameObject.SetActive(false);
            Trait1Text.gameObject.SetActive(false);
            Trait2Text.gameObject.SetActive(true);
            Trait3Text.gameObject.SetActive(false);
            Trait4Text.gameObject.SetActive(false);
        }
        else if (Posishoin == 3)
        {
            Ability1Text.gameObject.SetActive(false);
            Ability2Text.gameObject.SetActive(false);
            Ability3Text.gameObject.SetActive(true);
            Ability4Text.gameObject.SetActive(false);
            Trait1Text.gameObject.SetActive(false);
            Trait2Text.gameObject.SetActive(false);
            Trait3Text.gameObject.SetActive(true);
            Trait4Text.gameObject.SetActive(false);
        }
        else if (Posishoin == 4)
        {
            Ability1Text.gameObject.SetActive(false);
            Ability2Text.gameObject.SetActive(false);
            Ability3Text.gameObject.SetActive(false);
            Ability4Text.gameObject.SetActive(true);
            Trait1Text.gameObject.SetActive(false);
            Trait2Text.gameObject.SetActive(false);
            Trait3Text.gameObject.SetActive(false);
            Trait4Text.gameObject.SetActive(true);
        }
    }
}
