using TMPro;
using UnityEngine;

namespace GloomHaven.UI.CurseBless
{
    public class CurseBlessCounters : MonoBehaviour
    {
        [SerializeField] private TMP_Text curseCountText;
        [SerializeField] private TMP_Text blessCountText;

        public void SetCurseCount(int newCount)
        {
            curseCountText.text = newCount.ToString();
        }

        public void SetBlessCount(int newCount)
        {
            blessCountText.text = newCount.ToString();
        }
    }
}