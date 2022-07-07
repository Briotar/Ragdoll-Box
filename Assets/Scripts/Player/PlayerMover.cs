using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Transform _onGroundPoint;
    [SerializeField] private Vector3 _radius = Vector3.one;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpForce = 1.5f;
    [SerializeField] private float _fallForce = 0.4f;

    private Rigidbody _rigidbody;

    private bool _canJump = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    //TODO отрефакторить метод + 2 магических числа + переворачить вектор а не просто смотреть значение
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (StayOnGround(_onGroundPoint.position, _radius))
                if (_playerInput.Direction.y <= 0.45f)
                    _rigidbody.velocity = new Vector3(_playerInput.Direction.x, 0f, 0f) * _speed;
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
    }

    private bool StayOnGround(Vector3 center, Vector3 radius)
    {
        Collider[] hitColliders = Physics.OverlapBox(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<Ground>())
                return true;
        }

        return false;
    }

    private IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(1f);

        _canJump = true;
    }
}
