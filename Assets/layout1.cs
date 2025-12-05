using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layout1 : MonoBehaviour
{
    public static layout1 Instance;
    public ListPoint[] points;         
    public GameObject enemyPrefab;
    private int aliveCount;           
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SpawnAllEnemies();
    }

    public void SpawnAllEnemies()
    {
        aliveCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            GameObject enemyObj = Instantiate(enemyPrefab,
                points[i].pointB.position + new Vector3(0, 3, 0),
                points[i].pointB.rotation);
            Enemy1 enemyScript = enemyObj.GetComponent<Enemy1>();
            enemyScript.pointA = points[i].pointA;
            enemyScript.pointB = points[i].pointB;
        }
    }
    public void OnEnemyDead()
    {
        aliveCount--;

        if (aliveCount <= 0)
        {
            SpawnAllEnemies();
        }
    }
}
