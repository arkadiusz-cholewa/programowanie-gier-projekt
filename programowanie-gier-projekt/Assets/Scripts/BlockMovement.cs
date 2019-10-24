using UnityEngine;

namespace Assets.Scripts
{
    public class BlockMovement : MonoBehaviour
    {
        private const float MinY = Constants.MinY;

        private const float YVelocityMax = 15;
        private const float YVelocityMin = 9;
        private const float XVelocityMax = 3;
        private const float XVelocityMin = -3;

       

        // Start is called before the first frame update
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            if (transform.position.y < MinY)
            {
                float yVelocity = Random.Range(YVelocityMin, YVelocityMax);
                float xVelocity = Random.Range(XVelocityMin, XVelocityMax);
                var xPosition = Helpers.GetRandomXPosition();
                transform.position = new Vector2(xPosition, MinY);
                GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
                GetComponent<Rigidbody2D>().AddTorque(15);
            }
        }

        private void OnMouseOver()
        {
            if (!WeaponManager.isReloading && Input.GetMouseButtonDown(Constants.LeftMouseButton))
            {
                print("CLICK");
                ScoreManager.AddPoints(20);
                Destroy(gameObject);
            }
        }
    }
}
