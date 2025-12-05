using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int health;
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
    void Die()
    {
        if (health == 0)
            Destroy(gameObject);
    }
}
