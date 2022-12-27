using GloomHaven.Deck;
using GloomHaven.Util;
using UnityEngine;

namespace GloomHaven.Orchestration
{
    public class SessionManager : MonoBehaviour
    {
        public static SessionManager S;

        private GloomHavenDeck currentDeck;

        private void Awake()
        {
            if (S == null)
            {
                S = this;
                DontDestroyOnLoad(this);
                LoadPreviousSession();
            }
            else
            {
                Debug.Log("Multiple SessionManagers detected");
                Destroy(this);
                gameObject.SetActive(false);
            }
        }

        public bool PreviousSessionExists()
        {
            FileManager.ReadFromFile("TestSave.dat", out var content);
            return content.Length > 0;
        }

        public void CreateNewSession()
        {
            currentDeck = new GloomHavenDeck();
            currentDeck.Shuffle();
        }

        public void LoadPreviousSession()
        {
            FileManager.ReadFromFile("TestSave.dat", out var content);

            if (content.Length > 0)
                currentDeck = GloomHavenDeck.LoadFromString(content);
            else
                currentDeck = null;
        }

        public void SaveCurrentSession()
        {
            FileManager.WriteToFile("TestSave.dat", currentDeck.SaveToString());
        }

        public GloomHavenDeck GetCurrentDeck()
        {
            return currentDeck;
        }
    }
}