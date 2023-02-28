using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;
using System;

public class MoveController : MonoBehaviour
{
    public static int v=0;
    public GameObject player;
    public Rigidbody2D rb;
    public float speed=1.0f;
    public Camera[] cam;
    public GameObject[] lig;
    //public Animator ani;
    // Start is called before the first frame update
    private void Awake()
    {
        lig[1].SetActive(true);
        lig[0].SetActive(false);
    }
    void Start()
    {
        
        for (int i=0;i<cam.Length;i++)
        {
            cam[i].transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
        //ani =GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (v==1)
        {
            for (int i = 0; i < lig.Length; i++)
            {
                lig[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < lig.Length; i++)
            {
                lig[i].SetActive(true);
            }
        }
        move();
    }
   
    public void move()
    {
        float Ymove=0;
        float Xmove = 0;
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            lig[1].SetActive(false);
            lig[0].SetActive(true);
            Xmove = -1;
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            Xmove = 1;
            lig[1].SetActive(true);
            lig[0].SetActive(false);
            
        }
        if (Input.GetKey(KeyCode.W))
        {
            lig[1].SetActive(true);
            lig[0].SetActive(false);
            transform.rotation = Quaternion.Euler(0, 0, 90);
            Ymove = 1;
            
        }
        else if (Input.GetKey(KeyCode.S)){
            transform.rotation = Quaternion.Euler(0, 0, -90);
            lig[0].SetActive(false);
            lig[1].SetActive(true);
            Ymove = -1;
            
        }
        //ani.SetTrigger("run");
        rb.velocity=new Vector3(Xmove*speed, Ymove*speed,0);
        for (int i = 0; i < cam.Length; i++)
        {
            cam[i].transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            
        }
    }
 
}

