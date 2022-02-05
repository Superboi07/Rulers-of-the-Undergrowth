using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    // Cooldown varibales
    bool CoolDown = true;
    bool CoolDownJr;
    int CoolDownint = MainMessageCheckpoint.Hour + 1;

    #region Ability vars
    bool Ppppatience;
    int PatienceInt;
    #endregion

    #region Trait vars
    bool HasReaching;
    bool HasRange;
    bool HasOverkill;
    bool HasBrittle;
    #endregion

    #region Class

    void Animal(int[] PlayerAndID)
    {
        Rush(PlayerAndID);
    }

    void Plant(int[] PlayerAndID)
    {
        //thing do
    }

    void Fungi(int[] PlayerAndID)
    {
        // dpp thing
    }

    void Inst(int[] PlayerAndID)
    {
        Rush(PlayerAndID);
        Brittle(PlayerAndID);
    }

    #endregion

    #region Species

    void Spider(int[] PlayerAndID)
    {
        //thing do
    }

    void Construct(int[] PlayerAndID)
    {
        //thing do
    }

    //void Inst(int[] PlayerAndID)
    //{
    //If I even need to difenaticate class inst and species inst
    //}

    #endregion

    #region Abilities

    void InsertAbilityNameHere(int[] Stats)
    {
        Debug.Log("InsertAbilityNameHere" + " is attempting to exicute");
    }

    void GainBio(int[] Stats)
    {
        if (Stats[0] != -1 && CoolDown == false)
        {
            Debug.Log("GainBio" + " is attempting to exicute");
            SendMessageUpwards("MiscText", "GainBio" + " is attempting to exicute");
            if (Ppppatience == true)
            {
                Ppppatience = false;
                Stats[1] *= PatienceInt;
                Debug.Log("You reap what you sow, and you have planted wisely");
                SendMessageUpwards("MiscText", "Your harvest is: " + Stats[1]);
                Debug.Log("Your harvest is: " + Stats[1]);
                SendMessageUpwards("MiscText", "You reap what you sow, and you have planted wisely");
                PatienceInt = 0;
            }
            SendMessageUpwards("ChangeBio", Stats);
            SendMessageUpwards("PassTurn", Stats);
        }
        else if (Stats[0] != -1 && CoolDown == true)
        {
            Debug.Log("sorry bretheren, but you have made the fatal error of forgeting cool down timage");
            SendMessageUpwards("MiscText", "Sorry bretheren, but you have made the fatal error of forgeting cool down timage");
        }

        if (CoolDown == false)
        {
            CoolDownint = Stats[2] + MainMessageCheckpoint.Hour;
            CoolDown = true;
        }
    }

    void GainGeo(int[] Stats)
    {
        if (Stats[0] != -1 && CoolDown == false)
        {
            Debug.Log("GainGeo" + " is attempting to exicute");
            SendMessageUpwards("MiscText", "GainGeo" + " is attempting to exicute");
            if (Ppppatience == true)
            {
                Ppppatience = false;
                Stats[1] *= PatienceInt;
                Debug.Log("You reap what you sow, and you have planted wisely");
                SendMessageUpwards("MiscText", "Your harvest is: " + Stats[1]);
                Debug.Log("Your harvest is: " + Stats[1]);
                SendMessageUpwards("MiscText", "You reap what you sow, and you have planted wisely");
                PatienceInt = 0;
            }
            SendMessageUpwards("ChangeGeo", Stats);
            SendMessageUpwards("PassTurn", Stats);
        }
        else if (Stats[0] != -1 && CoolDown == true)
        {
            Debug.Log("sorry bretheren, but you have made the fatal error of forgeting cool down timage");
            SendMessageUpwards("MiscText", "Sorry bretheren, but you have made the fatal error of forgeting cool down timage");
        }

        if (CoolDown == false)
        {
            CoolDownint = Stats[2] + MainMessageCheckpoint.Hour;
            CoolDown = true;
        }
    }

    void NegateAttack(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("NegateAttack is not triggerble");
            SendMessageUpwards("MiscText", "NegateAttack is not triggerble");
        }
        else
        {
            Debug.Log("NegateAttack" + " is attempting to exicute");
        }
    }

    void SpawnWeb(int[] Stats)
    {
        if (Stats[0] != -1 && CoolDown == false)
        {
            int zero = 0;
            Debug.Log("SpawnWeb" + " is attempting to exicute");
            SendMessageUpwards("MiscText", "SpawnWeb" + " is attempting to exicute");
            SendMessageUpwards("Spawn___", zero);
        }
        else if (Stats[0] != -1 && CoolDown == true)
        {
            Debug.Log("sorry bretheren, but you have made the fatal error of forgeting cool down timage");
            SendMessageUpwards("MiscText", "Sorry bretheren, but you have made the fatal error of forgeting cool down timage");
        }

        if (CoolDown == false)
        {
            CoolDownint = Stats[2] + MainMessageCheckpoint.Hour;
            CoolDown = true;
        }
    }

    void PoisonDam(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("PoisonDam is not triggerble");
            SendMessageUpwards("MiscText", "PoisonDam is not triggerble");
        }
        else
        {
            Debug.Log("PoisonDam" + " is attempting to exicute");
        }
    }

    void PoisonWeak(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("PoisonWeak is not triggerble");
            SendMessageUpwards("MiscText", "PoisonWeak is not triggerble");
        }
        else
        {
            Debug.Log("PoisonWeak" + " is attempting to exicute");
        }
    }

    void InhabitBasicSpider(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("InhabitBasicSpider" + " is attempting to exicute");
            SendMessageUpwards("MiscText", "InhabitBasicSpider" + " is attempting to exicute");
            SendMessageUpwards("Inhabit___", 2);
        }
    }

    void InhabCounter(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("InhabCounter is not triggerble");
            SendMessageUpwards("MiscText", "InhabCounter is not triggerble");
        }
        else
        {
            Debug.Log("InhabCounter" + " is attempting to exicute");
        }
    }

    void InhabMultiHit(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("InhabMultiHit is not triggerble");
            SendMessageUpwards("MiscText", "InhabMultiHit is not triggerble");
        }
        else
        {
            Debug.Log("InhabMultiHit" + " is attempting to exicute");
        }
    }

    void AbsorbDam(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("AbsorbDam is not triggerble");
            SendMessageUpwards("MiscText", "AbsorbDam is not triggerble");
        }
        else
        {
            Debug.Log("AbsorbDam" + " is attempting to exicute");
        }
    }

    void Counter(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("Counter is not triggerble");
            SendMessageUpwards("MiscText", "Counter is not triggerble");
        }
        else
        {
            Debug.Log("Counter" + " is attempting to exicute");
        }
    }

    void DealDam(int[] Stats)
    {
        if (Stats[0] != -1 && CoolDown == false)
        {
            if (HasReaching == true)
            {
                SendMessageUpwards("AddReaching", Stats[0]);
            }
            if (HasRange == true)
            {
                SendMessageUpwards("AddRange", Stats[0]);
            }
            if (HasOverkill == true)
            {
                SendMessageUpwards("AddOverkill", Stats[0]);
            }
            if (Ppppatience == true)
            {
                Ppppatience = false;
                Stats[1] *= PatienceInt;
                Debug.Log("You reap what you sow, and you have planted wisely");
                SendMessageUpwards("MiscText", "Your harvest is: " + Stats[1]);
                Debug.Log("Your harvest is: " + Stats[1]);
                SendMessageUpwards("MiscText", "You reap what you sow, and you have planted wisely");
                PatienceInt = 0;
            }
            Debug.Log("DealDam" + " is attempting to exicute");
            SendMessageUpwards("MiscText", "DealDam" + " is attempting to exicute");
            SendMessageUpwards("MinusHealth", Stats);
        }
        else if (Stats[0] != -1 && CoolDown == true)
        {
            Debug.Log("sorry bretheren, but you have made the fatal error of forgeting cool down timage");
            SendMessageUpwards("MiscText", "Sorry bretheren, but you have made the fatal error of forgeting cool down timage");
        }

        if (CoolDown == false)
        {
            CoolDownint = Stats[2] + MainMessageCheckpoint.Hour;
            CoolDown = true;
        }
    }

    void SacPrev(int[] Stats)
    {
        Debug.Log("SacPrev" + " is attempting to exicute");
    }

    void SacFri(int[] Stats)
    {
        Debug.Log("SacFri" + " is attempting to exicute");
    }

    void Armor(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("Armor is not triggerble");
            SendMessageUpwards("MiscText", "Amror is not triggerble");
        }
        else
        {
            Debug.Log("Armor" + " is attempting to exicute");
        }
    }

    void Spot(int[] Stats)
    {
        if (Stats[0] != -1 && CoolDown == false)
        {
            Debug.Log("Spot" + " is attempting to exicute");
            SendMessageUpwards("MiscText", "Spot" + " is attempting to exicute");
            SendMessageUpwards("SendSpot", Stats);
        }
        else if (Stats[0] != -1 && CoolDown == true)
        {
            Debug.Log("sorry bretheren, but you have made the fatal error of forgeting cool down timage");
            SendMessageUpwards("MiscText", "Sorry bretheren, but you have made the fatal error of forgeting cool down timage");
        }

        if (CoolDown == false)
        {
            CoolDownint = Stats[2] + MainMessageCheckpoint.Hour;
            CoolDown = true;
        }
    }

    void Suicide(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            SendMessageUpwards("AddUnblocking", Stats[0]);
            Debug.Log("Suicide" + " is attempting to exicute");
            SendMessageUpwards("MiscText", "Suicide" + " is attempting to exicute");
            SendMessage("Ssuicide", Stats);
        }
    }

    void Cannibalize(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("Cannibalize" + " is attempting to exicute");
            SendMessageUpwards("MiscText", "Cannibalize" + " is attempting to exicute");
            SendMessageUpwards("Ccannibalize");
            if (HasBrittle == true)
            {
                SendMessage("Die");
            }
        }
    }

    void MultiHit(int[] Stats)
    {
        Debug.Log("MultiHit" + " is attempting to exicute");
    }

    void TrapLay(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("TrapLay" + " is attempting to exicute");
            SendMessageUpwards("MiscText", "TrapLay" + " is attempting to exicute");
            if (HasBrittle == true)
            {
                SendMessage("Die");
            }
            SendMessageUpwards("TtrapLay");
            SendMessageUpwards("LazyPassTurn");
        }
    }

    void Poison(int[] Stats)
    {
        if (Stats[0] != -1 && CoolDown == false)
        {
            Debug.Log("Poison" + " is attempting to exicute");
            SendMessageUpwards("MiscText", "Poison" + " is attempting to exicute");
            SendMessage("Ppoison", Stats);
        }
        else if (Stats[0] != -1 && CoolDown == true)
        {
            Debug.Log("sorry bretheren, but you have made the fatal error of forgeting cool down timage");
            SendMessageUpwards("MiscText", "Sorry bretheren, but you have made the fatal error of forgeting cool down timage");
        }

        if (CoolDown == false)
        {
            CoolDownint = Stats[2] + MainMessageCheckpoint.Hour;
            CoolDown = true;
        }
    }

    void Poison___(int[] Stats)
    {
        Debug.Log("Poison___" + " is attempting to exicute");
    }
    
    void RefreshWeb(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            int zero = 0;
            Debug.Log("RefreshWeb" + " is attempting to exicute");
            SendMessageUpwards("MiscText", "RefreshWeb" + " is attempting to exicute");
            SendMessageUpwards("RefreshCard", zero);
            SendMessageUpwards("LazyPassTurn");
            if (HasBrittle == true)
            {
                SendMessage("Die");
            }
        }
    }

    void RefreshSpider(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("RefreshSpider" + " is attempting to exicute");
            SendMessageUpwards("MiscText", "RefreshSpider" + " is attempting to exicute");
            SendMessageUpwards("RefreshSpecies", "Spider");
            SendMessageUpwards("LazyPassTurn");
        }
    }

    void Refresh()
    {
        CoolDown = false;
        CoolDownint = 0;
    }

    void ResSpiderSpiderBall(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            if (HasBrittle == true)
            {
            SendMessage("Die");
            }
            object[] temp = new object[3];
            temp[0] = Stats[2];
            temp[1] = "Spider";
            temp[2] = 24; // dubble check if this is Spider Ball’s ID
            SendMessageUpwards("ResSpeciesCard", temp);
            SendMessageUpwards("LazyPassTurn");
        }
    }


    void Trigger___(int[] Stats)
    {
        Debug.Log("Trigger___" + " is attempting to exicute");
    }

    void Burn___(int[] Stats)
    {
        Debug.Log("Burn___" + " is attempting to exicute");
    }

    void Patience(int[] Stats)
    {
        if (Stats[0] != -1 && CoolDown == false)
        {
            Debug.Log("Patience" + " is attempting to exicute");
            SendMessageUpwards("MiscText", "Patience" + " is attempting to exicute");
            SendMessageUpwards("SendPatience", Stats);
        }
        else if (Stats[0] != -1 && CoolDown == true)
        {
            Debug.Log("sorry bretheren, but you have made the fatal error of forgeting cool down timage");
            SendMessageUpwards("MiscText", "Sorry bretheren, but you have made the fatal error of forgeting cool down timage");
        }

        if (CoolDown == false)
        {
            CoolDownint = Stats[2] + MainMessageCheckpoint.Hour;
            CoolDown = true;
        }
    }

    void Pppatience(int[] Stats)
    {
        Ssstun(Stats[2]);
        PatienceInt = Stats[1];
        Ppppatience = true;
    }

    void Stun(int[] Stats)
    {
        if (Stats[0] != -1 && CoolDown == false)
        {
            Debug.Log("Stun" + " is attempting to exicute");
            SendMessageUpwards("MiscText", "Stun" + " is attempting to exicute");
            SendMessageUpwards("SendStun", Stats);
        }
        else if (Stats[0] != -1 && CoolDown == true)
        {
            Debug.Log("sorry bretheren, but you have made the fatal error of forgeting cool down timage");
            SendMessageUpwards("MiscText", "Sorry bretheren, but you have made the fatal error of forgeting cool down timage");
        }

        if (CoolDown == false)
        {
            CoolDownint = Stats[2] + MainMessageCheckpoint.Hour;
            CoolDown = true;
        }
    }

    void Ssstun(int Stats)
    {
        CoolDown = true;
        CoolDownint += Stats;
    }

    #endregion

    #region Traits 

    void Brittle(int[] PlayerAndID)
    {
        HasBrittle = true;
    }

    void Cowardly(int[] PlayerAndID)
    {
        Debug.Log("Cowardly");
        SendMessageUpwards("NotVisible", PlayerAndID);
    }

    void Stealth(int[] PlayerAndID)
    {
        Debug.Log("Stealth");
        SendMessageUpwards("NotVisible", PlayerAndID);
    }

    void Rush(int[] PlayerAndID)
    {
        Debug.Log("Rush");
        CoolDown = false;
    }

    void Toxic(int[] PlayerAndID)
    {
        Debug.Log("Toxic");
    }

    void Flying(int[] PlayerAndID)
    {
        //thing do
    }

    void Reaching(int[] PlayerAndID)
    {
        HasReaching = true;
    }

    void Range(int[] PlayerAndID)
    {
        HasRange = true;
    }

    void Overkill(int[] PlayerAndID)
    {
        HasOverkill = true;
    }

    void Taunt(int[] PlayerAndID)
    {
        //thing do
    }

    void Unphased(int[] PlayerAndID)
    {
        //thing do
        //thing do
    }

    #endregion

    void Update()
    {
        if (CoolDownint == MainMessageCheckpoint.Hour)
        {
            CoolDown = false;
        }
    }
}