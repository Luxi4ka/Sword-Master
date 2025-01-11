using UnityEngine;
[CreateAssetMenu(fileName = "NewAbility", menuName = "Ability")]
public abstract class AbilityStats : ScriptableObject
{
    [SerializeField] private float _damage;
    public float Damage { get { return _damage; } }

    [SerializeField] private float _lifetime;
    public float Lifetime { get { return _lifetime; } }

    [SerializeField] private float _speed;
    public float Speed { get { return _speed; } }
}
