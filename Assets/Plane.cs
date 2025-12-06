using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public static Plane Instance;
    int health;
    public SpriteRenderer sprite;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        health = 2;
        sprite = GetComponent<SpriteRenderer>();
        GameObject prefab = MenuManager.Instance.characterPrefab[MenuManager.index];
        SpriteRenderer prefabRenderer = prefab.GetComponentInChildren<SpriteRenderer>();
        sprite.sprite = prefabRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        IsDie();
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
        if (health == 0)
        {
            Destroy(gameObject);
            return true;
        }
        else return false;
    }
}
