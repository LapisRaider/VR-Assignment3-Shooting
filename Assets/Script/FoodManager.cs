using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public static FoodManager instance;
    public GameObject food;
    public GameObject[] spawnPoints;
    public int initialSpawn;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i <= initialSpawn; i++)
        {
            foreach (GameObject spawnPoint in spawnPoints)
            {
                Instantiate(food, 
                    spawnPoint.transform.position + new Vector3(Random.Range(-0.1f, 0.1f), i, Random.Range(-0.1f, 0.1f)), 
                    Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), new Vector3(0, 1, 0))
                );
            }
        }
    }

    public void SpawnFood()
    {
        GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(food, spawnPoint.transform.position, Quaternion.AngleAxis(Random.Range(0.0f, 360.0f), new Vector3(0, 1, 0)));
    }
}
