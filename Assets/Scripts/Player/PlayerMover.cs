using System;
using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Transform _onGroundPoint;
    [SerializeField] private Vector3 _radius = Vector3.one;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 1.5f;
    [SerializeField] private float _fallForce = 0.4f;

    [SerializeField] private Rigidbody _rigidbody;

    private bool _canJump = true;

    public event Action<bool> OnGround;
    public event Action<float> Speed;

    private void Update()
    {
        if (_playerInput.Direction.x < 0f)
            gameObject.transform.eulerAngles = new Vector3(0f, -90f, 0f);
        else if(_playerInput.Direction.x > 0f)
            gameObject.transform.eulerAngles = new Vector3(0f, 90f, 0f);

    }

    //TODO отрефакторить метод + 2 магических числа + переворачить вектор а не просто смотреть значение
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (StayOnGround(_onGroundPoint.position, _radius))
                if (_playerInput.Direction.y <= 0.45f)
                {
                    _rigidbody.velocity = new Vector3(_playerInput.Direction.x, 0f, 0f) * _speed;

                    Speed.Invoke(1f);
                }
                else
                {
                    if (_canJump)
                    {
                        _rigidbody.AddForce(Vector3.up * _speed * _jumpForce, ForceMode.VelocityChange);
                       
                        _canJump = false;
                        StartCoroutine(JumpCooldown());
                    }
                }
            else
                if (_playerInput.Direction.y <= -0.2f)
                    _rigidbody.AddForce(_playerInput.Direction * _fallForce, ForceMode.VelocityChange);
        }
        else
        {
            StayOnGround(_onGroundPoint.position, _radius);
            Speed.Invoke(0f);
        }
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
        yield return new WaitForSeconds(1f);

        _canJump = true;
    }
}
