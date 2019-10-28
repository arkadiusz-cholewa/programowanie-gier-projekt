using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TimeManager : MonoBehaviour
    {
        public static float StartingTime;
        public static float MoreTimeInSeconds = 30;
        public string ShowSceneNameAfterTimeEnd = "GameOverScene";

        private Text _theText;

        void Start()
        {
            _theText = GetComponent<Text>();
            RestartTimer();
        }

        void Update()
        {
            StartingTime -= Time.deltaTime;

            _theText.text = "" + Mathf.Round(StartingTime);

            if (StartingTime < 0)
            {
                SceneManager.LoadScene(ShowSceneNameAfterTimeEnd);
            }
        }

        public static void RestartTimer()
        {
            StartingTime += MoreTimeInSeconds;
        }
    }
}
