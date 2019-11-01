using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameExitButtonHandler : MonoBehaviour
    {
        public Button yourButton;

        void Start()
        {
            Button btn = yourButton.GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
        }

        void TaskOnClick()
        {
            Application.Quit();
        }
    }
}