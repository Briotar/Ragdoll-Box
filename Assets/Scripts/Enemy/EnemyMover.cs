using UnityEngine;

public class EnemyMover : Mover
{
    [SerializeField] private TargetFinder _targetFinder;

    private Vector3 _direction;

    private void Start()
    {
        CalculateDirection();
    }

    private void Update()
    {
        Rotate(_direction);
    }

    protected void FixedUpdate()
    {
        CalculateDirection();

        Move(_direction);
    }

    private void CalculateDirection()
    {
        _direction = (_targetFinder.CurrentTarget.position - gameObject.transform.position).normalized;
    }
}
