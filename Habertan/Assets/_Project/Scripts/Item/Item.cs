using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu(menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{
    public ItemType type;

    [Header("Both")]
    public Sprite image;
}



public enum ItemType
{
    Organic,
    Anorganic,
    B3
}

