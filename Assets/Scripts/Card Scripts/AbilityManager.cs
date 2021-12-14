using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    // Ability varibales
    bool CoolDown = true;
    bool CoolDownJr;
    int CoolDownint = MainMessageCheckpoint.Hour + 1;
    int PoisonLessDam = 0;

    // trait varibales

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
        //thing do
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
            SendMessageUpwards("ChangeBio", Stats);
            SendMessageUpwards("PassTurn", Stats);
        }
        else if (Stats[0] != -1 && CoolDown == true)
        {
            Debug.Log("sorry bretheren, but you have made the fatal error of forgeting cool down timage");
        }

        if (CoolDown == false)
        {
            CoolDownint = Stats[2] + MainMessageCheckpoint.Hour;
            CoolDown = true;
        }
    }

    void GainGeo(int[] Stats)
    {
        if (Stats[0] != -1 && CoolDown == true)
        {
            Debug.Log("GainGeo" + " is attempting to exicute");
            SendMessageUpwards("ChangeGeo", Stats);
            SendMessageUpwards("PassTurn", Stats);
        }
        else if (Stats[0] != -1 && CoolDown == true)
        {
            Debug.Log("sorry bretheren, but you have made the fatal error of forgeting cool down timage");
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
            Debug.Log("NegateAttack" + " is attempting to exicute");
        }
    }

    void SpawnWeb(int[] Stats)
    {
        if (Stats[0] != -1 && CoolDown == true)
        {
            int zero = 0;
            Debug.Log("SpawnWeb" + " is attempting to exicute");
            SendMessageUpwards("Spawn___", zero);
        }
        else if (Stats[0] != -1 && CoolDown == true)
        {
            Debug.Log("sorry bretheren, but you have made the fatal error of forgeting cool down timage");
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
        }
        else
        {
            Debug.Log("PoisonWeak" + " is attempting to exicute");
        }
    }

    void Poisonn(int[] Stats)
    {
        PoisonLessDam = Stats[2];
        if (Stats[0] == 0)
        {
            PoisonLessDam = 0;
        }
    }

    void InhabitBasicSpider(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("InhabitBasicSpider" + " is attempting to exicute");
            SendMessageUpwards("Inhabit___", 2);
        }
    }

    void InhabCounter(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("InhabCounter is not triggerble");
        }
        else
        {
            Debug.Log("InhabCounter" + " is attempting to exicute");
        }
    }

    void AbsorbDam(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("AbsorbDam is not triggerble");
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
            Stats[1] -= PoisonLessDam;
            if (Stats[1] <= 0)
            {
                Debug.Log("Poison renders this card inert");
            }
            else
            {
                Debug.Log("DealDam" + " is attempting to exicute");
                SendMessageUpwards("MinusHealth", Stats);
            }
        }
        else if (Stats[0] != -1 && CoolDown == true)
        {
            Debug.Log("sorry bretheren, but you have made the fatal error of forgeting cool down timage");
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
        }
        else
        {
            Debug.Log("Armor" + " is attempting to exicute");
        }
    }

    void Spot(int[] Stats)
    {
        Debug.Log("Spot" + " is attempting to exicute");
    }

    void Suicide(int[] Stats)
    {
        Debug.Log("Suicide" + " is attempting to exicute");
    }

    void Cannibalize(int[] Stats)
    {
        Debug.Log("Cannibalize" + " is attempting to exicute");
    }

    void MultiHit(int[] Stats)
    {
        Debug.Log("MultiHit" + " is attempting to exicute");
    }

    void TrapLay(int[] Stats)
    {
        Debug.Log("TrapLay" + " is attempting to exicute");
    }

    void Poison(int[] Stats)
    {
        Debug.Log("Poison" + " is attempting to exicute");
    }

    void Poison___(int[] Stats)
    {
        Debug.Log("Poison___" + " is attempting to exicute");
    }

    void Refresh___(int[] Stats)
    {
        Debug.Log("Refresh___" + " is attempting to exicute");
    }

    void Res______(int[] Stats)
    {
        Debug.Log("Res___,___" + " is attempting to exicute");
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
        Debug.Log("Patience" + " is attempting to exicute");
    }

    void Stun___(int[] Stats)
    {
        Debug.Log("Stun___" + " is attempting to exicute");
    }

    #endregion

    #region Traits 

    void Nocturnal(int[] PlayerAndID)
    {
        // do thing
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
        //thing do
    }

    void Range(int[] PlayerAndID)
    {
        //thing do
    }

    void Overkill(int[] PlayerAndID)
    {
        //thing do
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