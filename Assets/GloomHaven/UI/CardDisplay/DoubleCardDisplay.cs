using GloomHaven.Card;
using UnityEngine;
using UnityEngine.UI;

namespace GloomHaven.UI.CardDisplay
{
    public class DoubleCardDisplay : MonoBehaviour
    {
        [SerializeField] private Image leftCard;
        [SerializeField] private Image rightCard;

        public void Show(CardAsset cardOne, CardAsset cardTwo)
        {
            leftCard.sprite = cardOne.cardFace;
            rightCard.sprite = cardTwo.cardFace;
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}