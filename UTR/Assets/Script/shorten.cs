using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shorten : MonoBehaviour
{
    // Start is called before the first frame update
    public int slotnume;
    public Item item;
    public Image itemIcon;
    private void Awake()
    {
        UpdateSlotUI();
        Color color = new Vector4(255, 255, 255, 0);
        itemIcon.color = color;
    }
    public void UpdateSlotUI(Slot slot)
    {
        item = slot.item;
        itemIcon.sprite=slot.item.itemImage;
        UpdateSlotUI();
        itemIcon.gameObject.SetActive(true);
    }
    public void UpdateSlotUI()
    {
        if (itemIcon.sprite == null)
        {
            Color color = new Vector4(255, 255, 255, 0);
            itemIcon.color = color;
        }
        else
        {
            Color color = new Vector4(255, 255, 255, 255);
            itemIcon.color = color;
        }
    
    }
    public void RemoveSlot()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
