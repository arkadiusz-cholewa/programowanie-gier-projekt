using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TimeManager : MonoBehaviour
    {
        public float StartingTime;
 
        private Text _theText;

        void Start()
        {
            _theText = GetComponent<Text>();
        }

        void Update()
        {
            StartingTime -= Time.deltaTime;

            _theText.text = "" + Mathf.Round(StartingTime);

            if (StartingTime < 0)
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }
}
