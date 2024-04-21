using Services.UIService.Implementation.UIUnits;
using UnityEngine;

namespace Factories
{
    public class UIFactory
    {
        public TScreen CreateScreen<TScreen>(Transform parent) where TScreen : UIScreen
        {
            var screenPrefab = Resources.Load<TScreen>($"UI/Screens/{typeof(TScreen).Name}");
            var instance = Object.Instantiate(screenPrefab, parent);

            return instance;
        }
    }
}