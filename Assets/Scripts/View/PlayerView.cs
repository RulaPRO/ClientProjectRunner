using System;
using Common.Player;
using UnityEngine;
using View.UI.Screens;

namespace View
{
    public class PlayerView : MonoBehaviour
    {
        public Action OnCollisionEnterObstacle;

        [SerializeField] private PlayerJumpBehaviour jumpBehaviour;

        private const string ObstacleTag = "Obstacle";
        private const string FinishTag = "Finish";

        public PlayerJumpBehaviour JumpBehaviour => jumpBehaviour;


        private void OnEnable()
        {
            SceneContext.I.PlayerService.OnPlayerRespawn += RespawnPlayer;
        }

        private void OnDisable()
        {
            SceneContext.I.PlayerService.OnPlayerRespawn -= RespawnPlayer;
        }

        private void OnCollisionEnter(Collision collision)
        {
            switch (collision.gameObject.tag)
            {
                case ObstacleTag:
                    OnCollisionEnterObstacle?.Invoke();
                    break;
                case FinishTag:
                    SceneContext.I.UIService.ShowScreen<CompleteLevelScreen>();
                    break;
            }
        }

        private void RespawnPlayer()
        {
            transform.position = SceneContext.I.TileService.CurrentTile.RespawnPoint.position;
        }
    }
}