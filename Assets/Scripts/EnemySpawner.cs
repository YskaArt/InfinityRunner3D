using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Prefabs de Secciones de Escenario")]
    public List<GameObject> scenarioPrefabs; // Prefabs de bloques/obstáculos

    [Header("Configuración del Spawner")]
    public float spawnInterval = 2f;            
    public Transform spawnPoint;                
    public float tileLength = 30f;              

    private float timer;
    private Vector3 nextSpawnPosition;

    void Start()
    {
        nextSpawnPosition = spawnPoint.position;
    }

    void Update()
    {
        if (GameManager.Instance.isGameOver) return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnTile();
            timer = 0f;
        }
    }

    void SpawnTile()
    {
        if (scenarioPrefabs.Count == 0 || spawnPoint == null)
            return;

        int index = Random.Range(0, scenarioPrefabs.Count);
        GameObject tile = Instantiate(scenarioPrefabs[index], nextSpawnPosition, Quaternion.identity);

        // Avanza el punto de aparición para el siguiente bloque
        nextSpawnPosition += Vector3.forward * tileLength;

        
    }
}
