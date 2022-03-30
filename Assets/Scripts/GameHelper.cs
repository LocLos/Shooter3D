using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHelper : MonoBehaviour
{

    [SerializeField]
    private int _currentEnemyCount;

    [SerializeField]
    private int _nextLevel;

     [SerializeField]
    private EnemySpawner _enemySpawner;

    private bool _isLoadNextLvl = false;

    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private int _score = 0;

    private void Start()
    {
        _scoreText.text = $"Score: {_score}";
        Bullet.onHitEnemy += HitEnemyHandler;
        Enemy.onDeath += DeathEnemyHandler;
        DontDestroyOnLoad(this);
    }

    private void HitEnemyHandler()
    {
        _score++;
        _scoreText.text = $"Score: {_score}";
    }

    private void DeathEnemyHandler()
    {
        _currentEnemyCount--;
        if (_currentEnemyCount == 0 && !_isLoadNextLvl)
        {
            StartLvl();
            _isLoadNextLvl = true;
        }
    }
    private void StartLvl()
    {
        if (_nextLevel < SceneManager.sceneCount)
            _nextLevel++;
        else
            _nextLevel = 0;

        SceneManager.LoadScene(_nextLevel);
        _enemySpawner.StartCoroutine(_enemySpawner.Spawner());
        _isLoadNextLvl = false;
    }

    private void OnDestroy()
    {
        Enemy.onDeath -= DeathEnemyHandler;
        Bullet.onHitEnemy -= HitEnemyHandler;

    }
}
