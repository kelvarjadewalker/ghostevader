using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectSpawner : MonoBehaviour
{
    // Editor Fields
    [SerializeField] private GameObject prefab;
    [SerializeField] private float timeBetweenSpawns;
    [SerializeField] private Transform[] spawnPointArray;
    
    // Internal Fields
    [SerializeField] private bool _isRunning;  // This is `[SerializeField]` for testing only
    private Coroutine _spawningCoroutine;
    
    // Unity Events
    private void Start()
    {
        StartSpawner();
    }

    // Internal Functions
    private IEnumerator SpawnObjects()
    {
        WaitForSeconds delay = new WaitForSeconds(timeBetweenSpawns);

        while (_isRunning)
        {
            int spawnIndex = Random.Range(0, spawnPointArray.Length);
            Instantiate(prefab, spawnPointArray[spawnIndex].position, Quaternion.identity);
            yield return delay;
        }
    }

    private void StartSpawner()
    {
        if (_spawningCoroutine != null)
        {
            StopCoroutine(_spawningCoroutine);
        }

        _isRunning = true;
        _spawningCoroutine = StartCoroutine(SpawnObjects());
    }

    private void StopSpawner()
    {
        _isRunning = false;
        
        // This is not needed, use if you hard code the spawning to always be true.
        // You may need to make sure `_spawningRoutine` is not null
        // StopCoroutine(_spawningRoutine);
    }

    
    
}
