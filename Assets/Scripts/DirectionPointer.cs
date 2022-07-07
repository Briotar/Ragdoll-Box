using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DirectionPointer : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _radius = 1;

    private SpriteRenderer _sprite;

    private float _rotation;
    private float _currentRotation;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();

        _rotation = 0;
        _currentRotation = 0;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            var direction = _playerInput.Direction;
            CalculateRotationAngle(direction);
            _sprite.enabled = true;
            ShowDirection(direction);
        }
        else
        {
            _sprite.enabled = false;
        }
    }

    protected void CalculateRotationAngle(Vector3 direction)
    {
        _currentRotation = Mathf.Acos(direction.y) * Mathf.Rad2Deg;

        if (direction.x > 0)
            _currentRotation = -_currentRotation;

        _rotation = Mathf.Lerp(_rotation, _currentRotation, 1 * Time.deltaTime);
        _rotation = _currentRotation;
    }

    private void ShowDirection(Vector3 direction)
    {
        transform.position = direction * _radius + _playerInput.gameObject.transform.position;
        transform.eulerAngles = new Vector3(0f, 0f, _rotation);
    }
}
