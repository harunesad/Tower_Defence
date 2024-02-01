using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowersDrag : CardDrag, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] int myCardsId;
    [SerializeField] LayerMask gridLayer;
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
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100, gridLayer) && hit.transform.childCount == 0)
        {
            warManager.TowerCreate(1, cardsId, hit.transform);
        }
        transform.parent = parent;
        cardsManager.RandomCard(myCardsId);
    }
}
