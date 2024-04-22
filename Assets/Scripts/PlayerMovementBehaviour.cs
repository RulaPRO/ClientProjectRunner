using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        private float currentSpeed;
        private bool canMove;

        public float PlayerSpeedMax => SceneContext.I.PlayerService.Speed.SpeedMax;
        public float Acceleration => SceneContext.I.PlayerService.Speed.SpeedMax;

        private void Awake()
        {
            canMove = true;
        }

        private void OnEnable()
        {
            SceneContext.I.PlayerService.OnPlayerDeath += OnPlayerDeath;
            SceneContext.I.PlayerService.OnPlayerRespawn += OnPlayerRespawn;
        }

        private void OnDisable()
        {
            SceneContext.I.PlayerService.OnPlayerDeath -= OnPlayerDeath;
            SceneContext.I.PlayerService.OnPlayerRespawn -= OnPlayerRespawn;
        }

        private void Update()
        {
            if (!canMove)
            {
                return;
            }

            if (currentSpeed < PlayerSpeedMax)
            {
                var newSpeed = currentSpeed + (Acceleration * Time.deltaTime);
                currentSpeed = Mathf.Clamp(newSpeed, 0.0f, PlayerSpeedMax);
            }

            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }

        private void OnPlayerDeath()
        {
            currentSpeed = 0.0f;
            canMove = false;
        }

        private void OnPlayerRespawn()
        {
            canMove = true;
        }
    }
}