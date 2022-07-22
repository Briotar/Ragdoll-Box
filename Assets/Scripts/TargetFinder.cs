using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    [SerializeField] private Transform[] _targets;
    [SerializeField] private float _timeToChooseNewTarget = 2f;

    private float _currentTime = 0f;

    public Transform CurrentTarget { get; private set; }

    private void Awake()
    {
        ChooseTarget();
    }

    void Update()
    {
        if(_currentTime >= _timeToChooseNewTarget)
        {
            ChooseTarget();

            _currentTime = 0f;
        }
        else
        {
            _currentTime += Time.deltaTime;
        }
    }
    
    private void ChooseTarget()
    {
        System.Random random = new System.Random();
        var index = random.Next(0, _targets.Length);

        if(_targets[index].gameObject.activeInHierarchy)
            CurrentTarget = _targets[index];
        else
            CurrentTarget = _targets[0];
    }
}

