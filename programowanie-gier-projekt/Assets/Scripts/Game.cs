using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{

    public class Game : MonoBehaviour
    {
        private const float MinY = Constants.MinY;

        public GameObject targetPrefab;
        public float respawnTime = 1f;

        AudioSource audioSource;
        public AudioClip[] shots;
        SpriteRenderer sr;
        GameObject back1;
        GameObject back2;
        GameObject back3;
        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            back1 = GameObject.Find("back1");
            back2 = GameObject.Find("back2");
            back3 = GameObject.Find("back3");

            if (back1 != null && back2 != null && back3 != null)
            {
                back1.SetActive(true);
                back2.SetActive(false);
                back3.SetActive(false);
            }

           
        }

        private void Update()
        {
            if (back1 != null && back2 != null && back3 != null)
            {
                if (RoundManager.round - 1 % 3 == 0)
                {
                    back1.SetActive(true);
                    back2.SetActive(false);
                    back3.SetActive(false);
                }

                if (RoundManager.round - 1 % 3 == 1)
                {
                    back1.SetActive(false);
                    back2.SetActive(true);
                    back3.SetActive(false);
                }

                if (RoundManager.round - 1 % 3 == 2)
                {
                    back1.SetActive(false);
                    back2.SetActive(false);
                    back3.SetActive(true);
                }
            }
        

            if (Input.GetMouseButtonDown(Constants.LeftMouseButton))
            {
                WeaponManager.Shot();
                if (!WeaponManager.isReloading)
                {
                    audioSource.PlayOneShot(shots[(int)WeaponManager.weaponCategory], 0.7F);
                }
            }

         
            if (Input.GetKeyDown("escape"))
            {
                SceneManager.LoadScene("MainMenuScene");
            }
        }

        private void spawnEnemy()
        {
            var newGameObject = Instantiate(targetPrefab) as GameObject;
            var xPosition = Helpers.GetRandomXPosition();
            newGameObject.transform.position = new Vector2(xPosition, MinY);
        }

        IEnumerator targetWave()
        {
            while (true)
            {
                yield return new WaitForSeconds(respawnTime);
                spawnEnemy();
            }
        }
    }
}
