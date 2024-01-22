using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowersDrag : CardDrag, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] int myCardsId;
    void Update()
    {
        
    }
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
        cardsManager.RandomCard(myCardsId);
    }
}
