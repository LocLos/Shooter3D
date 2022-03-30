using System.Collections;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemySpawnPoints;

    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private int _countEnemy = 5;

    private DiContainer _diContainer;

    [Inject]
    public void Constructor(DiContainer diContainer)
    {
        _diContainer = diContainer;

    }

    private void Start()
    {
        StartCoroutine(Spawner());
    }
    public IEnumerator Spawner()
    {
        for (int i = 0; i < _countEnemy; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Random.Range(1, 2));
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = _diContainer.InstantiatePrefab(_enemyPrefab);
        int index = Random.Range(0, _enemySpawnPoints.Length);
        enemy.transform.position = _enemySpawnPoints[index].transform.position;
    }
}
