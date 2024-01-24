using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public List<DifficultyLevel> levels;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[Serializable]
public class DifficultyLevel
{
    public float startTime, repeatTime;
    public float mana;
    public List<WaveData> waveData;
}
[Serializable]
public class WaveData
{
    public float manaInc;
    public List<GameObject> enemyUnits;
    public List<GameObject> enemySpawnPoints;
}