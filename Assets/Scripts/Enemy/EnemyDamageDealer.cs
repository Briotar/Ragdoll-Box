using UnityEngine;

public class EnemyDamageDealer : DamageDealer
{
    [SerializeField] private TargetFinder _targetFinder;

    private Damageble _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Damageble>(out _enemy))
        {
            if(other.gameObject != _targetFinder.gameObject)
            {
                Damage(_targetFinder.CurrentTarget.position, _enemy);
            }
        }
    }
}