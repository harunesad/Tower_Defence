using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] CardsManager cardsManager;
    [SerializeField] RectTransform canvas;
    RectTransform myRect, oldRect;
    CanvasGroup myGroup;
    public int cardsId, myCardsId;
    Transform parent;
    void Start()
    {
        myRect = GetComponent<RectTransform>();
        oldRect = GetComponent<RectTransform>();
        //myGroup = GetComponent<CanvasGroup>();
        parent = transform.parent;
    }
    void Update()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        myRect.anchoredPosition += eventData.delta / canvas.localScale.x;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.parent = canvas.transform;
        //myGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.parent = parent;
        if (myCardsId >= 0)
        {
            cardsManager.RandomCard(myCardsId);
        }
        else if(myCardsId == -1)
        {
            cardsManager.RandomSpell();
        }
        //myGroup.blocksRaycasts = true;
    }
}
