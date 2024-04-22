using Common;
using UnityEngine;

namespace View.Bonuses
{
    public abstract class BonusView : MonoBehaviour
    {
        private const string PlayerTag = "Player";

        [SerializeField] private TriggerZone triggerZone;

        private void OnEnable()
        {
            triggerZone.OnEnter += OnPlayerEnter;
        }

        private void OnDisable()
        {
            triggerZone.OnEnter -= OnPlayerEnter;
        }

        private void OnPlayerEnter(string objectTag)
        {
            if (objectTag.Equals(PlayerTag))
            {
                ApplyBonus();

                Destroy(gameObject);
            }
        }

        protected virtual void ApplyBonus()
        {
            
        }
    }
}