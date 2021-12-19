using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZObjectPools;

public class GameManager : MonoBehaviour
{
    public EZObjectPool blockPool;
    public OreImages oreImages;
    Dictionary<Vector3, Block> blocks;
    public int weight = 10, height = 10, deepness = 10;

    private void Start()
    {
        GenerateBlocks(deepness);
    }

    void GenerateBlocks(int deepness)
    {
        for (var z = 0; z < deepness; z++) PopulateLayer(z);
    }

    void PopulateLayer(int layerNumber)
    {
        for (var x = 0; x < weight; x++)
            for (var y = 0; y < height; y++) PutBlock(new Vector3(x, y, layerNumber));
    }

    void PutBlock(Vector3 spawnPosition)
    {
        if (blockPool.TryGetNextObject(spawnPosition, Quaternion.identity, out GameObject newBlockGO))
        {
            Block block = GenerateBlock(spawnPosition);
            if (block.oreType.HasValue) ShowOres(newBlockGO, block.oreType.Value);
        }
    }

    Block GenerateBlock(Vector3 blockPosition)
    {
        Block newBlock = new Block();
        newBlock.blockType = GenerateBlockType();
        newBlock.oreType = GenerateOreType();
        return newBlock;
    }

    BlockType GenerateBlockType()
    {
        var random = Random.Range(0, 10);
        return random > 6 ? BlockType.Wall : BlockType.Wall;
    }

    OreType? GenerateOreType()
    {
        var random = Random.Range(0, 100);
        return random > 90 ? (OreType?)OreType.Miniore : null;
    }

    void ShowOres(GameObject block, OreType oreType)
    {
        var ore = block.transform.Find("Ore");
        ore.gameObject.SetActive(true);
        foreach (Transform oreChild in ore) oreChild.GetComponent<MeshRenderer>().material = MaterialByOreType(oreType);
    }

    Material MaterialByOreType(OreType oreType)
    {
        return oreImages.MinioreOre;
    }

}
