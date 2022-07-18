using UnityEngine;

public abstract class DirectionPointer : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _radius = 1;

    private float _rotation = 0;
    private float _currentRotation = 0;

    protected void CalculateRotationAngle(Vector3 direction)
    {
        _currentRotation = Mathf.Acos(direction.y) * Mathf.Rad2Deg;

        if (direction.x > 0)
            _currentRotation = -_currentRotation;

        _rotation = Mathf.Lerp(_rotation, _currentRotation, 1 * Time.deltaTime);
        _rotation = _currentRotation;
    }

    protected void ShowDirection(Vector3 direction)
    {
        transform.position = direction * _radius + _center.position;
        transform.eulerAngles = new Vector3(0f, 0f, _rotation);
    }
}
