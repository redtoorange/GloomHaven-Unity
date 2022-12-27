using GloomHaven.Card;
using UnityEngine;
using UnityEngine.UI;

namespace GloomHaven.UI.FlippedCards
{
    public class FlippedCard : MonoBehaviour
    {
        private CardAsset cardAsset;
        private Image cardImage;

        private void Awake()
        {
            cardImage = GetComponent<Image>();
        }

        public void Initialize(CardAsset cardAsset)
        {
            this.cardAsset = cardAsset;
            cardImage.sprite = cardAsset.cardFace;
        }
    }
}