using UnityEngine;

namespace Assets.Scripts
{
    public class CrosshairHandler : MonoBehaviour
    {
        public Sprite reload;
        public Sprite crosshair;

        void Start()
        {
            var sr = gameObject.GetComponent<SpriteRenderer>();
            sr.sprite = crosshair;
        }

        void Update()
        {
            if (WeaponManager.isReloading)
            {
                var sr = gameObject.GetComponent<SpriteRenderer>();
                sr.sprite = reload;
            }
            else
            {
                var sr = gameObject.GetComponent<SpriteRenderer>();
                sr.sprite = crosshair;
            }
        }
    }
}
