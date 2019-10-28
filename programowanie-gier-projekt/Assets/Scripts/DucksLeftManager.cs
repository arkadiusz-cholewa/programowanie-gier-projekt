using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.Scripts
{
    public class DucksLeftManager : MonoBehaviour
    {
        private Text _theText;
        public static int ducksLeft = 20;

        void Start()
        {
            _theText = GetComponent<Text>();
        }

        void Update()
        {
            _theText.text = "" + ducksLeft;

            if (ducksLeft == 0)
            {
                RoundManager.NextRound();
               // TimeManager.RestartTimer();
                ducksLeft = 20;
            }
        }

        public static void DecreaseDucksLeftCounter()
        {
            ducksLeft--;
        }
    }
}
