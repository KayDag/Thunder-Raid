using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int speed = 1;
    [SerializeField] protected GameObject present;
    public int health { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual void Move() { }
    protected virtual void Shoot() { }
    protected virtual void Die()
    {
        Destroy(gameObject);
        Instantiate(present, transform.position, Quaternion.identity);
    }
}
