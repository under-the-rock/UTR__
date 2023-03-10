using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    public Item item;
    public SpriteRenderer image;
    public static int set;
    public static int sets;
    public void SetItem(Item _item)
    {
        item.itemName = _item.itemName;
        item.itemImage =_item.itemImage;
        item.itemType= _item.itemType;
        item.efts= _item.efts;
        image.sprite= _item.itemImage;
    }
    public Item GetItem()
    {
        return item;
    }
    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
