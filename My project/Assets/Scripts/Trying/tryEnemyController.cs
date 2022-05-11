using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class tryEnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent thisNavmesh;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
        thisNavmesh = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            thisNavmesh.SetDestination(target.position);
        }
    }

}
