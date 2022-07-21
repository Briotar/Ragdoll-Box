using System;
using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _onGroundPoint;
    [SerializeField] private Vector3 _radius = Vector3.one;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 1.5f;
    [SerializeField] private float _fallForce = 0.4f;
    [SerializeField] private float _additionalForce = 2f;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ParticleSystem _jumpParticle;

    private bool _canJump = true;

    public event Action<bool> OnGround;
    public event Action<float> Speed;

    protected void Rotate(Vector3 direction)
    {
        if (direction.x < 0f)
            gameObject.transform.eulerAngles = new Vector3(0f, -90f, 0f);
        else if (direction.x > 0f)
            gameObject.transform.eulerAngles = new Vector3(0f, 90f, 0f);
    }

    protected void Move(Vector3 direction)
    {
        if (StayOnGround(_onGroundPoint.position, _radius))
            if (direction.y <= 0.35f)
            {
                _rigidbody.velocity = new Vector3(direction.x, 0f, 0f) * _speed;

                Speed.Invoke(1f);
            }
            else
            {
                if (_canJump)
                {
                    _jumpParticle.Play();
                    _rigidbody.AddForce(Vector3.up * _speed * _jumpForce * _additionalForce, ForceMode.VelocityChange);
                    _rigidbody.AddForce(direction * _jumpForce * _additionalForce, ForceMode.VelocityChange);

                    _canJump = false;
                    StartCoroutine(JumpCooldown());
                }
            }
        else
            if (direction.y <= -0.2f)
                _rigidbody.AddForce(direction * _fallForce, ForceMode.VelocityChange);
    }

    protected void ChangeToIdleState()
    {
        StayOnGround(_onGroundPoint.position, _radius);
        Speed.Invoke(0f);
    }

    private bool StayOnGround(Vector3 center, Vector3 radius)
    {
        Collider[] hitColliders = Physics.OverlapBox(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<Ground>())
            {
                OnGround.Invoke(true);
                return true;
            }
        }

        OnGround.Invoke(false);
        return false;
    }

    private IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(1.5f);

        _canJump = true;
    }
}
