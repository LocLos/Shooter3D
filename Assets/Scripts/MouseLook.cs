using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSpeed = 100f;  

    public Transform playerBody;  
    float rotationY = 0f;

     
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  
    }

     
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;  
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;  

        rotationY -= mouseY;  
        rotationY = Mathf.Clamp(rotationY, -45f, 45f);  

        transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);  

        playerBody.Rotate(Vector3.up * mouseX);  

    }
    void OnGUI()  
    {
        int size = 24;
        float posX = GetComponent<Camera>().pixelWidth / 2 - size / 4;
        float posY = GetComponent<Camera>().pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }
}
