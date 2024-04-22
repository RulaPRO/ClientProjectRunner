using UnityEngine;

namespace GameConfig
{
    [CreateAssetMenu(
        menuName = "Config/" + nameof(Config),
        fileName = nameof(Config))]
    public class Config : ScriptableObject
    {
        public float BaseSpeed;
        public float Acceleration;
        public float JumpForce;
        public float DoubleJumpForce;

        [Space]
        public int BaseHealth;

        [Space]
        public int TilesAmountOnLevel;
        public float TileSize;
        
        [Space]
        public float SpeedBonusValue;
        [Range(1, 100)] public int SpeedBonusDropChance;
        public int HealthBonusValue;
        [Range(1, 100)]public int HealthBonusDropChance;
        public int InvincibilityBonusDurationMs;
        [Range(1, 100)]public int InvincibilityBonusDropChance;
    }
}