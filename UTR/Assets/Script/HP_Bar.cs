using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class HP_Bar : MonoBehaviour
{

    public PlayerAbility ability;
    public float Hp_persent;
    public GameObject can;
    public Image image1;
    public Text text;
    public bool active=false;
    // Start is called before the first frame update
    void Start()
    {
        active= false;
        text= text.GetComponent<Text>();
        Hp_persent= ability.Hp/ability.MaxHp;
        image1.fillAmount= Hp_persent;
        text.text = ability.Hp + "/" + ability.MaxHp;
        can.SetActive(active);
        active=!active;

    }
    IEnumerator showHp()
    {

        can.SetActive(active);
        active = !active;
        yield return new WaitForSeconds(3.0f);
        can.SetActive(active);
        active= !active;
    }
    // Update is called once per frame
    void Update()
    {
        if (image1.fillAmount<=0.1)
        {
            Vector4 color = new Vector4(255,0,0,255);
            Image image =image1.GetComponent<Image>();
            text.color = color;
            image.color = color;
        }
        else if (image1.fillAmount <=0.5)
        {
            Vector4 color = new Vector4(255, 255, 0, 255);
            Image image = image1.GetComponent<Image>();
            image.color = color;
            text.color = color;
        }
        else
        {
            Vector4 color = new Vector4(0, 255, 0, 255);
            Image image = image1.GetComponent<Image>();
            image.color = color;
            text.color = color;
        }
        if (Input.GetKeyUp(KeyCode.P)&&ability.Hp!=0)
        {
            ability.Hp -= 1;
            Hp_persent =ability.Hp/ability.MaxHp;
            image1.fillAmount=Hp_persent;
            text.text = ability.Hp+"/"+ability.MaxHp;
            if (active)
            {
                StartCoroutine(showHp());
            }
            
        }
        if(Input.GetKeyUp(KeyCode.O)) {
            ability.Hp =ability.MaxHp;
            Hp_persent = ability.Hp / ability.MaxHp;
            Hp_persent *= 100;
            image1.fillAmount = Hp_persent;
            text.text = ability.Hp + "/" + ability.MaxHp;
            if (active)
            {
                StartCoroutine(showHp());
            }
        }
    }
}
