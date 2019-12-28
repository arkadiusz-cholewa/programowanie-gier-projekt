using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
            ScoreManager.Reset();
            TimeManager.ResetTimer();
            RoundManager.ResetRound();
            WeaponManager.Ready();
            WeaponManager.numberOfBullets = 8;
            DucksLeftManager.ducksLeft = 20;
            Time.timeScale = 1;
            SquirellHandleClick.isSpawned = false;
            SceneManager.LoadScene(Constants.NewGameScene);
        }
    }
}