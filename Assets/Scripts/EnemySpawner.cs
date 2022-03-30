using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemySpawnPoints;

    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private int _countEnemy = 5;
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
        GameObject enemy = Instantiate(_enemyPrefab) as GameObject;
        int index = Random.Range(0, _enemySpawnPoints.Length);
        Debug.Log(index);
        enemy.transform.position = _enemySpawnPoints[index].transform.position;
    }
}
