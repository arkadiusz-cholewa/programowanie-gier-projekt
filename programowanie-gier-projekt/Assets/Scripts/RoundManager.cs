using System.Collections;
using System.Collections.Generic;
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

        public void ResetRound()
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