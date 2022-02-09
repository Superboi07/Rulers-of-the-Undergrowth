using UnityEngine;
using UnityEditor.Animations;
using System.Collections;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CardList", order = 1)]
public class SpawnManagerScriptableObject : ScriptableObject
{
    [Serializable]
    public class Card
    {
        // I have ID so I both remember placement and name
        public string ID;
        public string Name;
        public int BioCost;
        public int GeoCost;
        public string Class;
        public string Species;
        public int Duration;
        public int HealthPoints;
        public string[] Abilities;
        public int[] AbilityStats;
        public int[] AbilityRefresh;
        public string[] Traits;
        public Sprite Image;
        public AnimatorController RulerImage;
    }
    public Card[] CardList;
}