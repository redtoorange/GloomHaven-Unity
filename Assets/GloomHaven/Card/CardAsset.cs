using GloomHaven.Deck;
using UnityEngine;

namespace GloomHaven.Card
{
    [CreateAssetMenu(fileName = "Card", menuName = "GloomHaven Card", order = 0)]
    public class CardAsset : ScriptableObject
    {
        public CardType cardType;
        public Sprite cardFace;
        public Sprite cardBack;
    }
}