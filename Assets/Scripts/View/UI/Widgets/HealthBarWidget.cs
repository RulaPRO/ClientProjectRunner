using UnityEngine;

namespace View.UI.Widgets
{
    public class HealthBarWidget : MonoBehaviour
    {
        [SerializeField] private GameObject[] hearts;

        private void OnEnable()
        {
            UpdateHealthValue(SceneContext.I.PlayerService.Health.Value);

            SceneContext.I.PlayerService.Health.OnHealthIncrease += UpdateHealthValue;
            SceneContext.I.PlayerService.Health.OnHealthDecrease += UpdateHealthValue;
        }

        private void OnDisable()
        {
            SceneContext.I.PlayerService.Health.OnHealthIncrease -= UpdateHealthValue;
            SceneContext.I.PlayerService.Health.OnHealthDecrease -= UpdateHealthValue;
        }

        private void UpdateHealthValue(int value)
        {
            for (var i = 0; i < hearts.Length; i++)
            {
                hearts[i].SetActive(value > i);
            }
        }
    }
}