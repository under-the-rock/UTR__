using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory Inven;
    public GameObject inventoryPanel;
    bool activeInventory = false;
    public Slot[] slots;
    public shorten[] Shorten;
    public Transform slotHolder;
    public GameObject header;
    public GameObject lig;
    private void Start()
    {

        Inven = Inventory.instance;
        slots=slotHolder.GetComponentsInChildren<Slot>();
        Shorten=header.GetComponentsInChildren<shorten>();
        Inven.onSlotCountchange += SlotChange;
        Inven.onChangeItem += RedrawSlotUI;
        inventoryPanel.SetActive(activeInventory);
        for(int i = 0; i < Shorten.Length; i++)
        {
            Shorten[i].slotnume = i;
        }
    }
    private void SlotChange(int val)
    {
        for (int i=0;i<slots.Length;i++)
        {
            slots[i].slotnume = i;
            if (i<Inven.SlotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                slots[i].GetComponent<Button>().interactable=false;
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
            header.SetActive(!activeInventory);
            lig.SetActive(!activeInventory);
        }
    }
    public void AddSlot()
    {
        Inven.SlotCnt++;
    }
    public void RedrawSlotUI()
    {
        for (int i = 0; i < slots.Length; i++) 
        {
            slots[i].RemoveSlot();
            if (i < 10)
            {
                Shorten[i].RemoveSlot();
            }
        }
        for (int i =0;i<Inven.items.Count;i++)
        {
            slots[i].item = Inven.items[i];
            slots[i].UpdateSlotUI();
            if (i<10)
            {
                Shorten[i].UpdateSlotUI(slots[i]);
            }
        }
    }
}
