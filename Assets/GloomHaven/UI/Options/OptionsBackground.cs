using UnityEngine;
using UnityEngine.EventSystems;

namespace GloomHaven.UI.Options
{
    public class OptionsBackground : MonoBehaviour, IPointerDownHandler
    {
        private OptionsButtonAnimator _optionsButtonAnimator;

        private void Start()
        {
            _optionsButtonAnimator = GetComponentInParent<OptionsButtonAnimator>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _optionsButtonAnimator.HidePanel();
        }
    }
}