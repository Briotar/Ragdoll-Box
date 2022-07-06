using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Player _player;
    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - _player.transform.position;
    }

    void FixedUpdate()
    {
        transform.position = _player.transform.position + _offset;
    }
}
