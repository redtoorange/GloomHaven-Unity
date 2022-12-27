using System;
using UnityEngine;

namespace GloomHaven.UI.Options
{
    public class OptionsButtonController : MonoBehaviour
    {
        public static Action OnShufflePressed;
        public static Action OnAddCursePressed;
        public static Action OnAddBlessPressed;
        public static Action OnUndoPressed;

        public void ShufflePressed()
        {
            OnShufflePressed?.Invoke();
        }

        public void AddCursePressed()
        {
            OnAddCursePressed?.Invoke();
        }

        public void AddBlessingsPressed()
        {
            OnAddBlessPressed?.Invoke();
        }

        public void UndoPressed()
        {
            OnUndoPressed?.Invoke();
        }
    }
}