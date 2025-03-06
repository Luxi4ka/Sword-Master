using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemies : MonoBehaviour
{
    public static event Action OnGameWin;
    
    [SerializeField] private GameObject _gate;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _gatePosition;

    [SerializeField] private SpawnerData _spawnerData;
    private int _enemyCounter;
    private int _enemyTotal;

    private void OnEnable()
    {
        Enemy.OnDeath += UpdateEnemyCount;
    }

    private void OnDisable()
    {
        Enemy.OnDeath -= UpdateEnemyCount;
    }

    public void StartWave()
    {
        _enemyTotal = _spawnerData.EnemyWave[_enemyCounter];
        StartCoroutine(SpawnEnemy());
        _gate.SetActive(true);
    }

    private IEnumerator SpawnEnemy()
    {
        for (var i = 0; i < _spawnerData.EnemyWave[_enemyCounter]; i++) //todo enemyCount
        {
            
            yield return new WaitForSeconds(_spawnerData.SpawnRate);
            Vector3 _spawnOffset = new Vector2(Random.Range(_spawnerData.SpawnXmin, _spawnerData.SpawnXmax),
                Random.Range(-_spawnerData.SpawnY, _spawnerData.SpawnY));
            var newEnemy = Instantiate(_enemy, _gatePosition.position + _spawnOffset, _gatePosition.rotation);
            var enemy = newEnemy.GetComponent<Enemy>();
           
            enemy.Target = _gatePosition;
        }

        _enemyCounter++;
    }
    
    private void UpdateEnemyCount()
    {
        _enemyTotal--;
        
        if (_enemyTotal <= 0)
        {
            OnGameWin?.Invoke();
           
            _gate.SetActive(false);
        }
    }
}
