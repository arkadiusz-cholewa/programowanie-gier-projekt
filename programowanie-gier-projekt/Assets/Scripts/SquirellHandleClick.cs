using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (!isSpawned && Input.GetMouseButtonDown(Constants.LeftMouseButton) && !WeaponManager.isReloading)
            {
                isSpawned = false;
                SceneManager.LoadScene(Constants.MagicWorldScene);
                TimeManager.ResetTimerForMagicWorld();
                Destroy(gameObject);
            }
        }
    }
}