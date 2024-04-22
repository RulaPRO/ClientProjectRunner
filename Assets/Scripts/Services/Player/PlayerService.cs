using System;
using Factories;
using View;

namespace Services.Player
{
    public class PlayerService : IDisposable
    {
        public Action OnPlayerDeath;
        public Action OnPlayerRespawn;

        private PlayerFactory playerFactory;

        public PlayerView PlayerView { get; private set; }
        public HealthController Health { get; }
        public SpeedController Speed { get; }

        public PlayerService()
        {
            playerFactory = new PlayerFactory();

            Health = new HealthController();
            Speed = new SpeedController();

            Health.OnHealthDecrease += UpdateDeathStatus;
        }

        public void CreatePlayer()
        {
            PlayerView = playerFactory.Create();
            PlayerView.OnCollisionEnterObstacle += Health.DecreaseHealth;

            Health.Init(SceneContext.I.Config.BaseHealth);
            Speed.Init();
        }

        public void RespawnPlayer()
        {
            Health.Init(1);

            OnPlayerRespawn?.Invoke();
        }

        public void TryJumpPlayer()
        {
            PlayerView.JumpBehaviour.TryJump();
        }

        private void UpdateDeathStatus(int obj)
        {
            if (Health.Value == 0)
            {
                OnPlayerDeath?.Invoke();
            }
        }

        public void Dispose()
        {
            PlayerView.OnCollisionEnterObstacle -= Health.DecreaseHealth;
            Health.OnHealthDecrease -= UpdateDeathStatus;
        }
    }
}