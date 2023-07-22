using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private PathCreator path;
    
    [SerializeField] private GameObject[] enemyPrefab;

    [SerializeField] private float spawnTime;

    private float spawnTimer;

    private Vector2 spawnPos;

    private void Start()
    {
        spawnPos = path.path[0];

        spawnTimer = spawnTime;
    }

    private void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (spawnTimer <= 0)
        {
            var enemy = Instantiate(enemyPrefab[UnityEngine.Random.Range(0, enemyPrefab.Length)], spawnPos, Quaternion.identity);
            
            enemy.GetComponent<PathMove>().Init(path.path);

            spawnTimer = spawnTime;
        }

        spawnTimer -= Time.deltaTime;
    }
}