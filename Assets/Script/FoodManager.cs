using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject food;
    public int initialSpawn;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initialSpawn; i++)
        {
            Instantiate(food, transform.position + new Vector3(0, i, 0), Quaternion.identity);
        }
    }

    void SpawnFood()
    {
        Instantiate(food, transform.position, Quaternion.identity);
    }
}
