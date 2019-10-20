using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class TimeManager : MonoBehaviour
    {
        public float StartingTime;

        private Text _theText;
        // Start is called before the first frame update
        void Start()
        {
            _theText = GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            StartingTime -= Time.deltaTime;

            _theText.text = "" + Mathf.Round(StartingTime);
        }
    }
}
