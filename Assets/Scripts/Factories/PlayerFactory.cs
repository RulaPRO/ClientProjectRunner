using UnityEngine;
using View;

namespace Factories
{
    public class PlayerFactory
    {
        public PlayerView Create()
        {
            var prefab = LoadPlayerPrefab("PrefabPlayer");
            var instance = Object.Instantiate(prefab);

            return instance;
        }

        private PlayerView LoadPlayerPrefab(string id)
        {
            return Resources.Load<PlayerView>($"Player/{id}");
        }
    }
}