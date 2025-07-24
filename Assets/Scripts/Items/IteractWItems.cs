using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IteractWItems : MonoBehaviour
{
    protected InventoryManager inventoryManager;
    public InventoryBase inventoryBase;

    private void Start()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }

    protected virtual void OnMouseDown()
    {
        inventoryManager.AddToInventory(inventoryBase);
        Destroy(this.gameObject);
    }
}
