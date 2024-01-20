using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public float attack;
    public float health;
    public float attackSpeed;
    public Transform target;
    public LayerMask towerLayer;
    NavMeshAgent agent;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public virtual void MoveToTarget() 
    {
        agent.SetDestination(target.position);
    }
    public virtual bool TargetEnemy() 
    {
        return false;
    }
}
