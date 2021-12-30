using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    PlayerMove target;  
    public int damage = 20;
    GameManager levelManager;
     
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();  
        target = FindObjectOfType<PlayerMove>();  
        levelManager = FindObjectOfType<GameManager>();
    }

     
    void Update()
    {
        agent.SetDestination(target.transform.position);  
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player"))
        {
            target.TakeDamage(damage);  
            Destroy(gameObject);
            levelManager.CurrentEnemyCount--;
        }

    }
}
