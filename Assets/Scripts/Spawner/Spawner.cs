using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private WaitForSeconds _wfs;
    private Coroutine _coroutine;
    [SerializeField] private SpawnController _spawnController;
    [SerializeField] private Transform _parentTransform;
    [SerializeField] private Transform _initTransform;
    [SerializeField] private int _slotCount;
    [SerializeField] private int _spawnDuration;
    [SerializeField] private float _slotDistance;


    private void Awake()
    {
        CreateSpawnPoints();
        _wfs = new WaitForSeconds(_spawnDuration);
        StartRoutine();
    }

    private void OnDestroy()
    {
        StopRoutine();
    }

    public void StartRoutine()
    {
        if (_coroutine != null)
        {
            _coroutine = null;
        }
        _coroutine = StartCoroutine(SpawnRoutine());
    }

    public void StopRoutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void CreateSpawnPoints()
    {
        float initialYPosition = _initTransform.position.y;
        for (int i = 1; i < _slotCount; i++)
        {
            GameObject obj = Instantiate(_initTransform.gameObject, _parentTransform);
            obj.name = "SpawnPoint_" + i;
            obj.transform.localPosition = new Vector3(0, initialYPosition - _slotDistance, 0);
            initialYPosition -= _slotDistance;
            _spawnController.SpawnPoints.Add(obj.transform);
        }
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            _spawnController.Spawn();
            yield return _wfs;
        }
    }
}
