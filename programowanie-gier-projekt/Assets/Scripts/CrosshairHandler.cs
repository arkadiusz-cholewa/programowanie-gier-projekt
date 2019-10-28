using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairHandler : MonoBehaviour
{
    public Sprite reload;
    public Sprite crosshair;
    // Start is called before the first frame update
    void Start()
    {
        var sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = crosshair;
    }

    // Update is called once per frame
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
