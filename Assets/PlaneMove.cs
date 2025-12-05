using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    int speedMove = 5;
    Vector3 moveInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        if (moveInput != Vector3.zero)
        {
            Vector3 direction = moveInput.normalized;
            transform.position += direction * speedMove * Time.deltaTime;
            MaxScreen();
        }
    }
    void MaxScreen()
    {
        Camera cam = Camera.main;
        float camHeight = 2f * cam.orthographicSize;
        float camWidth = camHeight * cam.aspect;
        float minX = cam.transform.position.x - camWidth / 2f;
        float maxX = cam.transform.position.x + camWidth / 2f;
        float minY = cam.transform.position.y - camHeight / 2f;
        float maxY = cam.transform.position.y + camHeight / 2f;
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX + 0.5f, maxX - 0.5f);
        pos.y = Mathf.Clamp(pos.y, minY + 0.5f, maxY - 0.5f);
        transform.position = pos;
    }
}
