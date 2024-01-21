using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    protected float towerAttack;
    protected float health;
    protected float attackSpeed;
    protected float attackRange;
    protected LayerMask unitLayer, towerLayer;
    protected Transform target;
    protected GameObject towerCanvas;
    protected Button sell, move, cancel;
    protected bool moving;
    Collider[] colliders;
    List<Collider> targets;
    RaycastHit hit;

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
