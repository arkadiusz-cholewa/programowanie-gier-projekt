using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TimeManager : MonoBehaviour
    {
        public static float StartingTime = 45;
        public string ShowSceneNameAfterTimeEnd = "GameOverScene";
        public static float MoreTimeInSeconds = 15f;


        private Text _theText;

        void Start()
        {
            _theText = GetComponent<Text>();
        }

        void Update()
        {
            StartingTime -= Time.deltaTime;

            _theText.text = "" + Mathf.Round(StartingTime);

            if (StartingTime < 1)
            {
                SceneManager.LoadScene(ShowSceneNameAfterTimeEnd);
                if (ShowSceneNameAfterTimeEnd != "GameOverScene")
                {
                    StartingTime = 45f;
                }
            }
        }

        public static void RestartTimer()
        {
            StartingTime += MoreTimeInSeconds;
        }

        public static void ResetTimerForMagicWorld()
        {
            if (StartingTime > 15)
            {
                StartingTime = 15f;
            }

        }
    }
}
