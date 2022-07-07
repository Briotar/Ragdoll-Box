using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Camera _camera;

    private Vector3 _screenPosition;
    private Vector3 _worldPosition;

    public Vector3 Direction { get; private set; }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            _screenPosition = Input.mousePosition;
            _screenPosition.z = 20;
            _worldPosition = _camera.ScreenToWorldPoint(_screenPosition);

            Direction = (_worldPosition - transform.position).normalized;
        }
    }
}
