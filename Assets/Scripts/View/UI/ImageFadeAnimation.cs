using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace View.UI
{
    public class ImageFadeAnimation : MonoBehaviour
    {
        [SerializeField] private Image imageComponent;
        [SerializeField] private float fadeDuration = 0.5f;

        private Color defaultColor;
        private Coroutine fadeCoroutine;

        private void OnEnable()
        {
            defaultColor = imageComponent.color;
        }

        private void OnDisable()
        {
            imageComponent.color = defaultColor;
        }

        private void OnDestroy()
        {
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
                fadeCoroutine = null;
            }
        }

        public void Play()
        {
            fadeCoroutine = StartCoroutine(AnimateFade());
        }

        private IEnumerator AnimateFade()
        {
            while (true)
            {
                yield return FadeImage(0f, 1f, fadeDuration * 0.25f);
                yield return FadeImage(1f, 0f, fadeDuration);
                yield break;
            }
        }

        private IEnumerator FadeImage(float startAlpha, float targetAlpha, float duration)
        {
            var timer = 0f;
            var startColor = imageComponent.color;
            var targetColor = new Color(startColor.r, startColor.g, startColor.b, targetAlpha);

            while (timer < duration)
            {
                timer += Time.deltaTime;
                var alpha = Mathf.Lerp(startAlpha, targetAlpha, timer / duration);
                imageComponent.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
                yield return null;
            }

            imageComponent.color = targetColor;
        }
    }
}