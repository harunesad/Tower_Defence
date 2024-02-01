using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarManager : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] float mana, manaMax;
    public List<GameObject> towers;

    LevelData levelData;
    int waveId = 0;
    void Start()
    {
        Transform parent = transform.parent;
        levelData = levelManager.levels[levelManager.storyLevel].levels[levelManager.chapter].GetComponent<LevelData>();
        manaMax = levelData.levels[levelManager.levelDifficulty].mana;
        mana = manaMax;
        InvokeRepeating("ManaIncrease", levelData.levels[levelManager.levelDifficulty].startTime, levelData.levels[levelManager.levelDifficulty].repeatTime);
    }
    void Update()
    {
        
    }
    public void TowerCreate(float towerMana, int towerId, Transform grid)
    {
        if (mana >= towers[towerId].GetComponent<Tower>().stats[0].buyMana)
        {
            mana -= towers[towerId].GetComponent<Tower>().stats[0].buyMana;
            var tower = Instantiate(towers[towerId], grid.position, Quaternion.identity, grid);
        }
    }
    void ManaIncrease()
    {
        if (mana + levelData.levels[levelManager.levelDifficulty].waveData[waveId].manaInc <= manaMax)
        {
            mana += levelData.levels[levelManager.levelDifficulty].waveData[waveId].manaInc;
        }
    }
}
