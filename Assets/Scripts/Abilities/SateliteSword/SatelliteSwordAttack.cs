using UnityEngine;

public class SatelliteSwordAttack : UltimateAttack
{
    [SerializeField] private Transform _playerPositionTracker;
    protected override void InitAbility(GameObject instancedAbility, AbilityStats stats)
    {
        instancedAbility.transform.parent = _playerPositionTracker;
        base.InitAbility(instancedAbility, stats);
    }
}
