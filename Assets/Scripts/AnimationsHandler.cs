using UnityEngine;

public class AnimationsHandler : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Animator _animator;

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
            _animator.enabled = true;
        }
        else
        {
            _animator.enabled = false;
        }
    }

    private void SetSpeed(float Speed)
    {
        _animator.SetFloat(AnimatorStickmanController.Params.Speed, Speed);
    }
}
