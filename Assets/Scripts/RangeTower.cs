using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeTower : Tower
{
    [SerializeField] Button upgrade;
    private void Awake()
    {
        upgrade.onClick.AddListener(UpgradeTower);
    }
    void Update()
    {
        
    }
    protected virtual void UpgradeTower() 
    {

    }
}
