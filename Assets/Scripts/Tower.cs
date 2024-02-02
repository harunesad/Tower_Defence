using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public LayerMask unitLayer, towerLayer;
    public Transform target;
    public GameObject towerCanvas, bullet;
    public Button sell, move;
    public bool moving;
    public Sprite towerImage;
    public int levelId, upgradeId;
    Collider[] colliders;
    List<Collider> targets;
    RaycastHit hit;

    public List<Upgrade> upgrade;
    //public List<Stat> stats;
    //[Serializable]
    //public struct Stat
    //{
    //    public float hp;
    //    public float range;
    //    public float attackSpeed;
    //    public float buyMana;
    //    public float sellMana;
    //}

    private void Awake()
    {
        move.onClick.AddListener(MoveTower);
        sell.onClick.AddListener(SellTower);
        targets.AddRange(colliders);
    }
    protected void TargetEnemy() 
    {
        if (targets.Count > 0)
        {
            targets.Clear();
        }
        colliders = Physics.OverlapSphere(transform.position, 1, unitLayer);
        targets.AddRange(colliders);
        Array.Sort(colliders, new DistanceCompare(transform));
        foreach (var item in colliders)
        {
            if (target == null || !targets.Contains(target.GetComponent<Collider>()))
            {
                target = item.transform;
                break;
            }
        }

    }
    void MoveTower() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100, towerLayer))
        {
            moving = true;
            transform.position = hit.transform.position + Vector3.up;
        }
    }
    void SellTower()
    {

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
}
[Serializable]
public class Upgrade
{
    public List<Level> levels;
}
[Serializable]
public class Level
{
    public float hp;
    public float range;
    public float attackSpeed;
    public float buyMana;
    public float sellMana;
}