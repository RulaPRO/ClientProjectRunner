﻿using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class LevelGenerator
{
    private int tilesAmount = 10;
    
    int tileTypeCount = Enum.GetValues(typeof(TileType)).Length;
    
    public List<Tile> GenerateLevel()
    {
        var tiles = new List<Tile>();

        for (int i = 0; i < tilesAmount; i++)
        {
            var randomType = (TileType)Random.Range(1, tileTypeCount);
            tiles.Add(new Tile { Type = randomType});
        }
        
        return tiles;
    }
}

public class Tile
{
    public TileType Type;
    public float Size = 20.0f;
}

public enum TileType
{
    None = 0,
    Default = 1,
    Gap = 2,
    BigGap = 3,
    Wall = 4,
}