using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;

    public static event OnHitEnemy onHitEnemy;
    public delegate void OnHitEnemy();

    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            onHitEnemy?.Invoke();
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
