using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListGun : MonoBehaviour
{
    public GunBarrel[] guns;
    Shoot shoot;
    // Start is called before the first frame update
    void Start()
    {
        shoot = GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGun();
    }
    void UpdateGun()
    {
        foreach (var g in guns)
        {
            if (GameManager.Instance.level == g.level)
            {
                shoot.SetGun(g.points, g.bullet);
            }
        }
    }
}
