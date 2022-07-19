using UnityEngine;

public class AnimationsHandler : MonoBehaviour
{
    [SerializeField] private Mover _mover;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform[] _legs;
    [SerializeField] private Rigidbody[] _legsRigidbody;

    private Vector3[] _localPosition;
    private Quaternion[] _localRotation;

    private void Start()
    {
        _localPosition = new Vector3[_legs.Length];
        _localRotation = new Quaternion[_legs.Length];

        for (int i = 0; i < _legs.Length; i++)
        {
            _localPosition[i] = _legs[i].localPosition;
            _localRotation[i] = _legs[i].localRotation;
        }
    }


    private void OnEnable()
    {
        _mover.OnGround += (bool OnGround) =>
        {
            StayOnGround(OnGround);
        };

        _mover.Speed += (float Speed) =>
        {
            SetSpeed(Speed);
        };
    }

    private void OnDisable()
    {
        _mover.OnGround -= (bool OnGround) =>
        {
            StayOnGround(OnGround);
        };

        _mover.Speed -= (float Speed) =>
        {
            SetSpeed(Speed);
        };
    }

    private void StayOnGround(bool OnGround)
    {
        _animator.SetBool(AnimatorStickmanController.Params.OnGround, OnGround);
    
        if(OnGround)
        {
            for (int i = 0; i < _legs.Length; i++)
            {
                _legs[i].localPosition = _localPosition[i];
                _legs[i].localRotation = _localRotation[i];
                _legsRigidbody[i].constraints = RigidbodyConstraints.FreezeRotation;
            }

            _animator.enabled = true;
        }
        else
        {
            _animator.enabled = false;

            for (int i = 0; i < _legs.Length; i++)
            {
                _legsRigidbody[i].constraints = RigidbodyConstraints.None;
            }
        }
    }

    private void SetSpeed(float Speed)
    {
        _animator.SetFloat(AnimatorStickmanController.Params.Speed, Speed);
    }
}
