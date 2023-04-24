using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] _listOfEnemy;
    private float startDeley = 1.0f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDeley, Random.Range(1,4));
    }

    void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, _listOfEnemy.Length);
        int spawnEnemyHeight = Random.Range(-9, 9);
        Vector3 spawnPoint = new Vector3(30, spawnEnemyHeight, 0);
        Instantiate(_listOfEnemy[enemyIndex], spawnPoint, _listOfEnemy[enemyIndex].transform.rotation);
    }
}
