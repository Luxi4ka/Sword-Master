using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private float _spawnRate;

    private void Start()
    {
        StartCoroutine(SpawnRate());
    }
    private IEnumerator SpawnRate()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnRate);
            Vector3 _spawnOffset = new Vector2(Random.Range(-_spawnRadius, _spawnRadius), Random.Range(-_spawnRadius, _spawnRadius));
            GameObject newEnemy = Instantiate(_enemy, _playerTransform.position + _spawnOffset, _playerTransform.rotation);
            Enemy enemy = newEnemy.GetComponent<Enemy>();
            enemy.Target = _playerTransform;
        }
    }
}
