using UnityEngine;

namespace Assets.Scripts
{
    public class FallingPackage : MonoBehaviour
    {
        public GameObject targetPrefab;

        private float _scale = 0f;
        private float _gravityScale = 0f;
        public readonly float _offsetMin = 3f;
        public readonly float _offsetMax = 3f;
        private readonly float _minVelocity = 4f;
        private readonly float _maxVelocity = 8f;
        private float mult = RoundManager.round / 10f;
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
                GetComponent<Rigidbody2D>().velocity = new Vector2(0 + mult, 0 + mult);
                ReScale();

            }

            if (!WeaponManager.isReloading && Input.GetMouseButtonDown(Constants.LeftMouseButton))
            {
                var dist = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
                var v3Pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
                v3Pos = Camera.main.ScreenToWorldPoint(v3Pos);
                var distanceBetween = Vector3.Distance(v3Pos, transform.position);
                if (distanceBetween < 0.25f + (int)WeaponManager.weaponCategory * 0.15f)
                {
                    Hit();
                }
            }
        }

        private void OnMouseOver()
        {
            if (!WeaponManager.isReloading && Input.GetMouseButtonDown(Constants.LeftMouseButton))
            {
                Hit();
            }
        }

        private void Hit()
        {
            WeaponManager.RerollWeapon();
        }

        private void Setup()
        {
            ReScale();
            transform.position = new Vector2(Helpers.GetRandomXPosition(), Constants.MaxY + Random.Range(_offsetMin, _offsetMax));
            GetComponent<Rigidbody2D>().gravityScale = _gravityScale;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0 + mult, 0 + mult);

        }

        private void ReScale()
        {
            _scale = Random.Range(2f, 3f);
            _scale -= RoundManager.round / 30f;
            _gravityScale = Random.Range(0.1f, 0.15f);
            transform.localScale = new Vector3(_scale, _scale, 1);
        }
    }
}
