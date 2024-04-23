using Services.UIService.Implementation.UIUnits;
using UnityEngine;

namespace View.UI.Screens
{
    public class GameplayHUDScreen : UIScreen
    {
        [SerializeField] private ImageFadeAnimation imageFadeAnimation;

        private void OnEnable()
        {
            SceneContext.I.PlayerService.Health.OnHealthDecrease += OnPlayerHealsDecrease;
            SceneContext.I.PlayerService.OnPlayerDeath += OnPlayerDeath;
        }

        private void OnDisable()
        {
            SceneContext.I.PlayerService.Health.OnHealthDecrease -= OnPlayerHealsDecrease;
            SceneContext.I.PlayerService.OnPlayerDeath -= OnPlayerDeath;
        }
        
        private void OnPlayerHealsDecrease(int value)
        {
            if (SceneContext.I.PlayerService.Health.Value > 0)
            {
                imageFadeAnimation.Play();
            }
        }

        private void OnPlayerDeath()
        {
            SceneContext.I.UIService.ShowScreen<FailLevelScreen>();
        }
    }
}