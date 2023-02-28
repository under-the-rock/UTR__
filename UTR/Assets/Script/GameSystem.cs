using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    public bool _mode = false;
    public bool _Q=false;
    public static bool mode=false;
    public static bool Q=false;
    public GameObject[] stones;
    public GameObject stone;
    private void Update()
    {
        stones = GameObject.FindGameObjectsWithTag("object");
        
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            mode = !mode;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Q= !Q;
        }
        _Q = Q;
        Q = _Q;
        _mode= mode;
        mode= _mode;
        if (!Q&&stones!=null)
        {
            if (!mode&&Input.GetMouseButtonUp(0))
            {
                Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                     Input.mousePosition.y, -Camera.main.transform.position.z));
                for (int i = 0; i < stones.Length; i++)
                {
                    if ((int)Math.Round(point.x) == (int)Math.Round(stones[i].transform.position.x)&&(int)Math.Round(point.y) ==(int)Math.Round(stones[i].transform.position.y)) 
                    {
                        Destroy(stones[i]);
                        Instantiate(stone, stones[i].transform.position, Quaternion.identity);
                    }
                }
            }
        }

    }

}
