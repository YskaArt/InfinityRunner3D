using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Prefabs de Enemigos")]
    public List<GameObject> enemyPrefabs; // Prefabs a spawnear

    [Header("Configuración de Spawner")]
    public float spawnInterval = 2f;      
    public Transform spawnPoint;           
    public float laneDistance = 4f;        
    public int numberOfLanes = 3;          

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefabs.Count == 0 || spawnPoint == null)
            return;

        
        int enemyIndex = Random.Range(0, enemyPrefabs.Count);
        GameObject selectedEnemy = enemyPrefabs[enemyIndex];

        // Selecciona un carril aleatorio 
        int lane = Random.Range(0, numberOfLanes);
        float xPos = (lane - 1) * laneDistance;

        // Calcula posición final
        Vector3 spawnPosition = new Vector3(xPos, spawnPoint.position.y, spawnPoint.position.z);

        // Instancia el enemigo
        Instantiate(selectedEnemy, spawnPosition, Quaternion.identity);
    }
}
