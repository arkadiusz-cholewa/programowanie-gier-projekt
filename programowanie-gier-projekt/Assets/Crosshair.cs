using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public float Offset = 150;
    public float Speed = 15;
    public Vector2 MinMaxXPosition;
    private float _screenWidth;
    private Vector3 _cameraMove;

    // Start is called before the first frame update
    private void Start()
    {
        _screenWidth = Screen.width;
        MinMaxXPosition = new Vector2(-7, 7);
        _cameraMove.x = transform.position.x;
        _cameraMove.y = transform.position.y;
        _cameraMove.z = transform.position.z;
    }

    // Update is called once per frame
    private void Update()
    {
        if ((Input.mousePosition.x > _screenWidth - Offset) && transform.position.x < MinMaxXPosition.y)
        {
            _cameraMove.x += MoveSpeed();
            _cameraMove.z = -10;
        }

        if ((Input.mousePosition.x < Offset) && transform.position.x > MinMaxXPosition.x)
        {
            _cameraMove.x -= MoveSpeed();
            _cameraMove.z = -10;

        }
        transform.position = _cameraMove;
        var position = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        var target = GameObject.Find("Crosshair");
        target.transform.position = new Vector3(position.x, position.y, -9);

    }

    private float MoveSpeed()
    {
        return Speed * Time.deltaTime;
    }
}
