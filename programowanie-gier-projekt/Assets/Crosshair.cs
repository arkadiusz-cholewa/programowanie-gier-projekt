using UnityEngine;

public class Crosshair : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        var position = GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        var target = GameObject.Find("Crosshair");
        target.transform.position = new Vector3(position.x, position.y, -9);
    }
}
