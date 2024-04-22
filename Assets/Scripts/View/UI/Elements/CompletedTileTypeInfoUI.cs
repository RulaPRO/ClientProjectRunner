using TMPro;
using UnityEngine;

namespace View.UI.Elements
{
    public class CompletedTileTypeInfoUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI label;

        public void SetLabel(string text)
        {
            label.text = text;
        }
    }
}