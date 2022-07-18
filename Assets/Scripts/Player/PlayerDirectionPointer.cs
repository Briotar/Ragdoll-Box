using UnityEngine;

public class PlayerDirectionPointer : DirectionPointer
{
    [SerializeField] private PlayerInput _playerInput;

    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
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
}
