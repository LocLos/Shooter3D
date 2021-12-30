using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    CharacterController controller;

    public int health = 100;  

    public float speed = 10f;  
    public float gravity = -9.81f;  
    public float jump = 3;

    public Vector3 velocity;  

    public Transform groundPoint;  
    public float groundDistance = 0.4f;  
    public LayerMask groundMask;  

    bool isGround;  

    public Slider healthSlider;  

    public Text scoreText;
    public int score = 0;

     
    void Start()
    {
        controller = GetComponent<CharacterController>();
        scoreText.text = $"Score: {score}";
    }

     
    void Update()
    {
         
        isGround = Physics.CheckSphere(groundPoint.position, groundDistance, groundMask);

        if (isGround && velocity.y < 0)  
        {
            velocity.y = -2f;  
        }

        float x = Input.GetAxis("Horizontal");  
        float z = Input.GetAxis("Vertical");  

        Vector3 move = transform.right * x + transform.forward * z;  

        velocity.y += gravity * Time.deltaTime;  

        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }



        controller.Move(move * speed * Time.deltaTime);  
        controller.Move(velocity * Time.deltaTime);  
    }
    public void TakeDamage(int damage)
    {
        if (health >= 0)
        {
            health -= damage;
            healthSlider.value = health;
        }
    }
}
