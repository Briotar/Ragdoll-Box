using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Camera _camera;

    private Vector3 _screenPosition;
    private float _cameraToGroundRange = 20f;

    public Vector3 WorldPosition { get; private set; }
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
            _screenPosition.z = _cameraToGroundRange;
            WorldPosition = _camera.ScreenToWorldPoint(_screenPosition);

            Direction = (WorldPosition - transform.position).normalized;
        }
    }
}
