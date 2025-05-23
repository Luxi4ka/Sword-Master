using System.Collections;
using UnityEngine;

public class EnemyDamageArea : MonoBehaviour, IAttack
{
    [SerializeField] private EnemyDamageAreaStats _damageAreaStats;
    private BoxCollider2D _collider2D;
    private float _damage;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _damage = _damageAreaStats.Damage;
        _collider2D = GetComponent<BoxCollider2D>();
        _collider2D.size = new Vector2(_damageAreaStats.ZoneArea, _damageAreaStats.ZoneArea);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Gate"))
        {
            other.GetComponent<Damageable>().TakeDamage(_damage);
        }
    }

    public IEnumerator Attack()
    {
        _collider2D.enabled = true;
        yield return null;
        _collider2D.enabled = false;
    }
}