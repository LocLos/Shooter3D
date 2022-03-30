using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField]
    private EnemySpawner _enemySpawner;

    [SerializeField]
    private PlayerMove _playerMove;



    public override void InstallBindings()
    {
        BindPlayer();
        CreateEnemySpawner();

    }

    private void CreateEnemySpawner()
    {
        Container.InstantiatePrefab(_enemySpawner);
        Container.BindInstance(_enemySpawner).AsSingle().NonLazy();

    }

    private void BindPlayer()
    {
        Container.BindInstance(_playerMove).AsSingle().NonLazy();
    }
}
