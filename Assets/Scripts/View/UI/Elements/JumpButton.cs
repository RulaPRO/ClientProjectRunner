using UnityEngine;
using UnityEngine.EventSystems;

namespace View.UI.Elements
{
    public class JumpButton : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            SceneContext.I.PlayerService.TryJumpPlayer();
        }
    }
}