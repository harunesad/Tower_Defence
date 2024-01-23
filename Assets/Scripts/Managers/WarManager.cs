using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarManager : MonoBehaviour
{
    [SerializeField] float mana, manaMax;
    [SerializeField] List<GameObject> towers;
    LevelData levelData;
    void Start()
    {
        Transform parent = transform.parent;
        for (int i = 0; i < parent.childCount; i++)
        {
            if (parent.GetChild(i).gameObject.activeSelf)
            {
                levelData = parent.GetChild(i).GetComponent<LevelData>();
                break;
            }
        }
        manaMax = levelData.mana;
        mana = manaMax;
        InvokeRepeating("ManaIncrease", levelData.startTime, levelData.repeatTime);
    }
    void Update()
    {
        
    }
    public void TowerCreate(float towerMana, int towerId, Transform grid)
    {
        if (mana >= towerMana)
        {
            mana -= towerMana;
            Instantiate(towers[towerId], grid.position, Quaternion.identity);
        }
    }
    void ManaIncrease()
    {
        if (mana + levelData.manaInc <= manaMax)
        {
            mana += levelData.manaInc;
        }
    }
}
