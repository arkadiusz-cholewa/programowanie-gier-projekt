using UnityEngine;

namespace Assets.Scripts
{
    public class BlockMovement : MonoBehaviour
    {
        private const int MaxX = 7;
        private const int MinX = -7;
        private const float MinY = -6;

        private const float YVelocityMax = 15;
        private const float YVelocityMin = 9;
        private const float XVelocityMax = 3;
        private const float XVelocityMin = -3;

        private const int LeftMouseButton = 0;

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
                var xPosition = _getRandomXPosition();
                transform.position = new Vector2(xPosition, MinY);
                GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
                GetComponent<Rigidbody2D>().AddTorque(15);
            }
        }

        private void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(LeftMouseButton))
            {
                print("CLICK");
                ScoreManager.AddPoints(20);
                Destroy(gameObject);
            }
        }

        private static float _getRandomXPosition() => Random.Range(MinX, MaxX);
    }
}
