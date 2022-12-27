using System;
using System.Collections.Generic;
using GloomHaven.Card;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GloomHaven.Deck
{
    [Serializable]
    public enum CardType
    {
        ZERO,
        PLUS_ONE,
        PLUS_TWO,
        MINUS_ONE,
        MINUS_TWO,
        MISS,
        CRITICAL,
        CURSE,
        BLESS
    }

    /**
     * Data layer representation of that gloomhaven attack modifier deck
     */
    [Serializable]
    public class GloomHavenDeck
    {
        public int totalZeroCount = 6;
        public int totalPlusOneCount = 5;
        public int totalPlusTwoCount = 1;
        public int totalMinusOneCount = 5;
        public int totalMinusTwoCount = 1;
        public int totalMissCount = 1;
        public int totalCriticalCount = 1;
        public int totalBlessCount;
        public int totalCurseCount;

        // Staged means they have been added to the deck and should show in the discard, but haven't been removed
        public int stagedBlessCount;
        public int stagedCurseCount;

        public List<GloomHavenCard> drawPile;
        public List<GloomHavenCard> flippedPile;

        public int RemainingCards()
        {
            return drawPile.Count;
        }

        public CardType DrawCard()
        {
            var index = Random.Range(0, drawPile.Count);

            var card = drawPile[index];
            drawPile.RemoveAt(index);

            card.order = flippedPile.Count;
            flippedPile.Add(card);

            switch (card.type)
            {
                case CardType.CURSE:
                    totalCurseCount -= 1;
                    break;
                case CardType.BLESS:
                    totalBlessCount -= 1;
                    break;
            }

            return card.type;
        }

        public void Shuffle()
        {
            drawPile = new List<GloomHavenCard>();
            flippedPile = new List<GloomHavenCard>();

            // Zero
            for (var i = 0; i < totalZeroCount; i++) drawPile.Add(new GloomHavenCard(CardType.ZERO));

            // Plus One
            for (var i = 0; i < totalPlusOneCount; i++) drawPile.Add(new GloomHavenCard(CardType.PLUS_ONE));

            // Plus Two
            for (var i = 0; i < totalPlusTwoCount; i++) drawPile.Add(new GloomHavenCard(CardType.PLUS_TWO));

            // Minus One
            for (var i = 0; i < totalMinusOneCount; i++) drawPile.Add(new GloomHavenCard(CardType.MINUS_ONE));

            // Minus Two
            for (var i = 0; i < totalMinusTwoCount; i++) drawPile.Add(new GloomHavenCard(CardType.MINUS_TWO));

            // Critical
            for (var i = 0; i < totalCriticalCount; i++) drawPile.Add(new GloomHavenCard(CardType.CRITICAL));

            // Miss
            for (var i = 0; i < totalMissCount; i++) drawPile.Add(new GloomHavenCard(CardType.MISS));

            // Bless
            totalBlessCount += stagedBlessCount;
            stagedBlessCount = 0;
            for (var i = 0; i < totalBlessCount; i++) drawPile.Add(new GloomHavenCard(CardType.BLESS));

            // Curse
            totalCurseCount += stagedCurseCount;
            stagedCurseCount = 0;
            for (var i = 0; i < totalCurseCount; i++) drawPile.Add(new GloomHavenCard(CardType.CURSE));
        }

        public void AddCard(CardType cardToAdd)
        {
            if (cardToAdd == CardType.BLESS)
            {
                stagedBlessCount += 1;
                flippedPile.Add(new GloomHavenCard(CardType.BLESS));
            }
            else if (cardToAdd == CardType.CURSE)
            {
                stagedCurseCount += 1;
                flippedPile.Add(new GloomHavenCard(CardType.CURSE));
            }
        }

        public string SaveToString()
        {
            return JsonUtility.ToJson(this, true);
        }

        public static GloomHavenDeck LoadFromString(string deck)
        {
            var loadedDeck = JsonUtility.FromJson<GloomHavenDeck>(deck);
            return loadedDeck;
        }
    }
}