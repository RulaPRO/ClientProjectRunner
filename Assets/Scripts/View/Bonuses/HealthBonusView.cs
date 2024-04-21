using UnityEngine;

namespace View.Bonuses
{
    public class HealthBonusView : BonusView
    {
        [SerializeField] private int bonusValue;

        protected override void ApplyBonus()
        {
            SceneContext.I.PlayerService.Health.IncreaseHealth(bonusValue);
        }
    }
}