using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class FallingEggMovement : MonoBehaviour
    {
        public GameObject targetPrefab;
        public Sprite duck_kill;
        public Sprite egg;
      

        private bool _isDead = false;
        private float _scale = 0f;
        private float _gravityScale = 0f;
        private readonly float _offsetMin = 1f;
        private readonly float _offsetMax = 3f;
        private readonly float _minVelocity = 4f;
        private readonly float _maxVelocity = 8f;

        void Start()
        {
            GetComponent<Collider2D>().enabled = true;
            _gravityScale = Random.Range(0.1f, 0.3f);

            Setup();
        }


        void Update()
        {
            if (!_isDead && transform.position.y < Constants.MinY)
            {
                Setup();
            }

            if (_isDead && transform.position.y < Constants.MinY)
            {
                var obj = (GameObject)Instantiate(targetPrefab, new Vector2(Helpers.GetRandomXPosition(), Constants.MaxY + Random.Range(_offsetMin, _offsetMax)), Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().gravityScale = _gravityScale;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                ReScale();
                Destroy(gameObject);
            }
        }

        private void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(Constants.LeftMouseButton))
            {
              
                var sr = gameObject.GetComponent<SpriteRenderer>();
                sr.sprite = duck_kill;
                _isDead = true;
             
                ScoreManager.AddPoints(Mathf.FloorToInt(-30));
            }
        }

        private void Setup()
        {
            transform.position = new Vector2(Helpers.GetRandomXPosition(), Constants.MaxY + Random.Range(_offsetMin, _offsetMax));
            GetComponent<Rigidbody2D>().gravityScale = _gravityScale;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            var sr = gameObject.GetComponent<SpriteRenderer>();
            sr.sprite = egg;

            _isDead = false;
            ReScale();
        }

        private void ReScale()
        {
            _scale = Random.Range(4f, 7f);
            _gravityScale = Random.Range(0.1f, 0.5f);
            transform.localScale = new Vector3(-_scale, _scale, 1);
        }
    }
}