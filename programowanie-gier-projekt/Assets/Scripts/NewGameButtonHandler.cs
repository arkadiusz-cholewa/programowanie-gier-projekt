﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
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
            SquirellHandleClick.isSpawned = true;
            SceneManager.LoadScene("NewGameScene");
        }
    }

}