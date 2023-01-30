using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Combine combine;
    public bool isCombine = false;

    private void Start()
    {
        combine = FindObjectOfType<Combine>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;

            if (isCombine)
            {
                combine.counter++;
            }
            else if (combine.counter > 0)
            {
                combine.counter--;
            }
        }
    }
}
