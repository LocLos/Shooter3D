using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3f;
    PlayerMove player;
    GameManager levelManager;
     
    void Start()
    {
        player = FindObjectOfType<PlayerMove>();
        levelManager = FindObjectOfType<GameManager>();
    }

     
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;  
    }
    void OnTriggerEnter(Collider other)   
    {
        if (other.CompareTag("Enemy"))  
        {
            Destroy(other.gameObject);
            player.score++;
            player.scoreText.text = $"Score: {player.score}";
            levelManager.CurrentEnemyCount--;
        }
        Destroy(this.gameObject);  
    }
}
