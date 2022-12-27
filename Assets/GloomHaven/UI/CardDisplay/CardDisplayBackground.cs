using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GloomHaven.UI.CardDisplay
{
    public class CardDisplayBackground : MonoBehaviour, IPointerDownHandler
    {
        public Action OnClicked;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnClicked?.Invoke();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}