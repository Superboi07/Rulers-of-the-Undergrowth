using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1CardScript : MonoBehaviour
{
    // calls my data objects
    public SpawnDeckList SpawnDeckList;
    public SpawnManagerScriptableObject SpawnManagerScriptableObject;

    // calls my text boxes
    public Text CurentCard;
    public Text HP;

    // varibles for messaging
    public int id;
    int[] PlayerAndStats = new int[2];
    int[] PlayerAndID = new int[2];
    int Player = 1;
    int TempInt1 = 0;

    // varibles for Abilites
    int AbilityStats;
    bool LeftClicked;
    bool Wait = true;
    bool Prompt;
    bool Prompt2;
    bool Open; // I don't know what this does, there isn't a error, and I fear the consiquences of removing it

    // varibles for stats
    bool BlockBool;
    int OriginID;
    int CardListNumber = 0;
    int HeP = -1;
    #region abilities
    int[] HealthChange;
    int DamAbsorb;
    int ArmorInt;
    bool Inhabiting;
    bool Inhabited;
    int Counter;
    bool Attacking = false;
    int PoisonDamInt;
    int PoisonDurrationInt;
    int PoisonWeakInt;
    int[] PoisonStats = new int[4];
    int[] HarmPoisonStats = new int[4];
    bool Poisoned;
    bool HasNegateAttack;
    int NegateAttacks;
    #endregion
    #region traits
    bool HasToxic;
    bool HasStealth;
    bool HasCowardly;
    bool HasFlying;
    bool AgHasReaching;
    bool AgHasRange;
    bool AgHasOverkill;
    bool AgHasUnblocking;
    #endregion
    #region ability OpenTo___
    bool OpenToAttack;
    bool OpenToInhabit;
    bool OpenToInhabiting;
    bool OpenToPoison;
    bool OpenToSpot;
    #endregion

    void Closed()
    {
        // set all varibles in ability OpenTo___ to false
        OpenToAttack = false;
        OpenToInhabit = false;
        OpenToInhabiting = false;
        OpenToPoison = false;
        OpenToSpot = false;
        AgHasReaching = false;
        AgHasRange = false;
        AgHasOverkill = false;
        AgHasUnblocking = false;
        Prompt2 = false;
    }

    void Turn(int turn)
    {
        Player = turn;
    }

    void ReciveGooStats(int[] Stats)
    {
        if (Stats[0] == id)
        {
            // insert code to apply sprite
            Debug.Log("Player1Card (" + id + ") is " + SpawnManagerScriptableObject.CardList[Stats[1]].Name);
            CardListNumber = Stats[1];
            HeP = SpawnManagerScriptableObject.CardList[Stats[1]].HealthPoints;
            // It is important abilities goes first so that Rush Works
            Abilities();
            Class();
            Species();
            Traits();
        }
    }

    void OnMouseDown()
    {
        #region Abilites
        if (MainMessageCheckpoint.HammerTime == true)
        {
            string normal = "a";
            if (OpenToInhabit == true)
            {
                SendMessageUpwards("InhabitingMessage");
                OpenToInhabit = false;
                Inhabited = true;
            }
            else if (OpenToSpot == true)
            {
                if (HasStealth == true)
                {
                    HasStealth = false;
                    SendMessageUpwards("SendClosed");
                    Debug.Log("Stealth has been removed");
                }
                else
                {
                    Debug.Log("This card does not have stealth; you can not spot a coward");
                }
            }
            else if (OpenToAttack == true)
            {
                #region Triats that effect a card's capability of being attacked
                bool IHateThis = false;
                if (BlockBool == false && IHateThis == false)
                {
                    // make the Debug.Logs visible
                    if (Inhabited == true)
                    {
                        Debug.Log("Sorry mate, but this card is inside another card");
                    }
                    else if (HasStealth == true)
                    {
                        Debug.Log("Sorry mate, but you cant see this card");
                    }
                    else if (HasCowardly == true && Player1MessageCheckpoint.VisibleCards >= 1)
                    {
                        Debug.Log("Sorry mate, but this card is a coward");
                    }
                    else if (HasFlying == true)
                    {
                        Debug.Log("Sorry mate, but you cant reach this card");

                        if (AgHasReaching == true)
                        {
                            Debug.Log("Fortunately your card can!");
                            IHateThis = true;
                        }
                    }
                    else
                    {
                        IHateThis = true;
                    }

                    if (AgHasUnblocking == true)
                    {
                        Debug.Log("But it dont matter as your card is a beast");
                        IHateThis = true;
                    }
                }
                else
                {
                    IHateThis = true;
                }
                #endregion

                if (IHateThis == true)
                {
                    if (BlockBool == true)
                    {
                        if (OriginID == id)
                        {
                            Debug.Log("You cant block with the same card, if you misclicked [y], too bad, so sad");
                        }
                        else
                        {
                            Wait = false;
                        }
                    }
                    if (Wait == true)
                    {
                        Debug.Log("Do you want to block using another card? [Y] [N] ps. if you click another card, I think everything will break, so please don't");
                        Prompt = true;
                    }
                    else if (Wait == false)
                    {
                        string God = "alive";
                        #region things that adjust damage caulculation
                        if (AgHasUnblocking == false)
                        {
                            if (HealthChange[1] > ArmorInt && ArmorInt != 0)
                            {
                                HealthChange[1] -= ArmorInt;
                                God = "dead";
                            }
                            else if (ArmorInt != 0)
                            {
                                DamAbsorb = HealthChange[1];
                                HealthChange[1] = 0;
                                God = "very dead";
                            }

                            if (AgHasOverkill == true)
                            {
                                int temptemp = HealthChange[1] - HeP;
                                if (temptemp > 0)
                                {
                                    Debug.Log("OverKill has " + temptemp + " dam left");
                                    SendMessageUpwards("Again", temptemp);
                                    normal = "c";
                                }
                            }

                            if (God == "dead" || God == "very dead" && DamAbsorb != 0)
                            {
                                HeP -= HealthChange[1];
                                HeP += DamAbsorb;

                                if (HeP <= 0)
                                {
                                    HeP = 0;
                                }

                                if (God == "very dead")
                                {
                                    Debug.Log("The damge was less than the attacked card's defences, loser");
                                }
                            }
                        }
                        #endregion
                        if (HeP <= HealthChange[1] && God == "alive")
                        {
                            HeP = 0;
                        }
                        else if (God != "dead" || God != "very dead")
                        {
                            HeP -= HealthChange[1];
                        }
                        #region Things that happen after being attacked
                        if (AgHasUnblocking == false)
                        {
                            if (Counter > 0)
                            {
                                if (AgHasRange == true)
                                {
                                    Debug.Log("Cant counter a ranged attack");
                                    AgHasRange = false;
                                }
                                else
                                {
                                    SendMessageUpwards("SendRetaliation", Counter);
                                }
                                normal = "b";
                            }

                            if (HasToxic == true)
                            {
                                if (AgHasRange == true)
                                {
                                    Debug.Log("Cant poison a ranged attack");
                                    AgHasRange = false;
                                }
                                else
                                {
                                    PoisonStats[0] = PoisonDamInt;
                                    Debug.Log("Poison Dur D = " + PoisonDurrationInt);
                                    PoisonStats[1] = PoisonDurrationInt;
                                    Debug.Log("Poison Dur E = " + PoisonStats[1]);
                                    PoisonStats[2] = PoisonWeakInt;
                                    PoisonStats[3] = 1;
                                    SendMessageUpwards("SendPoison", PoisonStats);
                                }
                                normal = "b";
                            }

                            if (OpenToPoison == true && HeP != 0)
                            {
                                Poisoned = true;
                                normal = "b";
                            }

                            if (normal != "b")
                            {
                                Debug.Log("no after effects");
                            }
                        }
                        #endregion
                        if (normal == "a")
                        {
                            SendMessageUpwards("SendClosed");
                        }
                        Wait = true;
                    }
                    else
                    {
                        Debug.Log("Can a bool be nither true nor false? if you are seeing this, then it can");
                    }
                }
            }
            else if (1 == 0)
            {
                // placeholder
            }
            else
            {
                Debug.Log("Card " + id + " is not open to being a/e ffected by the ability, use the ability before doing ANYTING else");
            }
        }
        #endregion
        else if (Player == 1 && Inhabited == false)
        {
            if (SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length > 0)
            {
                LeftClicked = true;
            }
            else
            {
                Debug.Log(SpawnManagerScriptableObject.CardList[CardListNumber].Name + " has no Abilities or Robert forgot to add them, that idiot");
            }
        }
        else if (Player == 1 && Inhabited == true)
        {
            Debug.Log("This card is inside another card");
        }
        else
        {
            Debug.Log("It is not player 1's turn, it is player " + Player + "'s turn; if that just so happened to be a 1, god help me");
        }
    }

    void OnMouseOver()
    {
        CurentCard.text = "Current Card: " + "\n" + SpawnManagerScriptableObject.CardList[CardListNumber].Name;
        HP.text = "HP: " + HeP;

        if (Prompt2 == true && Input.GetKeyDown("y"))
        {
            NNegateAttack();
            Debug.Log("Attack has been Negated");
            SendMessageUpwards("SendClosed");
        }

        if (LeftClicked == true)
        {
            int[] PlayerAndStatsAndCooldown = new int[3];
            if (Input.GetKeyDown("1") && SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 1)
            {
                PlayerAndStats[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[0];
                PlayerAndStatsAndCooldown[0] = PlayerAndStats[0];
                PlayerAndStatsAndCooldown[1] = PlayerAndStats[1];
                PlayerAndStatsAndCooldown[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[0];
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[0], PlayerAndStatsAndCooldown);
            }
            else if (Input.GetKeyDown("1"))
            {
                Debug.Log(SpawnManagerScriptableObject.CardList[CardListNumber].Name + " has no Abilities or Robert forgot to add them, that idiot");
            }

            if (Input.GetKeyDown("2") && SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 2)
            {
                PlayerAndStats[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[1];
                PlayerAndStatsAndCooldown[0] = PlayerAndStats[0];
                PlayerAndStatsAndCooldown[1] = PlayerAndStats[1];
                PlayerAndStatsAndCooldown[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[1];
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[1], PlayerAndStatsAndCooldown);
            }
            else if (Input.GetKeyDown("2"))
            {
                Debug.Log(SpawnManagerScriptableObject.CardList[CardListNumber].Name + " has only 1 Ability or Robert forgot to add the rest, that idiot");
            }

            if (Input.GetKeyDown("3") && SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 3)
            {
                PlayerAndStats[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[2];
                PlayerAndStatsAndCooldown[0] = PlayerAndStats[0];
                PlayerAndStatsAndCooldown[1] = PlayerAndStats[1];
                PlayerAndStatsAndCooldown[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[2];
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[2], PlayerAndStatsAndCooldown);
            }
            else if (Input.GetKeyDown("3"))
            {
                Debug.Log(SpawnManagerScriptableObject.CardList[CardListNumber].Name + " has only 2 Abilities or Robert forgot to add the rest, that idiot");
            }

            if (Input.GetKeyDown("4") && SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 4)
            {
                PlayerAndStats[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[3];
                PlayerAndStatsAndCooldown[0] = PlayerAndStats[0];
                PlayerAndStatsAndCooldown[1] = PlayerAndStats[1];
                PlayerAndStatsAndCooldown[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[3];
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[3], PlayerAndStatsAndCooldown);
            }
            else if (Input.GetKeyDown("4"))
            {
                Debug.Log(SpawnManagerScriptableObject.CardList[CardListNumber].Name + " has only 3 Abilities or Robert forgot to add the rest, that idiot");
            }
        }
    }

    void Class()
    {
        SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Class, PlayerAndID);
    }

    void Species()
    {
        SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Species, PlayerAndID);
    }

    #region Abiblites (sans Abiblites)
    void SubtractHealth(int[] Stats)
    {
        if (HasNegateAttack == true)
        {
            Debug.Log("If you want to Negate the Attack, mouse over Player " + "1" + " ID " + id + " and press [y]");
            Prompt2 = true;
            Debug.Log("If you don't want to Negate the Attack, just procide like normal");
        }
        HealthChange = Stats;
        OpenToAttack = true;
    }

    void DealDam(int[] Stats)
    {
        Attacking = true;

        #region Things that hppen after attacking
        if (HasToxic == true)
        {
            PoisonStats[0] = PoisonDamInt;
            PoisonStats[1] = PoisonDurrationInt;
            PoisonStats[2] = PoisonWeakInt;
            SendMessageUpwards("SendVenom", PoisonStats);
        }
        #endregion
    }

    void AbsorbDam(int[] Stats)
    {
        DamAbsorb = Stats[1];
        ArmorInt = DamAbsorb;
    }

    void Armor(int[] Stats)
    {
        ArmorInt = Stats[1];
    }

    void Inhabit(int ID)
    {
        if (ID == CardListNumber)
        {
            OpenToInhabit = true;
        }
    }

    void Inhabit___(int IDontNeedThis)
    {
        OpenToInhabiting = true;
    }

    void Inhabitingg()
    {
        if (OpenToInhabiting == true)
        {
            Inhabiting = true;
            Abilities();
            SendMessageUpwards("LazyPassTurn");
        }
    }

    void Closing()
    {
        Attacking = false;
    }

    void Retaliation(int Stats)
    {
        if (Attacking == true)
        {
            HeP -= Stats;
            if (HeP <= 0)
            {
                HeP = 0;
            }
        }
    }

    void RetaliationPoison1(int[] Stats)
    {
        if (Attacking == true)
        {
            Debug.Log("Poison Dur L = " + Stats[1]);
            Poisoned = true;
            HarmPoisonStats = Stats;
            Debug.Log("Poison Dur K = " + HarmPoisonStats[1]);
        }
    }

    void AgressivePoison(int[] Stats)
    {
        Debug.Log("POG");
        OpenToPoison = true;
        HarmPoisonStats = Stats;
    }

    void PoisonDam(int[] Stats)
    {
        PoisonDamInt = Stats[1];
        PoisonDurrationInt = Stats[2];
    }

    void PoisonWeak(int[] Stats)
    {
        PoisonWeakInt = Stats[1];

        if (PoisonDurrationInt == 0)
        {
            Debug.Log("Make sure PoisonDam is before PoionWeak");
        }
        else if (PoisonDurrationInt != Stats[2])
        {
            Debug.Log("Uh-oh, the durration of weak & dam are different");
        }
    }

    void NegateAttack(int[] Stats)
    {
        HasNegateAttack = true;
        NegateAttacks = Stats[1];
    }

    void NNegateAttack()
    {
        NegateAttacks -= 1;
        if (NegateAttacks == 0)
        {
            HeP = 0;
            HasNegateAttack = false;
        }
    }

    void Sspot(int[] Stats)
    {
        OpenToSpot = true;
    }

    void Ssuicide(int[] Stats)
    {
        Stats[1] += HeP;
        HeP = 0;
        if (HasToxic == true)
        {
            PoisonStats[0] = PoisonDamInt;
            PoisonStats[1] = PoisonDurrationInt;
            PoisonStats[2] = PoisonWeakInt;
            SendMessageUpwards("SendVenom", PoisonStats);
        }
        SendMessageUpwards("MinusHealth", Stats);
    }

    #endregion

    void Abilities()
    {
        #region the tower
        int[] Temp = new int[3];
        Temp[0] = -1;
        if (SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 1)
        {
            {
                Temp[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[0];
                Temp[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[0];
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[0], Temp);

                if (SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 2)
                {
                    Temp[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[1];
                    Temp[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[1];
                    SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[1], Temp);

                    if (SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 3)
                    {
                        Temp[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[2];
                        Temp[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[2];
                        SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[2], Temp);

                        if (SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 4)
                        {
                            Temp[1] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityStats[3];
                            Temp[2] = SpawnManagerScriptableObject.CardList[CardListNumber].AbilityRefresh[3];
                            SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Abilities[3], Temp);

                            if (SpawnManagerScriptableObject.CardList[CardListNumber].Abilities.Length >= 5)
                            {
                                Debug.Log("this card has too many abilities");
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }

    #region Traits (sans Traits)
    void Stealth()
    {
        HasStealth = true;
    }
    
    void Cowardly()
    {
        HasCowardly = true;
    }

    void Toxic()
    {
        HasToxic = true;
    }

    void Flying(int[] PlayerAndID)
    {
        HasFlying = true;
    }

    void AdddReaching(int Player)
    {
        AgHasReaching = true;
    }

    void AdddRange(int Player)
    {
        AgHasRange = true;
    }

    void AdddOverkill(int Player)
    {
        AgHasOverkill = true;
    }

    void AdddUnblocking (int Player)
    {
        AgHasUnblocking = true;
    }

    #endregion

    void Traits()
    {
        #region the tower
        if (SpawnManagerScriptableObject.CardList[CardListNumber].Traits.Length >= 1)
        {
            SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Traits[0], PlayerAndID);

            if (SpawnManagerScriptableObject.CardList[CardListNumber].Traits.Length >= 2)
            {
                SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Traits[1], PlayerAndID);

                if (SpawnManagerScriptableObject.CardList[CardListNumber].Traits.Length >= 3)
                {
                    SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Traits[2], PlayerAndID);

                    if (SpawnManagerScriptableObject.CardList[CardListNumber].Traits.Length >= 4)
                    {
                        SendMessage(SpawnManagerScriptableObject.CardList[CardListNumber].Traits[3], PlayerAndID);

                        if (SpawnManagerScriptableObject.CardList[CardListNumber].Traits.Length >= 5)
                        {
                            Debug.Log("this card has too many triats");
                        }
                    }
                }
            }
        }
        #endregion
    }

    #region Inhabit sans Inhabit, Inhabit___, and Inhabitingg
    void InhabCounter(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("InhabCounter is not triggerble");
        }
        else if (Inhabiting == true)
        {
            Debug.Log("It works");
            Counter = Stats[1];
        }
        else
        {
            Debug.Log("You need to have another card inhabit this card");
        }
    }
    #endregion

    void TimePassing()
    {
        if (Poisoned == true && HarmPoisonStats[1] != 0)
        {
            Debug.Log("Dur P = " + HarmPoisonStats[1]);
            if (Poisoned == true && HarmPoisonStats[1] != 0)
            {
                Debug.Log("Dur I = " + HarmPoisonStats[1]);
                HeP -= HarmPoisonStats[0];
                if (HeP < 0)
                {
                    HeP = 0;
                }
                HarmPoisonStats[1] -= 1;
                if (HeP == 0)
                {
                    Poisoned = false;
                    HarmPoisonStats[1] = 0;
                }
                Debug.Log("Dur J = " + HarmPoisonStats[1]);
            }
            // Word of note: I dont know why, but somehow all of this Debug.Log nonsence fixed a bug. so you cant remove it or poison breaks
            TempInt1 += 1;
            Debug.Log("This scprit has run " + TempInt1 + " times");
        }
    }

    void Block(int Originid)
    {
        BlockBool = true;
        OriginID = Originid;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerAndID[1] = id;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 3 == 1)
        {
            PlayerAndStats[0] = Player;
            PlayerAndID[0] = Player;
        }

        if (HeP > SpawnManagerScriptableObject.CardList[CardListNumber].HealthPoints)
        {
            HeP = SpawnManagerScriptableObject.CardList[CardListNumber].HealthPoints;
        }

        if (Prompt == true)
        {
            if (Input.GetKeyDown("y"))
            {
                Debug.Log("Click the card you want to block with");
                SendMessageUpwards("SendBlock", id);
            }
            if (Input.GetKeyDown("n"))
            {
                Wait = false;
                Prompt = false;
                Debug.Log("click on the card again to procide");
            }
        }

        if (HeP == 0)
        {
            CardListNumber = 0;
            SendMessageUpwards("Player1NotFull", id);
            HeP = -1;
        }
    }
}