using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    #region Abilities

    void InsertAbilityNameHere(int[] Stats)
    {
        Debug.Log("InsertAbilityNameHere" + " is attempting to exicute");
    }

    void GainBio(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("GainBio" + " is attempting to exicute");
            SendMessageUpwards("ChangeBio", Stats);
            SendMessageUpwards("PassTurn", Stats);
        }
    }

    void GainGeo(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("GainGeo" + " is attempting to exicute");
            SendMessageUpwards("ChangeGeo", Stats);
            SendMessageUpwards("PassTurn", Stats);
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
        if (Stats[0] != -1)
        {
            int zero = 0;
            Debug.Log("SpawnWeb" + " is attempting to exicute");
            SendMessageUpwards("Spawn___", zero);
        }
    }

    void PoisonDam(int[] Stats)
    {
        Debug.Log("PoisonDam" + " is attempting to exicute");
    }

    void PoisonWeak(int[] Stats)
    {
        Debug.Log("PoisonWeak" + " is attempting to exicute");
    }

    void InhabitBasicSpider(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("InhabitBasicSpider" + " is attempting to exicute");
        }
    }

    void InhabCounter(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("InhabitBasicSpider" + " is attempting to exicute");
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
            Debug.Log("Counter" + " is attempting to exicute");
        }
    }

    void DealDam(int[] Stats)
    {
        if (Stats[0] != -1)
        {
            Debug.Log("DealDam" + " is attempting to exicute");
            SendMessageUpwards("MinusHealth", Stats);
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
        Debug.Log("Armor" + " is attempting to exicute");
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
    }
    void Stealth(int[] PlayerAndID)
    { 
        // dpp thing
    }
    void Rush(int[] PlayerAndID)
    {
        //thing do
    }
    void Toxic(int[] PlayerAndID)
    {
        //thing do
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
}
