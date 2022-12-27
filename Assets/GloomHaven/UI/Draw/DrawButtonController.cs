using System;
using UnityEngine;
using UnityEngine.UI;

namespace GloomHaven.UI.Draw
{
    public class DrawButtonController : MonoBehaviour
    {
        public static Action OnDrawSingle;
        public static Action OnDrawDouble;

        [SerializeField] private Button singleButton;
        [SerializeField] private Button doubleButton;

        public void DrawPressed()
        {
            OnDrawSingle?.Invoke();
        }

        public void DoubleDrawPressed()
        {
            OnDrawDouble?.Invoke();
        }

        public void SetSingleEnabled(bool pEnabled)
        {
            singleButton.interactable = pEnabled;
        }

        public void SetDoubleEnabled(bool pEnabled)
        {
            doubleButton.interactable = pEnabled;
        }
    }
}