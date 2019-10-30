using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SquirellHandleClick : MonoBehaviour
    {
        public static bool isSpawned = false;
        void Start()
        {
            if (isSpawned)
            {
                Destroy(gameObject);
            }
        }
        
        private void OnMouseOver()
        {

            if (!isSpawned && Input.GetMouseButtonDown(Constants.LeftMouseButton))
            {
                isSpawned = false;
                SceneManager.LoadScene("MagicWorldScene");
                TimeManager.ResetTimerForMagicWorld();
                Destroy(gameObject);
            }
        }
    }
}