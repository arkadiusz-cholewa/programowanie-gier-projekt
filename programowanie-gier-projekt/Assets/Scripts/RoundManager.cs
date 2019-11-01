using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class RoundManager : MonoBehaviour
    {
        private Text _theText;
        public static int round = 1;

        public static void NextRound()
        {
            round++;
        }

        public static void ResetRound()
        {
            round = 1;
        }

        void Start()
        {
            _theText = GetComponent<Text>();
        }

        void Update()
        {
            _theText.text = "" + round;
        }
    }
}