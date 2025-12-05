using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform[] gunPower;
    public GameObject Bullet;
    float timer = 0;
    int cooldown = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= cooldown)
        {
            Fire();
            timer = 0f;
        }
    }
    public void SetGun(Transform[] tf, GameObject prefab)
    {
        gunPower = tf;
        Bullet = prefab;
    }
    void Fire()
    {
        foreach (var g in gunPower)
        {
            Instantiate(Bullet, g.position, g.rotation);
        }
    }
}
