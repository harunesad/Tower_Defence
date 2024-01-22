using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeDrag : CardDrag, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = canvas.transform;
    }
    public void OnDrag(PointerEventData eventData)
    {
        myRect.anchoredPosition += eventData.delta / canvas.localScale.x;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.parent = parent;
    }
}
