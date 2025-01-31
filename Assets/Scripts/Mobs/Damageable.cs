using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] protected DamagebleStats _unitStats;
    private float _health;

    protected abstract void Die();
    protected virtual void SetStats()
    {
        _health = _unitStats.Health;
    }
    
    public void TakeDamage(float recivedDamage)
    {
        _health -= recivedDamage;
        if (_health <= 0)
        {
            Die();
        }
    }
}
