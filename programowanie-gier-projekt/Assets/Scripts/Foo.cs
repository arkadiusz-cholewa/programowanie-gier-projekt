using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Foo : MonoBehaviour
    {
        private Text _theText;
        void Start()
        {
            _theText = GetComponent<Text>();
        }

        void Update()
        {
            _theText.text = "" + ScoreManager.Score;
        }
    }
}
