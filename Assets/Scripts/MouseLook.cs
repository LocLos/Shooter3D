using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private float _mouseSpeed = 100f;

    [SerializeField]
    private Transform _playerBody;  
    float rotationY = 0f;
     
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  
    }
     
    void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSpeed * Time.deltaTime;

        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, -45f, 45f);

        transform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);

        _playerBody.Rotate(Vector3.up * mouseX);
    }

    void OnGUI()  
    {
        int size = 24;
        float posX = GetComponent<Camera>().pixelWidth / 2 - size / 4;
        float posY = GetComponent<Camera>().pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }
}
