using UnityEngine;
using Zenject;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int _damage = 20;
    private NavMeshAgent _agent;
    private PlayerMove _target;

    public static event OnDeath onDeath;
    public delegate void OnDeath();

    [Inject]
    public void Constructor(PlayerMove playerMove)
    {
        _target = playerMove;

    }

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        //_target = FindObjectOfType<PlayerMove>();
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
