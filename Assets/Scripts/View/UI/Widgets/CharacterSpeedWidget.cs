using TMPro;
using UnityEngine;

namespace View.UI.Widgets
{
    public class CharacterSpeedWidget : MonoBehaviour
    {
        private const string LabelPrefix = "MAX SPEED X-";

        [SerializeField] private TextMeshProUGUI label;

        private void OnEnable()
        {
            UpdateLabelValue(SceneContext.I.PlayerService.Speed.SpeedMax);

            SceneContext.I.PlayerService.Speed.OnMaxSpeedChange += UpdateLabelValue;
        }

        private void OnDisable()
        {
            SceneContext.I.PlayerService.Speed.OnMaxSpeedChange -= UpdateLabelValue;
        }

        private void UpdateLabelValue(float newValue)
        {
            label.text = $"{LabelPrefix}{newValue}";
        }
    }
}