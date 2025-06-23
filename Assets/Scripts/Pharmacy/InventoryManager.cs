using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int inventorySize = 6;
    public InventoryBase[] inventory;
    public InventoryBase[] displayedInventory;
    [SerializeField] private SpriteRenderer[] shelfSlots; //Will need to be set everytimeenter pharacy


    // Start is called before the first frame update
    void Awake()
    {
        inventory = new InventoryBase[inventorySize];
    }

    public void AddToInventory(InventoryBase _itemToAdd)
    {

        for (int i = 0; i < inventorySize; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = _itemToAdd;
                _itemToAdd.numberOwned += 1;
                return;
            } 
        }

        Debug.Log("Inventory full");
    }
}
