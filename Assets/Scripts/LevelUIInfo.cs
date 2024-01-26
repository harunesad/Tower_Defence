using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIInfo : MonoBehaviour
{
    [SerializeField]
    LevelManager levelManager;
    public int chapter, storyLevel, star;
    public List<bool> completed;
    void Start()
    {
        if (completed[levelManager.difficulty.value])
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    void Update()
    {
        
    }
}
