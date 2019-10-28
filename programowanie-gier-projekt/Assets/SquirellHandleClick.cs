using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class SquirellHandleClick : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(Constants.LeftMouseButton))
            {
                SceneManager.LoadScene("MagicWorldScene");
                Destroy(gameObject);
            }
        }
    }

}