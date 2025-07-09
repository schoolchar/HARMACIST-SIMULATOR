using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryBase : ScriptableObject
{
    public string itemName;
    public Sprite shelfSprite;
    public bool display; //If this object can be displayed on the pharmacy shelf
    public bool shipment; //Does this item come from shipments
    public int numberOwned;
    

}
