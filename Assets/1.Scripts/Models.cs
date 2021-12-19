using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockType { Boundary, Sand, Wall }
public enum OreType { Bronze, Silver, Gold, Diamond, Miniore }

public class Block
{
    public BlockType blockType;
    public OreType? oreType;
}
