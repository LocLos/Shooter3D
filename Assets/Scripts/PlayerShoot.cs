using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;  
    public Transform shootPoint;  
    Animator anim;
     
    void Start()
    {
        anim = GetComponentInChildren<Animator>();  
    }

     
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  
        {
            GameObject bulletObject = Instantiate(bulletPrefab);  
            bulletObject.transform.position = shootPoint.position;  
            bulletObject.transform.forward = shootPoint.forward;  
            anim.SetTrigger("isAttack");  
        }
    }
}
