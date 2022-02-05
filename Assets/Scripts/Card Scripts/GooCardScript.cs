using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GooCardScript : MonoBehaviour
{
    // calls my data objects
    public SpawnDeckList SpawnDeckList;
    public SpawnManagerScriptableObject SpawnManagerScriptableObject;

    // vanity stuff
    public SpriteRenderer spriteRenderer;

    // calls my text boxes
    public Text CurentCard;
    public Text Cost;
    public Text HP;
    public Text ClassSpecies;
    public Text Ability1Text;
    public Text Ability2Text;
    public Text Ability3Text;
    public Text Ability4Text;
    public Text Trait1Text;
    public Text Trait2Text;
    public Text Trait3Text;
    public Text Trait4Text;

    #region varibles for text boxes
    string Ability1;
    string Ability2;
    string Ability3;
    string Ability4;
    object[] AbilityStats1 = new object[2];
    object[] AbilityStats2 = new object[2];
    object[] AbilityStats3 = new object[2];
    object[] AbilityStats4 = new object[2];
    string Trait1;
    string Trait2;
    string Trait3;
    string Trait4;
    #endregion

    // temp variables

    // varibles for messaging
    int[] TempStorage = new int[2];
    int[] TempResourceStorage = new int[2];
    public bool[] Player1Card = new bool[120];
    public bool[] Player2Card = new bool[120];
    public int id;
    public int Player = 1;
    int[] one = new int[1];
    int[] two = new int[1];

    // Start is called before the first frame update
    void Start()
    {
        // temp variable definations

        // message variable definations
        TempResourceStorage[0] = 1;
        one[0] = 1; // I need these as an array
        two[0] = 2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Turn(int turn)
    {
        Player = turn;
        TempResourceStorage[0] = turn;
    }

    // message funtions
    void ReciveStats(int[] Stats)
    {
        if (Stats[0] == id)
        {
            TempStorage[1] = Stats[1];
            SendMessageUpwards("GooFull", id);
            // insert code to apply sprite and cost
            Debug.Log("GooCard " + id + " tryed to send message upwards");
            Debug.Log("GooCard " + id + " BioCost is " + SpawnManagerScriptableObject.CardList[Stats[1]].BioCost);
            Debug.Log("GooCard " + id + " BioCost is " + SpawnManagerScriptableObject.CardList[Stats[1]].GeoCost);
            Abilities();
            Traits();
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = SpawnManagerScriptableObject.CardList[Stats[1]].Image;
        }
    }

    void OnMouseDown()
    {
        if (Player == 1)
        {
            if (MainMessageCheckpoint.P1Bio >= SpawnManagerScriptableObject.CardList[TempStorage[1]].BioCost)
            {
                if (MainMessageCheckpoint.P1Geo >= SpawnManagerScriptableObject.CardList[TempStorage[1]].GeoCost)
                {
                    SendMessageUpwards("SendApplyStatsP1", TempStorage);
                    SendMessageUpwards("GooNotFull", id);
                    TempResourceStorage[1] = -SpawnManagerScriptableObject.CardList[TempStorage[1]].BioCost;
                    SendMessageUpwards("ChangeBio", TempResourceStorage);
                    TempResourceStorage[1] = -SpawnManagerScriptableObject.CardList[TempStorage[1]].GeoCost;
                    SendMessageUpwards("ChangeGeo", TempResourceStorage);
                    SendMessageUpwards("PassTurn", one);
                }
                else
                {
                    Debug.Log("Player " + Player + " does not have enough Geo; if it is player 2's turn, I am going to cry");
                }
            }
            else
            {
                Debug.Log("Player " + Player + " does not have enough Bio; if it is player 2's turn, I am going to cry");
            }
        }
        else if (Player == 2)
        {
            if (MainMessageCheckpoint.P2Bio >= SpawnManagerScriptableObject.CardList[TempStorage[1]].BioCost)
            {
                if (MainMessageCheckpoint.P2Geo >= SpawnManagerScriptableObject.CardList[TempStorage[1]].GeoCost)
                {
                    SendMessageUpwards("SendApplyStatsP2", TempStorage);
                    SendMessageUpwards("GooNotFull", id);
                    TempResourceStorage[1] = -SpawnManagerScriptableObject.CardList[TempStorage[1]].BioCost;
                    SendMessageUpwards("ChangeBio", TempResourceStorage);
                    TempResourceStorage[1] = -SpawnManagerScriptableObject.CardList[TempStorage[1]].GeoCost;
                    SendMessageUpwards("ChangeGeo", TempResourceStorage);
                    SendMessageUpwards("PassTurn", two);
                }
                else
                {
                    Debug.Log("Player " + Player + " does not have enough Geo; if it is player 1's turn, I am going to cry");
                }
            }
            else
            {
                Debug.Log("Player " + Player + " does not have enough Bio; if it is player 1's turn, I am going to cry");
            }
        }
        else
        {
            Debug.Log("Player != 1 && Player != 2, Player = " + Player);
        }
    }

    void OnMouseOver()
    {
        CurentCard.text = SpawnManagerScriptableObject.CardList[TempStorage[1]].Name;
        Cost.text = "Bio Cost: " + SpawnManagerScriptableObject.CardList[TempStorage[1]].BioCost + "\n" + "Geo Cost: "  + SpawnManagerScriptableObject.CardList[TempStorage[1]].GeoCost;
        HP.text = "HP: " + SpawnManagerScriptableObject.CardList[TempStorage[1]].HealthPoints;
        ClassSpecies.text = "Class: " + SpawnManagerScriptableObject.CardList[TempStorage[1]].Class + "\n" + "Species: " + SpawnManagerScriptableObject.CardList[TempStorage[1]].Species;
        Ability1Text.text = "Ability1: " + Ability1 + "\n" + "Power: " + AbilityStats1[0] + "\n" + "Cool Down: " + AbilityStats1[1];
        Ability2Text.text = "Ability2: " + Ability2 + "\n" + "Power: " + AbilityStats2[0] + "\n" + "Cool Down: " + AbilityStats2[1];
        Ability3Text.text = "Ability3: " + Ability3 + "\n" + "Power: " + AbilityStats3[0] + "\n" + "Cool Down: " + AbilityStats3[1];
        Ability4Text.text = "Ability4: " + Ability4 + "\n" + "Power: " + AbilityStats4[0] + "\n" + "Cool Down: " + AbilityStats4[1];
        Trait1Text.text = "Trait1: " + Trait1;
        Trait2Text.text = "Trait2: " + Trait2;
        Trait3Text.text = "Trait3: " + Trait3;
        Trait4Text.text = "Trait4: " + Trait4;
    }

    void Abilities()
    {
        #region the tower
        int[] Temp = new int[3];
        Temp[0] = -1;
        if (SpawnManagerScriptableObject.CardList[TempStorage[1]].Abilities.Length >= 1)
        {
            Temp[1] = SpawnManagerScriptableObject.CardList[TempStorage[1]].AbilityStats[0];
            Temp[2] = SpawnManagerScriptableObject.CardList[TempStorage[1]].AbilityRefresh[0];
            Ability1 = SpawnManagerScriptableObject.CardList[TempStorage[1]].Abilities[0];
            AbilityStats1[0] = Temp[1];
            AbilityStats1[1] = Temp[2];

            if (SpawnManagerScriptableObject.CardList[TempStorage[1]].Abilities.Length >= 2)
            {
                Temp[1] = SpawnManagerScriptableObject.CardList[TempStorage[1]].AbilityStats[1];
                Temp[2] = SpawnManagerScriptableObject.CardList[TempStorage[1]].AbilityRefresh[1];
                Ability2 = SpawnManagerScriptableObject.CardList[TempStorage[1]].Abilities[1];
                AbilityStats2[0] = Temp[1];
                AbilityStats2[1] = Temp[2];

                if (SpawnManagerScriptableObject.CardList[TempStorage[1]].Abilities.Length >= 3)
                {
                    Temp[1] = SpawnManagerScriptableObject.CardList[TempStorage[1]].AbilityStats[2];
                    Temp[2] = SpawnManagerScriptableObject.CardList[TempStorage[1]].AbilityRefresh[2];
                    Ability3 = SpawnManagerScriptableObject.CardList[TempStorage[1]].Abilities[2];
                    AbilityStats3[0] = Temp[1];
                    AbilityStats3[1] = Temp[2];

                    if (SpawnManagerScriptableObject.CardList[TempStorage[1]].Abilities.Length >= 4)
                    {
                        Temp[1] = SpawnManagerScriptableObject.CardList[TempStorage[1]].AbilityStats[3];
                        Temp[2] = SpawnManagerScriptableObject.CardList[TempStorage[1]].AbilityRefresh[3];
                        SendMessage(SpawnManagerScriptableObject.CardList[TempStorage[1]].Abilities[3], Temp);
                        Ability4 = SpawnManagerScriptableObject.CardList[TempStorage[1]].Abilities[3];
                        AbilityStats4[0] = Temp[1];
                        AbilityStats4[1] = Temp[2];

                        if (SpawnManagerScriptableObject.CardList[TempStorage[1]].Abilities.Length >= 5)
                        {
                            Debug.Log(SpawnManagerScriptableObject.CardList[TempStorage[1]].Name + " has too many abilities");
                        }
                    }
                    else
                    {
                        Ability4 = "n/a";
                        AbilityStats4[0] = "n/a";
                        AbilityStats4[1] = "n/a";
                    }
                }
                else
                {
                    Ability3 = "n/a";
                    Ability4 = "n/a";
                    AbilityStats3[0] = "n/a";
                    AbilityStats3[1] = "n/a";
                    AbilityStats4[0] = "n/a";
                    AbilityStats4[1] = "n/a";
                }
            }
            else
            {
                Ability2 = "n/a";
                Ability3 = "n/a";
                Ability4 = "n/a";
                AbilityStats2[0] = "n/a";
                AbilityStats2[1] = "n/a";
                AbilityStats3[0] = "n/a";
                AbilityStats3[1] = "n/a";
                AbilityStats4[0] = "n/a";
                AbilityStats4[1] = "n/a";
            }
        }
        else
        {
            Debug.Log("why does " + SpawnManagerScriptableObject.CardList[TempStorage[1]].Name + " have no abilities?");
            Ability1 = "n/a";
            Ability2 = "n/a";
            Ability3 = "n/a";
            Ability4 = "n/a";
            AbilityStats1[0] = "n/a";
            AbilityStats1[1] = "n/a";
            AbilityStats2[0] = "n/a";
            AbilityStats2[1] = "n/a";
            AbilityStats3[0] = "n/a";
            AbilityStats3[1] = "n/a";
            AbilityStats4[0] = "n/a";
            AbilityStats4[1] = "n/a";
        }
        #endregion
    }

    void Traits()
    {
        #region the tower
        if (SpawnManagerScriptableObject.CardList[TempStorage[1]].Traits.Length >= 1)
        {
            Trait1 = SpawnManagerScriptableObject.CardList[TempStorage[1]].Traits[0];

            if (SpawnManagerScriptableObject.CardList[TempStorage[1]].Traits.Length >= 2)
            {
                Trait2 = SpawnManagerScriptableObject.CardList[TempStorage[1]].Traits[1];

                if (SpawnManagerScriptableObject.CardList[TempStorage[1]].Traits.Length >= 3)
                {
                    Trait3 = SpawnManagerScriptableObject.CardList[TempStorage[1]].Traits[2];

                    if (SpawnManagerScriptableObject.CardList[TempStorage[1]].Traits.Length >= 4)
                    {
                        Trait4 = SpawnManagerScriptableObject.CardList[TempStorage[1]].Traits[3];

                        if (SpawnManagerScriptableObject.CardList[TempStorage[1]].Traits.Length >= 5)
                        {
                            Debug.Log("this card has too many triats");
                        }
                    }
                    else
                    {
                        Trait4 = "n/a";
                    }
                }
                else
                {
                    Trait3 = "n/a";
                    Trait4 = "n/a";
                }
            }
            else
            {
                Trait2 = "n/a";
                Trait3 = "n/a";
                Trait4 = "n/a";
            }
        }
        else
        {
            Debug.Log("why does " + SpawnManagerScriptableObject.CardList[TempStorage[1]].Name + " have no traits?");
            Trait1 = "n/a";
            Trait2 = "n/a";
            Trait3 = "n/a";
            Trait4 = "n/a";
        }
        #endregion
    }

}