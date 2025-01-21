using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
   public List<Item> inventory = new List<Item>();
    
}


[System.Serializable]
public class Item{ 
    public string name;
    public string description;
    public int value;
    public string rarity;
    public Stats stats;
}

[System.Serializable]
public class Stats{
    public int damage;
    public int PVsuplementaire;
}