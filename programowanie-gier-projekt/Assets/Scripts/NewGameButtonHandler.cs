using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class NewGameButtonHandler : MonoBehaviour
    {
        public Button yourButton;

        void Start()
        {
            Button btn = yourButton.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        void TaskOnClick()
        {
            ScoreManager.Score = 0;
            TimeManager.StartingTime = 60;
            RoundManager.round = 1;
            WeaponManager.numberOfBullets = 6;
            DucksLeftManager.ducksLeft = 20;
            SquirellHandleClick.isSpawned = true;
            SceneManager.LoadScene("NewGameScene");
        }
    }
}