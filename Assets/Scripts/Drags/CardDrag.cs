using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour
{
    [SerializeField] protected CardsManager cardsManager;
    [SerializeField] protected RectTransform canvas;
    [SerializeField] protected WarManager warManager;
    protected RectTransform myRect;
    public int cardsId;
    protected Transform parent;
    void Start()
    {
        myRect = GetComponent<RectTransform>();
        parent = transform.parent;
    }
}
