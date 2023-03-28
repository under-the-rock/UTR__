using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    // Start is called before the first frame update
    float anagle;
    Vector2 target, mouse;
    void Start()
    {
        target= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        anagle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x)*Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(anagle - 90, Vector3.forward);
    }
}
