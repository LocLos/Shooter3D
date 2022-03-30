using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string Jump = "Jump";

    CharacterController controller;

    [SerializeField] 
    private float _speed = 10f;
    [SerializeField]
    private float _gravity = -9.81f;
    [SerializeField]
    private float _jump = 3;

    [SerializeField]
    private Vector3 _velocity;

    [SerializeField]
    private Transform _groundPoint;
    [SerializeField]
    private float _groundDistance = 0.4f;
    [SerializeField]
    private LayerMask _groundMask;
 
    private bool _isGround;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {

        _isGround = Physics.CheckSphere(_groundPoint.position, _groundDistance, _groundMask);

        if (_isGround && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float x = Input.GetAxis(Horizontal);
        float z = Input.GetAxis(Vertical);

        Vector3 move = transform.right * x + transform.forward * z;

        _velocity.y += _gravity * Time.deltaTime;

        if (Input.GetButtonDown(Jump) && _isGround)
        {
            _velocity.y = Mathf.Sqrt(_jump * -2f * _gravity);
        }

        controller.Move(move * _speed * Time.deltaTime);
        controller.Move(_velocity * Time.deltaTime);
    }
}
