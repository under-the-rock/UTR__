using System.Collections;
using System.Collections.Generic;
using Unity.Android.Types;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnSlotCountChange(int val);
    public OnSlotCountChange onSlotCountchange;

    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;
    public GameObject stone;
    public List<Item> items = new List<Item>();

    private int slotCnt;
    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountchange.Invoke(slotCnt);
        }
    }
    private void Start()
    {
        slotCnt = 7;
    }
    public bool AddItem(Item _item)
    {
        if (items.Count < slotCnt)
        {
            items.Add(_item);
            if (onChangeItem != null)
            {
                onChangeItem.Invoke();
            }
            return true;
        }
        return false;
    }
    public void RemoveItem(int _index)
    {
        items.RemoveAt(_index);
        onChangeItem.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            FieldItem fieldItem = collision.GetComponent<FieldItem>();
            if (AddItem(fieldItem.GetItem()))
            {
                fieldItem.OnDestroy();
            }
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && GameSystem.Q)
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                 Input.mousePosition.y, -Camera.main.transform.position.z));
            if (items!=null) {
                if (items[0].itemName == "stone")
                {
                    Instantiate(stone, point, Quaternion.identity);
                    items.RemoveAt(0);
                    onChangeItem.Invoke();
                }
            }
            


        }
    }
}

