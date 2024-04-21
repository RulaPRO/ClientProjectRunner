using Services.Tiles;
using UnityEngine;
using View.Bonuses;

namespace Factories
{
    public class BonusFactory
    {
        public BonusView Create(BonusType bonusType)
        {
            var prefab = LoadBonusPrefab(bonusType);
            var instance = Object.Instantiate(prefab);

            return instance;
        }

        private BonusView LoadBonusPrefab(BonusType bonusType)
        {
            return Resources.Load<BonusView>($"Bonuses/PrefabBonus{bonusType}View");
        }
    }
}