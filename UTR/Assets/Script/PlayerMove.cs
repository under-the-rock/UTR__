using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    
    [SerializeField]
    private float speed;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private GameObject lig;
    private void Awake()
    { 
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        move();
    }
    public void move()
    {
        float xmove=0;
        float ymove=0;
        if (Input.GetKey(KeyCode.A))
        {
            xmove = -1;
            transform.localEulerAngles= new Vector3(0,0,0);
            lig.transform.localEulerAngles = new Vector3(0, 0, -90);
        } 
        else if (Input.GetKey(KeyCode.D))
        {
            xmove= 1;
            transform.localEulerAngles = new Vector3(0,0,180);
            lig.transform.localEulerAngles = new Vector3(0, 0,-270);
        }
        if (Input.GetKey(KeyCode.W))
        {
            ymove= 1;
            transform.localEulerAngles = new Vector3(0,0,90);
            lig.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            ymove= -1;
            transform.localEulerAngles = new Vector3(0,0,270);
            lig.transform.localEulerAngles = new Vector3(0, 0, 180);
        }
        rb.velocity= new Vector3(xmove*speed, ymove*speed,0);
        cam.transform.position = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,-10);
        lig.transform.position = gameObject.transform.position;
    }
}
