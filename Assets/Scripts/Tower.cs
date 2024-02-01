using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public LayerMask unitLayer, towerLayer;
    public Transform target;
    public GameObject towerCanvas;
    public Button sell, move, cancel;
    public bool moving;
    public Sprite towerImage;
    public float levelId, upgradeId;
    Collider[] colliders;
    List<Collider> targets;
    RaycastHit hit;

    public List<Stat> stats;
    [Serializable]
    public struct Stat
    {
        public float hp;
        public float range;
        public float attackSpeed;
        public float buyMana;
        public float sellMana;
    }

    private void Awake()
    {
        move.onClick.AddListener(MoveTower);
        sell.onClick.AddListener(SellTower);
        cancel.onClick.AddListener(CancelTower);
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
    void CancelTower()
    {
        towerCanvas.SetActive(false);
    }
    protected void UIOpen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            towerCanvas.SetActive(true);
        }
    }
}
//[Serializable]
//public class TowerLevels
//{
//    public struct Stat
//    {
//        public float hp;
//        public float range;
//        public float speed;
//        public float actionDelay;
//    }
//}
