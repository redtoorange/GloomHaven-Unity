using UnityEngine;

namespace GloomHaven.UI.Options
{
    public class OptionsButtonAnimator : MonoBehaviour
    {
        [SerializeField] private float transitionTime = 0.25f;
        [SerializeField] private float backgroundTransparency = 0.5f;
        [SerializeField] private float offsetAmount = -100;
        [SerializeField] private RectTransform optionsButtonPanel;
        [SerializeField] private GameObject optionsBackground;

        private Vector2 panelStartPosition;

        private void Start()
        {
            panelStartPosition = optionsButtonPanel.anchoredPosition;
        }

        public void ShowPanel()
        {
            var position = new Vector2(offsetAmount, 0);
            LeanTween.move(optionsButtonPanel, position, transitionTime)
                .setEase(LeanTweenType.easeInOutCubic);
            optionsBackground.SetActive(true);
            LeanTween.alpha(optionsBackground.GetComponent<RectTransform>(), backgroundTransparency, transitionTime);
        }

        public void HidePanel()
        {
            LeanTween.move(optionsButtonPanel, panelStartPosition, transitionTime)
                .setEase(LeanTweenType.easeInOutCubic);
            LeanTween.alpha(optionsBackground.GetComponent<RectTransform>(), 0.0f, transitionTime)
                .setOnComplete(HideBackground);
        }

        private void HideBackground()
        {
            optionsBackground.SetActive(false);
        }
    }
}