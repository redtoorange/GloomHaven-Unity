using UnityEngine;

namespace GloomHaven.UI.FlippedCards
{
    public class FlippedCardHolder : MonoBehaviour
    {
        private RectTransform rectTransform;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void UpdateSize(float size)
        {
            rectTransform.SetSizeWithCurrentAnchors(
                RectTransform.Axis.Vertical,
                size * 300
            );
        }
    }
}