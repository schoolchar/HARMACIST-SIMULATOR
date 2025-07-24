using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Hold information pertaining to dead bodies, instantiated with necessary info when in tandem w/body inventory item
public class DeadBodies : MonoBehaviour
{
    public string personName;
    public Sprite bodySpriteIntact;
    public Sprite bodySpriteMutilated;
    public bool isMutilated;
    public int indexInInventory;
    public bool crowbarSelected;

    private void OnMouseDown()
    {
        if(crowbarSelected)
        {
            isMutilated = true;
            GetComponent<SpriteRenderer>().sprite = bodySpriteMutilated;
        }
    }
}
