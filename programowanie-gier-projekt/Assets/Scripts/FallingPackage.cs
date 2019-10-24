using UnityEngine;

namespace Assets.Scripts
{
    public class FallingPackage : MonoBehaviour
    {
        public GameObject targetPrefab;

        private float _scale = 0f;
        private float _gravityScale = 0f;
        private readonly float _offsetMin = 3f;
        private readonly float _offsetMax = 3f;
        private readonly float _minVelocity = 4f;
        private readonly float _maxVelocity = 8f;

        void Start()
        {
            GetComponent<Collider2D>().enabled = true;
            _gravityScale = Random.Range(0.1f, 0.15f);
            Setup();
        }

        void Update()
        {
            if (transform.position.y < Constants.MinY)
            {
                Setup();
            }

            if (transform.position.y < Constants.MinY)
            {
                var obj = (GameObject)Instantiate(targetPrefab, new Vector2(Helpers.GetRandomXPosition(), Constants.MaxY + Random.Range(_offsetMin, _offsetMax)), Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().gravityScale = _gravityScale;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                ReScale();

            }
        }

        private void OnMouseOver()
        {
            if (!WeaponManager.isReloading && Input.GetMouseButtonDown(Constants.LeftMouseButton))
            {
              WeaponManager.RerollWeapon();
            }
        }

        private void Setup()
        {
            ReScale();
            transform.position = new Vector2(Helpers.GetRandomXPosition(), Constants.MaxY + Random.Range(_offsetMin, _offsetMax));
            GetComponent<Rigidbody2D>().gravityScale = _gravityScale;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        }

        private void ReScale()
        {
            _scale = Random.Range(2f, 3f);
            _gravityScale = Random.Range(0.1f, 0.15f);
            transform.localScale = new Vector3(_scale, _scale, 1);
        }
    }
}
