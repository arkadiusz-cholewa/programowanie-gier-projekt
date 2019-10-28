using UnityEngine;

namespace Assets.Scripts
{
    public class DuckMove : MonoBehaviour
    {
        private const int MaxX = Constants.MaxX;
        private const int MinX = -14;

        void Update()
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, 0);

            if (transform.position.x < MinX)
            {
                var xPosition = 15;
                transform.position = new Vector2(xPosition, 0);
                GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, 0);
            }
        }
    }
}
