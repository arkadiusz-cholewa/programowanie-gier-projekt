using UnityEngine;

namespace Assets.Scripts
{
    public class HorizontalRightMovement : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject targetPrefab;

        void Start()
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            GetComponent<Collider2D>().enabled = true;
            transform.position = new Vector2(-Constants.MaxX - Random.Range(1f, 3f), Helpers.GetRandomYPosition());
            GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(3f, 6f), 0);
        }


        void Update()
        {
            if (transform.position.x > Constants.MaxX)
            {
                transform.position = new Vector2(Constants.MaxX + Random.Range(1f, 3f), Helpers.GetRandomYPosition());
                GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(3f, 6f), 0);
            }
        }

        private void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(Constants.LeftMouseButton))
            {
                print("CLICK");


                var obj = (GameObject)Instantiate(targetPrefab, new Vector2(Constants.MaxX + Random.Range(1f, 3f), Helpers.GetRandomYPosition()), Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-Random.Range(3f, 6f), 0);

                ScoreManager.AddPoints(20);
                Destroy(gameObject);

            }
        }
    }
}
