using UnityEngine;

namespace Factories
{
    public class TileFactory
    {
        public TileView Create(string key)
        {
            var prefab = LoadTilePrefab($"PrefabTile{key}");
            var instance = Object.Instantiate(prefab);

            return instance;
        }

        public TileView Create(TileType tileType)
        {
            return Create(tileType.ToString());
        }

        private TileView LoadTilePrefab(string id)
        {
            return Resources.Load<TileView>($"Tiles/{id}");
        }
    }
}