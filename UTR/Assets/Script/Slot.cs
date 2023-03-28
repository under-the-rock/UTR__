using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.PackageManager.UI;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Slot : MonoBehaviour, IPointerUpHandler
{
    public int slotnume;
    public Item item;
    public Image itemIcon;
    private void Awake()
    {

        itemIcon = gameObject.GetComponentInChildren<Image>();
        UpdateSlotUI();
        Color color = new Vector4(255, 255, 255, 0);
        itemIcon.color = color;
    }
    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.itemImage;
        if (itemIcon.sprite==null)
        {
            Color color = new Vector4(255, 255, 255, 0);
            itemIcon.color = color;
        }
        else
        {
            Color color = new Vector4(255, 255, 255, 255);
            itemIcon.color = color;
        }
        itemIcon.gameObject.SetActive(true);
    }
    public void RemoveSlot()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bool isUse = item.Use();
        if (isUse)
        {
            Inventory.instance.RemoveItem(slotnume);
        }
    }
}
