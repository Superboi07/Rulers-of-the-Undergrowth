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
        Debug.Log("GainBio" + " is attempting to exicute");
        SendMessageUpwards("ChangeBio", Stats);
        SendMessageUpwards("PassTurn", Stats);
    }

    void GainGeo(int[] Stats)
    {
        Debug.Log("GainGeo" + " is attempting to exicute");
        SendMessageUpwards("ChangeGeo", Stats);
        SendMessageUpwards("PassTurn", Stats);
    }

    void NegateAttack(int[] Stats)
    {
        Debug.Log("NegateAttack" + " is attempting to exicute");
    }

    void Spawn___(int[] Stats)
    {
        Debug.Log("Spawn___" + " is attempting to exicute");
    }

    void PoisonDam(int[] Stats)
    {
        Debug.Log("PoisonDam" + " is attempting to exicute");
    }

    void PoisonWeak(int[] Stats)
    {
        Debug.Log("PoisonWeak" + " is attempting to exicute");
    }

    void Inhabit___(int[] Stats)
    {
        Debug.Log("Inhabit___" + " is attempting to exicute");
    }

    void Absorb(int[] Stats)
    {
        Debug.Log("Absorb" + " is attempting to exicute");
    }

    void Counter(int[] Stats)
    {
        Debug.Log("Counter" + " is attempting to exicute");
    }

    void DealDam(int[] Stats)
    {
        Debug.Log("DealDam" + " is attempting to exicute");
        SendMessageUpwards("MinusHealth", Stats);
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
}
