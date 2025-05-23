using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speed;
    private float _damage;

    public void Init(float speed, float damage, float timeToDestroy)
    {
        _speed = speed;
        _damage = damage;
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _rb.velocity = _speed * transform.right;
        Destroy(gameObject, timeToDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.GetComponent<Player>().TakeDamage(_damage);

            Destroy(gameObject);
        }
    }
}