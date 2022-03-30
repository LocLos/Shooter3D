using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private const string _isAttack = "isAttack";

    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private Transform _shootPoint;

    private Animator _anim;
     
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();  
    }
     
    void Update()
    {
        Shooting();
    }

    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulletObject = Instantiate(_bulletPrefab);
            bulletObject.transform.position = _shootPoint.position;
            bulletObject.transform.forward = _shootPoint.forward;
            _anim.SetTrigger(_isAttack);
        }
    }
}
