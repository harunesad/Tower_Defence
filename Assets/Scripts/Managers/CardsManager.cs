using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsManager : MonoBehaviour
{
    [SerializeField] WarManager warManager;
    [SerializeField] List<Sprite> cards, spells;
    [SerializeField] List<Image> myCards;
    [SerializeField] Image mySpell;
    public int cardIndex, spellIndex;
    void Start()
    {
        for (int i = 0; i < myCards.Count; i++)
        {
            RandomCard(i);
        }
        RandomSpell();
    }
    void Update()
    {
        
    }
    public void RandomCard(int index)
    {
        cardIndex = Random.Range(0, warManager.towers.Count);
        myCards[index].sprite = warManager.towers[cardIndex].GetComponent<Tower>().towerImage;
        myCards[index].GetComponent<CardDrag>().cardsId = cardIndex;
    }
    public void RandomSpell()
    {
        spellIndex = Random.Range(0, spells.Count);
        mySpell.sprite = spells[spellIndex];
        mySpell.GetComponent<CardDrag>().cardsId = spellIndex;
    }
}
