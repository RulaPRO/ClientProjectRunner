using UnityEngine;

namespace View.Bonuses
{
    public class InvincibilityBonusView : BonusView
    {
        [SerializeField] private int durationMs;

        protected override void ApplyBonus()
        {
            SceneContext.I.PlayerService.Health.EnableInvincibility(durationMs);
        }
    }
}