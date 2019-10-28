using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ScoreManager : MonoBehaviour
    {
        public static int Score;

        private Text _theText;

        void Start()
        {
            _theText = GetComponent<Text>();
        }

        void Update()
        {
            if (Score < 0)
            {
                Score = 0;
            }

            _theText.text = "" + Score;
        }

        public static void AddPoints(int pointsToAdd)
        {
            Score += pointsToAdd + (pointsToAdd > 0 ? RoundManager.round : -RoundManager.round);
        }

        public static void Reset()
        {
            Score = 0;
        }
    }
}
