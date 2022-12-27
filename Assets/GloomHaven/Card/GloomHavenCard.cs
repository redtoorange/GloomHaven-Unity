using System;
using GloomHaven.Deck;

namespace GloomHaven.Card
{
    [Serializable]
    public class GloomHavenCard
    {
        public CardType type;
        public int order = -1;

        public GloomHavenCard(CardType type)
        {
            this.type = type;
        }
    }
}