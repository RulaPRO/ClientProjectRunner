using System;
using System.Collections.Generic;
using Factories;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Services.Tiles
{
    public class TileService : IDisposable
    {
        private LevelGenerator levelGenerator = new LevelGenerator();
        private TileFactory tileFactory = new TileFactory();
        private BonusFactory bonusFactory = new BonusFactory();
        
        public TileView StartTileView { get; private set; }
        public TileView FinishTileView { get; private set; }
        public List<TileView> PathTilesViews { get; private set; } = new List<TileView>();
        public TileView CurrentTile { get; private set; }
        public Dictionary<TileType, int> FinishedTiles { get; private set; } = new Dictionary<TileType, int>();

        public void CreateTiles()
        {
            var tiles = levelGenerator.GenerateLevel(SceneContext.I.Config.TilesAmountOnLevel);

            StartTileView = tileFactory.Create("Start");
            StartTileView.transform.position = Vector3.zero;

            PathTilesViews.Clear();
            var posZ = StartTileView.transform.position.z;
            var tileSize = SceneContext.I.Config.TileSize;
            foreach (var tile in tiles)
            {
                var tileView = tileFactory.Create(tile.Type);
                posZ += tileSize;
                tileView.transform.position = new Vector3(0.0f, 0.0f, posZ);
                tileView.OnPlayerEnter = () => OnPlayerEnterTile(tileView);
                tileView.OnPlayerExit = () => OnPlayerExitTile(tile);

                if (tile.Type == TileType.Default)
                {
                    TrySpawnBonus(tileView.transform);
                }
                
                PathTilesViews.Add(tileView);
            }
            
            FinishTileView = tileFactory.Create("Finish");
            posZ += tileSize;
            FinishTileView.transform.position = new Vector3(0.0f, 0.0f, posZ);
        }

        private void TrySpawnBonus(Transform parent)
        {
            var maxExclusive = Enum.GetValues(typeof(BonusType)).Length;
            var randomType = (BonusType)Random.Range(1, maxExclusive);
            var bonusView = bonusFactory.Create(randomType);
            bonusView.transform.parent = parent;
            bonusView.transform.localPosition = Vector3.zero;
        }

        private void OnPlayerEnterTile(TileView tileView)
        {
            CurrentTile = tileView;
        }

        private void OnPlayerExitTile(Tile tile)
        {
            if (tile.Type == TileType.Gap ||
                tile.Type == TileType.BigGap ||
                tile.Type == TileType.Wall ||
                tile.Type == TileType.Saw)
            {
                if (!FinishedTiles.ContainsKey(tile.Type))
                {
                    FinishedTiles.Add(tile.Type, 0);
                }

                FinishedTiles[tile.Type] += 1;
            }
        }

        public void Dispose()
        {
            PathTilesViews.Clear();
            FinishedTiles.Clear();
        }
    }
}