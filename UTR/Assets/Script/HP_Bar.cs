using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class HP_Bar : MonoBehaviour
{
    public float k = 1;
    public float b = 0;
    public float p = 100;
    public float MaxHP = 50;
    public float Hp = 50;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {   
           
            if (p!=0)
            {
                Hp--;
                
                k -= 0.01f;
                b -= 0.009f;
                transform.localPosition = new Vector3(b,0, 0);
                transform.localScale = new Vector3(k, 1, 1);
                
                
            }
          
        }
        p = (Hp/MaxHP)*100;
    }
}
