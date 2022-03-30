using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int _damage = 20;
    private NavMeshAgent _agent;
    private PlayerMove _target;

    public static event OnDeath onDeath;
    public delegate void OnDeath();

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _target = FindObjectOfType<PlayerMove>();
    }

    void Update()
    {
        _agent.SetDestination(_target.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth player))
        {
            player.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        onDeath?.Invoke();

    }
}
