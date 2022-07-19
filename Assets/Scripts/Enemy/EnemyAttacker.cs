using UnityEngine;

public class EnemyAttacker : Attacker
{
    [SerializeField] private TargetFinder _targetFinder;

    private void LateUpdate()
    {
        Attack(_targetFinder.CurrentTarget.position);
        AttackEnding();
    }
}
