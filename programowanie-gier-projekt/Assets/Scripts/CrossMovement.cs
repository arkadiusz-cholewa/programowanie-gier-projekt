﻿using UnityEngine;

namespace Assets.Scripts
{
    public class CrossMovement : MonoBehaviour
    {
        public GameObject targetPrefab;
        public Sprite duck_kill;
        Animator animator;
        public int value = 30;
        public bool isClickable = true;
        private bool _isDead = false;
        private float _scale = 0f;
        private readonly float _minVelocity = 3f;
        private readonly float _maxVelocity = 6f;
        private float sign = 1;

        private float mult = RoundManager.round / 10f;
        public AudioClip hitSound;

        AudioSource audioSource;
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            GetComponent<Collider2D>().enabled = true;
            sign = (Random.value > 0.5f) ? -1 : 1;
            Setup();
        }


        void Update()
        {
            if (!_isDead && transform.position.y > Constants.MaxY)
            {
                Setup();
            }

            if (_isDead && transform.position.y < Constants.MinY)
            {
                var obj = (GameObject)Instantiate(targetPrefab, new Vector2(Helpers.GetRandomXPosition(), Constants.MinY - 3), Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().velocity = new Vector2(sign * Random.Range(_minVelocity + mult, _maxVelocity + mult), Random.Range(_minVelocity + mult, _maxVelocity + mult));
                ReScale();
                Destroy(gameObject);
            }


            if (!WeaponManager.isReloading && !_isDead && Input.GetMouseButtonDown(Constants.LeftMouseButton))
            {
                var dist = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
                var v3Pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
                v3Pos = Camera.main.ScreenToWorldPoint(v3Pos);
                var distanceBetween = Vector3.Distance(v3Pos, transform.position);
                if (distanceBetween < 0.25f + (int)WeaponManager.weaponCategory * 0.5f)
                {
                    Hit();
                }
            }
        }

        private void OnMouseOver()
        {
            if (!WeaponManager.isReloading && !_isDead && Input.GetMouseButtonDown(Constants.LeftMouseButton))
            {
                Hit();
            }
        }

        private void Hit()
        {
            if (isClickable)
            {
                audioSource.PlayOneShot(hitSound, 0.9F);
                animator = GetComponent<Animator>();
                animator.enabled = false;
                var sr = gameObject.GetComponent<SpriteRenderer>();
                sr.sprite = duck_kill;
                _isDead = true;
                GetComponent<Rigidbody2D>().gravityScale = 2f;
                ScoreManager.AddPoints(Mathf.FloorToInt(value - _scale * 10));
                DucksLeftManager.DecreaseDucksLeftCounter();
            }
        }

        private void Setup()
        {
            transform.position = new Vector2(Helpers.GetRandomXPosition(), Constants.MinY - 3);
            GetComponent<Rigidbody2D>().velocity = new Vector2(sign * Random.Range(_minVelocity + mult, _maxVelocity + mult), Random.Range(_minVelocity + mult, _maxVelocity + mult));
            animator = GetComponent<Animator>();
            animator.enabled = true;
            _isDead = false;
            ReScale();
            sign = (Random.value > 0.5f) ? -1 : 1;
        }

        private void ReScale()
        {
            _scale = Random.Range(1f, 3f);
            _scale -= RoundManager.round / 30f;
            transform.localScale = new Vector3((-sign) * _scale, _scale, 1);
        }
    }
}
