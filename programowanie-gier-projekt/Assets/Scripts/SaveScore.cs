using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class SaveScore : MonoBehaviour
    {
        public Button yourButton;
        public InputField iField;
        void Start()
        {
            Button btn = yourButton.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        void TaskOnClick()
        {
            HighscoreTable.AddHighscoreEntry(ScoreManager.Score, iField.text);
            SceneManager.LoadScene("ScoreboardScene");
        }
    }
}
