using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSenses : CoreComponent
{
    public LayerMask WhatIsEnemy { get => whatIsEnemy; set => whatIsEnemy = value; }

    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private float criticalDistance;
    [SerializeField] private float minDistance;
    [SerializeField] private float middleDistance;
    [SerializeField] private float maxDistance;

    public bool maxRange
    {
        get => Physics2D.Raycast(transform.root.position, Vector2.right * -1, maxDistance, whatIsEnemy);
    }

    public bool middleRange
    {
        get => Physics2D.Raycast(transform.root.position, Vector2.right * -1, middleDistance, whatIsEnemy);
    }

    public bool minRange
    {
        get => Physics2D.Raycast(transform.root.position, Vector2.right * -1, minDistance, whatIsEnemy);
    }

    public bool cliticalRange
    {
        get => Physics2D.Raycast(transform.root.position, Vector2.right * -1, criticalDistance, whatIsEnemy);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.root.position,transform.root.position + new Vector3(maxDistance * -1,0,0));

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.root.position, transform.root.position + new Vector3(middleDistance * -1, 0, 0));

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.root.position, transform.root.position + new Vector3(minDistance * -1, 0, 0));

        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.root.position, transform.root.position + new Vector3(criticalDistance * -1, 0, 0));
    }
}
