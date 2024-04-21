using UnityEngine;

namespace Services.UIService.Implementation.UIUnits
{
    public abstract class UIScreen : MonoBehaviour
    {
        public bool IsShowing => gameObject.activeSelf;

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}