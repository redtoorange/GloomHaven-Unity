using GloomHaven.Card;
using UnityEngine;

namespace GloomHaven.UI.FlippedCards
{
    public class FlippedCardController : MonoBehaviour
    {
        [SerializeField] private FlippedCard flippedCardPrefab;
        private int cardCount;
        private FlippedCardHolder cardHolder;

        private void Start()
        {
            cardHolder = GetComponentInChildren<FlippedCardHolder>();
        }

        public void AddCard(CardAsset cardAsset)
        {
            var newCard = Instantiate(flippedCardPrefab, cardHolder.transform);
            newCard.Initialize(cardAsset);
            cardHolder.UpdateSize(++cardCount);
        }

        public void ClearPile()
        {
            foreach (var child in cardHolder.GetComponentsInChildren<FlippedCard>()) Destroy(child.gameObject);
            cardHolder.UpdateSize(0);
            cardCount = 0;
        }
    }
}