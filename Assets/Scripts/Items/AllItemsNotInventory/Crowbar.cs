using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : IteractWItems
{
    [SerializeField] private InventoryBase baseBody;
    private DeadBodies deadBody;
    protected override void OnMouseDown()
    {
        //Check if bodies are pocessed by player
        //possibly not necessary I'm working w what I have here
        List<int> _numBodiesOwned = inventoryManager.CheckForSpecificItem(baseBody);

        //Display the bodies possessed onscreen? Click and thats whats picked?

        for(int i = 0; i < inventoryManager.inventorySize; i++)
        {
            if(inventoryManager.bodiesPocesssed[i] != null)
            {
                
                GameObject _body = Instantiate(inventoryManager.bodiesPocesssed[i]);
                DeadBodies _script = _body.GetComponent<DeadBodies>();
                if (!_script.isMutilated)
                {
                    _body.GetComponent<SpriteRenderer>().sprite = _script.bodySpriteIntact;
                    _script.crowbarSelected = true;
                }  
                else
                    Destroy(_body);
            }
        }
        //Beatdown event
    }
}
