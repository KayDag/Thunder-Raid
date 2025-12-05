using UnityEngine;

public class Present : MonoBehaviour
{
    Plane player;
    public float speed = 5f;
    float yBottom;

    void Start()
    {
        player = Plane.Instance;
        yBottom = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0, 0)).y;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 target = new Vector3(transform.position.x, yBottom + 0.5f, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            Destroy(gameObject);
            GameManager.Instance.AddStar(1);
        }
    }
}
