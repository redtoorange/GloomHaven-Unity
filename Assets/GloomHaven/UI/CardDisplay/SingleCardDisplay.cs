using GloomHaven.Card;
using UnityEngine;
using UnityEngine.UI;

namespace GloomHaven.UI.CardDisplay
{
    public class SingleCardDisplay : MonoBehaviour
    {
        [SerializeField] private Image image;

        public void Show(CardAsset card)
        {
            image.sprite = card.cardFace;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}