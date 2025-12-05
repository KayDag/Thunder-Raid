using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class Enemy1 : Enemy
{
    public Transform pointA;
    public Transform pointB;
    private Vector3 target;
    private void Start()
    {
        health = 2;
        target = pointB.position;
    }
    private void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        Move();
        Shoot();
    }
    protected override void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
        }
    }
    protected override void Die()
    {
        base.Die();
        layout1.Instance.OnEnemyDead();
    }
}
