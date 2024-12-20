using UnityEngine;

public class Mob : MonoBehaviour
{
    private float _health;
    private float _damage;
    private float _attackSpeed;

    private Rigidbody2D _rb;
    private float _movementSpeed = 5;
    private Vector2 _movementDirection;
    public Vector2 MoveDirection { set { _movementDirection = value; } }


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        _rb.velocity = _movementSpeed * _movementDirection;
    }

    public void Heal()
    {

    }

    public void Damage()
    {

    }

    public void TakeDamage(float recivedDamage)
    {
        _health -= recivedDamage;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void ItemPickUp()
    {

    }

    public void UseAbility()
    {

    }

    public void AplyStun()
    {

    }

    public void ReceiveStun()
    {
       
    }

}
