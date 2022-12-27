using GloomHaven.Card;
using GloomHaven.UI.FlippedCards;
using UnityEngine;

namespace GloomHaven.UI.CardDisplay
{
    public class CardDisplayController : MonoBehaviour
    {
        [SerializeField] private FlippedCardController flippedCardController;
        [SerializeField] private SingleCardDisplay singleCardDisplay;
        [SerializeField] private DoubleCardDisplay doubleCardDisplay;
        [SerializeField] private CardDisplayBackground displayBackground;

        private CardAsset revealedCardOne;
        private CardAsset revealedCardTwo;

        private void Start()
        {
            displayBackground.OnClicked += HandleBackgoundClicked;
            HideAll();
        }

        public void DisplaySingle(CardAsset card)
        {
            revealedCardOne = card;
            singleCardDisplay.Show(revealedCardOne);
            displayBackground.Show();
        }

        public void DisplayDouble(CardAsset cardOne, CardAsset cardTwo)
        {
            revealedCardOne = cardOne;
            revealedCardTwo = cardTwo;
            doubleCardDisplay.Show(revealedCardOne, revealedCardTwo);
            displayBackground.Show();
        }

        private void HandleBackgoundClicked()
        {
            HideAll();

            if (revealedCardOne)
            {
                flippedCardController.AddCard(revealedCardOne);
                revealedCardOne = null;
            }

            if (revealedCardTwo)
            {
                flippedCardController.AddCard(revealedCardTwo);
                revealedCardTwo = null;
            }
        }

        private void HideAll()
        {
            singleCardDisplay.Hide();
            doubleCardDisplay.Hide();
            displayBackground.Hide();
        }
    }
}