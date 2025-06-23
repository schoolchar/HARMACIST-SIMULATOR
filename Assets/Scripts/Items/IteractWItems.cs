using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IteractWItems : MonoBehaviour
{
    InventoryManager inventoryManager;
    public InventoryBase inventoryBase;

    private void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }

    private void OnMouseDown()
    {
        inventoryManager.AddToInventory(inventoryBase);
        Destroy(this.gameObject);
    }
}
