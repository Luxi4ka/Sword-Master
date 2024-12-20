using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    private Transform _target;
    public Transform Target { set { _target = value; } }
    private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    public float Speed { set { _speed = value; } }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Follow();
    }

    public void Follow()
    {
        if (_target == null)
        {
            return;
        }
        Vector2 direction = _target.position - transform.position;
        _rb.velocity = _speed * direction.normalized;
    }
}
