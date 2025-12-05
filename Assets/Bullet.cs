using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int speed = 5;
    [SerializeField] public int dmg = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.health -= dmg;
            Destroy(gameObject);
        }
    }
    void move()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;
        float minX = cam.transform.position.x - camWidth / 2f;
        float maxX = cam.transform.position.x + camWidth / 2f;
        float minY = cam.transform.position.y - camHeight / 2f;
        float maxY = cam.transform.position.y + camHeight / 2f;
        Vector3 pos = transform.position;
        if (pos.x > maxX || pos.x < minX || pos.y > maxY || pos.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
