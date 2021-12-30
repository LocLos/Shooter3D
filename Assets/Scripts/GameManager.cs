using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemySpawns;  
    public GameObject enemyPrefab;  
    GameObject enemy;  
    int CountEnemy = 5;  


    public int CurrentEnemyCount;
    public int nextLevel;

    
    void Start()
    {
        StartCoroutine(Spawner());
    }
   
    IEnumerator Spawner()
    {
       for (int i=0; i< CountEnemy; i++)
        {
             
            SpawnEnemy();
            yield return new WaitForSeconds(Random.Range(1, 2));
        }
            
    }

    void SpawnEnemy()
    {
        enemy = Instantiate(enemyPrefab) as GameObject;  
        int index = Random.Range(0, enemySpawns.Length);
        Debug.Log(index);
        enemy.transform.position = enemySpawns[index].transform.position; 
    }
}
