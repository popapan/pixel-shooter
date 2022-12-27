using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // enemy prefab references
    [SerializeField] private GameObject[] enemies;

    // other variables
    [SerializeField] int spawnNumber = 50;

    private void Start()
    {
        for (int i = 0; i <= spawnNumber; i++)
        {
            Instantiate(enemies[0], transform.position, transform.rotation);
        }
    }
}
