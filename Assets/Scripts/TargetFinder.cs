using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    [SerializeField] private Transform[] _targets;

    private float[] _distanceToTargets;
    private float minDistance = Mathf.Infinity;
    private int _currentIndex;

    public Transform CurrentTarget { get; private set; }

    private void Awake()
    {
        _distanceToTargets = new float[_targets.Length];

        ChooseTarget();
    }

    void Update()
    {
        ChooseTarget();
    }
    
    private void ChooseTarget()
    {
        for (int i = 0; i < _targets.Length; i++)
        {
            _distanceToTargets[i] = (gameObject.transform.position - _targets[i].position).magnitude;

            if (_distanceToTargets[i] < minDistance)
            {
                minDistance = _distanceToTargets[i];
                _currentIndex = i;
            }
        }

        CurrentTarget = _targets[_currentIndex];
        minDistance = Mathf.Infinity;
    }
}

