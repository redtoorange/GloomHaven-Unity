using System;
using System.Collections.Generic;
using GloomHaven.Card;
using GloomHaven.Orchestration;
using GloomHaven.UI.CardDisplay;
using GloomHaven.UI.CurseBless;
using GloomHaven.UI.Draw;
using GloomHaven.UI.FlippedCards;
using GloomHaven.UI.Options;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GloomHaven.Deck
{
    public class DeckController : MonoBehaviour
    {
        [SerializeField] private List<CardAsset> cardAssets;
        [SerializeField] private CurseBlessCounters curseBlessCounters;
        [SerializeField] private FlippedCardController flippedCardController;
        [SerializeField] private CardDisplayController cardDisplayController;
        private Dictionary<CardType, CardAsset> cardTypeToAssetMap;

        private GloomHavenDeck controlledDeck;
        private DrawButtonController drawButtonController;

        private void Start()
        {
            BuildAssetMap();

            controlledDeck = SessionManager.S.GetCurrentDeck();
            if (controlledDeck == null)
            {
                SessionManager.S.CreateNewSession();
                controlledDeck = SessionManager.S.GetCurrentDeck();
            }

            AddSavedCardsToFlippedPile();
            UpdateBlessCurseCounts();

            drawButtonController = FindObjectOfType<DrawButtonController>();
            UpdateDrawButtons();
        }

        private void OnEnable()
        {
            DrawButtonController.OnDrawSingle += HandleDrawSingle;
            DrawButtonController.OnDrawDouble += HandleDrawDouble;

            OptionsButtonController.OnShufflePressed += HandleShuffleDeck;
            OptionsButtonController.OnAddBlessPressed += HandleAddBlessing;
            OptionsButtonController.OnAddCursePressed += HandleAddCurse;
            OptionsButtonController.OnUndoPressed += HandleUndoDraw;
        }

        private void OnDisable()
        {
            DrawButtonController.OnDrawSingle -= HandleDrawSingle;
            DrawButtonController.OnDrawDouble -= HandleDrawDouble;

            OptionsButtonController.OnShufflePressed -= HandleShuffleDeck;
            OptionsButtonController.OnAddBlessPressed -= HandleAddBlessing;
            OptionsButtonController.OnAddCursePressed -= HandleAddCurse;
            OptionsButtonController.OnUndoPressed -= HandleUndoDraw;
        }

        public void BackToMainMenu()
        {
            SessionManager.S.SaveCurrentSession();
            SceneManager.LoadScene("Scenes/MainMenu");
        }

        public void SaveCurrentSession()
        {
            SessionManager.S.SaveCurrentSession();
        }

        private void UpdateBlessCurseCounts()
        {
            curseBlessCounters.SetBlessCount(controlledDeck.totalBlessCount + controlledDeck.stagedBlessCount);
            curseBlessCounters.SetCurseCount(controlledDeck.totalCurseCount + controlledDeck.stagedCurseCount);
        }

        /**
         * Read the deck's flipped pile and push them into the visual flipped pile
         */
        private void AddSavedCardsToFlippedPile()
        {
            flippedCardController.ClearPile();
            foreach (var card in controlledDeck.flippedPile)
                flippedCardController.AddCard(cardTypeToAssetMap[card.type]);
        }

        private void BuildAssetMap()
        {
            cardTypeToAssetMap = new Dictionary<CardType, CardAsset>();
            for (var i = 0; i < cardAssets.Count; i++) cardTypeToAssetMap[cardAssets[i].cardType] = cardAssets[i];
        }

        private void HandleDrawSingle()
        {
            var nextCard = controlledDeck.DrawCard();
            cardDisplayController.DisplaySingle(cardTypeToAssetMap[nextCard]);

            if (nextCard == CardType.BLESS || nextCard == CardType.CURSE) UpdateBlessCurseCounts();

            UpdateDrawButtons();
        }

        private void HandleDrawDouble()
        {
            var firstDraw = controlledDeck.DrawCard();
            var secondDraw = controlledDeck.DrawCard();

            cardDisplayController.DisplayDouble(
                cardTypeToAssetMap[firstDraw],
                cardTypeToAssetMap[secondDraw]
            );

            if (firstDraw == CardType.BLESS || firstDraw == CardType.CURSE ||
                secondDraw == CardType.BLESS || secondDraw == CardType.CURSE)
                UpdateBlessCurseCounts();

            UpdateDrawButtons();
        }

        private void HandleShuffleDeck()
        {
            controlledDeck.Shuffle();
            flippedCardController.ClearPile();
            UpdateDrawButtons();
        }

        private void HandleAddBlessing()
        {
            controlledDeck.AddCard(CardType.BLESS);
            flippedCardController.AddCard(cardTypeToAssetMap[CardType.BLESS]);
            UpdateBlessCurseCounts();
        }

        private void HandleAddCurse()
        {
            controlledDeck.AddCard(CardType.CURSE);
            flippedCardController.AddCard(cardTypeToAssetMap[CardType.CURSE]);
            UpdateBlessCurseCounts();
        }

        private void HandleUndoDraw()
        {
            throw new NotImplementedException();
        }

        private void UpdateDrawButtons()
        {
            var remaining = controlledDeck.RemainingCards();
            if (remaining < 1)
                drawButtonController.SetSingleEnabled(false);
            else
                drawButtonController.SetSingleEnabled(true);

            if (remaining < 2)
                drawButtonController.SetDoubleEnabled(false);
            else
                drawButtonController.SetDoubleEnabled(true);
        }
    }
}