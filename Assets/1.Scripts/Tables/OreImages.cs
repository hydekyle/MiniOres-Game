using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/OreImages")]
public class OreImages : ScriptableObject
{
    [Header("Block Materials")]
    public List<Material> Boundary, Sand, Wall, Bronze, Silver, Gold, Diamond, Miniore;
    [Header("Ore Materials")]
    public Material BronzeOre, SilverOre, GoldOre, DiamondOre, MinioreOre;
}
