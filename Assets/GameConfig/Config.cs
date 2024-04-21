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

        [Space]
        public int BaseHealth;
    }
}