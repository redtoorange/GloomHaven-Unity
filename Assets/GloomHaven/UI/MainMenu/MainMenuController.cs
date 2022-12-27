using GloomHaven.Orchestration;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GloomHaven.UI.MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private Button newSessionButton;
        [SerializeField] private Button continueSessionButton;

        private void Start()
        {
            if (!SessionManager.S.PreviousSessionExists()) continueSessionButton.interactable = false;
        }

        public void StartNewSession()
        {
            SessionManager.S.CreateNewSession();
            SceneManager.LoadScene("Scenes/MainScene");
        }

        public void ContinueSession()
        {
            SessionManager.S.LoadPreviousSession();
            SceneManager.LoadScene("Scenes/MainScene");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}