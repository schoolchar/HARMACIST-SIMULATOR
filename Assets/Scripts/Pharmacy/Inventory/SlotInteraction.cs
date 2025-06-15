using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allow player to interact with items on shelf
/// </summary>
public class SlotInteraction : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;

    [SerializeField] private Transform[] slotPosPre;
    [SerializeField] private Vector3[] slotPos;

    private void Start()
    {
        int _len = slotPosPre.Length;
        slotPos = new Vector3[_len];
        for(int i = 0; i < _len; i++)
        {
            slotPos[i] = transform.position;
        }
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

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
    }

    void ResetToSlot()
    {
        //When player drags item and drops it, make it automatically go to nearest slot

        Vector3 _closest = new Vector3(0,0,0);
        float _closestDistance = 0;
        int _len = slotPos.Length;

        for(int i = 0; i < _len; i++)
        {
           
            float _distance = Mathf.Sqrt(((transform.position.x - slotPos[i].x) * (transform.position.x - slotPos[i].x)) + ((transform.position.y - slotPos[i].y) * (transform.position.y - slotPos[i].y)));
            Debug.Log("Closest - " + _closestDistance + " this " + _distance);
            if(_closestDistance == 0 || _closestDistance > _distance)
            {
                _closest = slotPos[i];
                _closestDistance = _distance;
            }
        }

        transform.position = _closest;

    }



} //END SlotInteraction.cs
