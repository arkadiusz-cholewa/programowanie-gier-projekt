using UnityEngine;
using UnityEngine.UI;
namespace Assets.Scripts
{
    public class ScoreLabel : MonoBehaviour
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

