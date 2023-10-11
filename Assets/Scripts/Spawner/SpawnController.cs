using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private List<Transform> _spawnPoints = new List<Transform>();

    [Range(0, 100)]
    [SerializeField] private int _obstacleChance;
    [SerializeField] private List<string> _collectiblesTag;

    public List<Transform> SpawnPoints => _spawnPoints;

    public void Spawn()
    {
        int randomValue = Random.Range(0, 100);
        int randomSpawnPoint = Random.Range(0, SpawnPoints.Count);
        if (randomValue <= _obstacleChance)
        {
            ObjectPooler.Instance.Pop("Obstacle", SpawnPoints[randomSpawnPoint].position, Quaternion.identity);
            return;
        }
        ObjectPooler.Instance.Pop(_collectiblesTag[Random.Range(0, _collectiblesTag.Count)], SpawnPoints[randomSpawnPoint].position, Quaternion.identity);
    }
}
