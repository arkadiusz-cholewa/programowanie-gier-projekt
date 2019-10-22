﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Game : MonoBehaviour
    {
        private const float MinY = Constants.MinY;
   
        public GameObject targetPrefab;
        public float respawnTime = 1f;

        // Start is called before the first frame update
        private void Start()
        {
           // StartCoroutine(targetWave());
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