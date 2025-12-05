using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    int health;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        sprite = GetComponent<SpriteRenderer>();
        GameObject prefab = MenuManager.Instance.characterPrefab[MenuManager.index];
        SpriteRenderer prefabRenderer = prefab.GetComponentInChildren<SpriteRenderer>();
        sprite.sprite = prefabRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            health--;
        }
    }
    public bool IsDie()
    {
        return (health == 0);
    }
}
