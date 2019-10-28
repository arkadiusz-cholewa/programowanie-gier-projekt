using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SquirellHandleClick : MonoBehaviour
    {
        // Start is called before the first frame update

        public static bool isSpawned = false;
        void Start()
        {
            if (isSpawned)
            {
                Destroy(gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnMouseOver()
        {

            if (!isSpawned && Input.GetMouseButtonDown(Constants.LeftMouseButton))
            {
                isSpawned = false;
                SceneManager.LoadScene("MagicWorldScene");
                TimeManager.Foo();
                Destroy(gameObject);
            }
        }
    }

}