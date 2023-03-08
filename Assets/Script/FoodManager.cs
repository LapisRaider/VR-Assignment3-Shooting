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

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initialSpawn; i++)
        {
            foreach (GameObject spawnPoint in spawnPoints)
            {
                Instantiate(food, spawnPoint.transform.position + new Vector3(0, i, 0), Quaternion.identity);
            }
        }
    }

    public void SpawnFood()
    {
        GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(food, spawnPoint.transform.position, Quaternion.identity);
    }
}
