using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Allow player to interact with items on shelf
/// </summary>
public class SlotInteraction : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;
    Vector2 ogPos;
    [SerializeField] private Transform[] slotPosPre;
    [SerializeField] private Vector2[] slotPos;

    private Vector2 newPos;
    bool dragging;
    GameObject otherSlot;
    

    private void Start()
    {
        int _len = slotPosPre.Length;
        slotPos = new Vector2[_len];
        for(int i = 0; i < _len; i++)
        {
            slotPos[i] = transform.position;
        }

        ogPos = transform.position;
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        dragging = true;
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

    }

    private void OnMouseUp()
    {
        ResetToSlot();
        dragging = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(dragging)
        {
            newPos = collision.transform.position;
            otherSlot = collision.gameObject;
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(dragging)
        {
            newPos = Vector2.zero;
            otherSlot = null;
        }
           
    }


    void ResetToSlot()
    {
        //When player drags item and drops it, make it automatically go to nearest slot
        //Does not work well

         if (otherSlot == null)
         {
            
            transform.position = ogPos;

             
         }
         else
         {
            
            transform.position = newPos;
            otherSlot.transform.position = ogPos;
            ogPos = transform.position;
         }

       
    }



} //END SlotInteraction.cs
