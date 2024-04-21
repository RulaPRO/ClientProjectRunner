using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Services.Player
{
    public class HealthController
    {
        public Action<int> OnHealthIncrease;
        public Action<int> OnHealthDecrease;

        public int Value { get; private set; }
        public bool HasInvincibility { get; private set; }

        public void Init(int healthValue)
        {
            Value = healthValue;

            OnHealthIncrease?.Invoke(Value);
        }

        public void IncreaseHealth(int value)
        {
            Value = Mathf.Clamp(Value + value, 0, SceneContext.I.Config.BaseHealth);

            OnHealthIncrease?.Invoke(Value);
        }

        public void DecreaseHealth()
        {
            if (HasInvincibility)
            {
                return;
            }

            Value--;

            OnHealthDecrease?.Invoke(Value);
        }

        public async void EnableInvincibility(int value)
        {
            HasInvincibility = true;

            await Task.Delay(value);

            HasInvincibility = false;
        }
    }
}