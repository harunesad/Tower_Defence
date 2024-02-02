using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarManager : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] float mana, manaMax;
    [SerializeField] LayerMask towerLayer;
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
        UIOpen();
    }
    void UIOpen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100, towerLayer))
            {
                hit.transform.GetComponent<Tower>().towerCanvas.SetActive(!hit.transform.GetComponent<Tower>().towerCanvas.activeSelf);
            }
        }
    }
    public void TowerCreate(float towerMana, int towerId, Transform grid)
    {
        if (mana >= towers[towerId].GetComponent<Tower>().upgrade[towers[towerId].GetComponent<Tower>().upgradeId].levels[0].buyMana)
        {
            mana -= towers[towerId].GetComponent<Tower>().upgrade[towers[towerId].GetComponent<Tower>().upgradeId].levels[0].buyMana;
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
