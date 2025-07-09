using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosetManager : MonoBehaviour
{
    InventoryManager inventoryManager;
    [SerializeField] private GameObject shipmentPrefab;
    [SerializeField] private Transform[] spawnPts;

    // Start is called before the first frame update
    void Start()
    {
        InitValues();
    }


    void InitValues()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();

        int _invLen = inventoryManager.inventorySize;

        for(int i = 0; i < _invLen; i++)
        {
            if(inventoryManager.inventory[i] != null && inventoryManager.inventory[i].shipment)
            {
                GameObject _thisObj = Instantiate(shipmentPrefab, spawnPts[Random.Range(0, 6)].position, Quaternion.identity, this.gameObject.transform); //Might get rid of the randomization stuff
                _thisObj.GetComponent<SpriteRenderer>().sprite = inventoryManager.inventory[i].shelfSprite;
            }
        }
    }
}
