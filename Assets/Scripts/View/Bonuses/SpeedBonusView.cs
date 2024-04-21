using UnityEngine;

namespace View.Bonuses
{
    public class SpeedBonusView : BonusView
    {
        [SerializeField] private float bonusValue;

        protected override void ApplyBonus()
        {
            SceneContext.I.PlayerService.Speed.IncreaseMaxSpeed(bonusValue);
        }
    }
}