using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private List<Transform> _spawnPoints = new List<Transform>();

    [Range(0, 100)]
    [SerializeField] private int _obstacleChance;
    [SerializeField] private ObstacleBase _obstacle;
    [SerializeField] private List<CollectibleBase> _collectibles;

    public List<Transform> SpawnPoints => _spawnPoints;

    public void Spawn()
    {
        int randomValue = Random.Range(0, 100);
        int randomSpawnPoint = Random.Range(0, SpawnPoints.Count);
        if (randomValue <= _obstacleChance)
        {
            Instantiate(_obstacle.gameObject, SpawnPoints[randomSpawnPoint].position , Quaternion.identity);
            return;
        }
        Instantiate(_collectibles[Random.Range(0,_collectibles.Count)].gameObject, SpawnPoints[randomSpawnPoint].position, Quaternion.identity);
    }
}
