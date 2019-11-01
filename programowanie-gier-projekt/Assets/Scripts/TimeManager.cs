using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TimeManager : MonoBehaviour
    {
        public static float StartingTime = 60;
        public string ShowSceneNameAfterTimeEnd = Constants.GameOverScene;
        public static float MoreTimeInSeconds = 10f;

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
                if (ShowSceneNameAfterTimeEnd != Constants.GameOverScene)
                {
                    StartingTime = 30f;
                }
            }
        }

        public static void ResetTimer()
        {
            StartingTime = 60;
        }

        public static void AddMoreTime()
        {
            StartingTime += MoreTimeInSeconds;
        }

        public static void ResetTimerForMagicWorld()
        {
            if (StartingTime > 15)
            {
                StartingTime = 10f;
            }
        }
    }
}
