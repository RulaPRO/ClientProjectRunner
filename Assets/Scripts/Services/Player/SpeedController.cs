using System;

namespace Services.Player
{
    public class SpeedController
    {
        public Action<float> OnMaxSpeedChange;

        public float SpeedDefault { get; private set; }
        public float SpeedMax { get; private set; }
        public float Acceleration { get; private set; }

        public void Init()
        {
            SpeedDefault = SceneContext.I.Config.BaseSpeed;
            SpeedMax = SpeedDefault;
            Acceleration = SceneContext.I.Config.Acceleration;
        }

        public void IncreaseMaxSpeed(float value)
        {
            SpeedMax += value;

            OnMaxSpeedChange?.Invoke(SpeedMax);
        }
    }
}