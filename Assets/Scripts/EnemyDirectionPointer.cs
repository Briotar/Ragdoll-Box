using UnityEngine;
using UnityEngine.UI;

public class EnemyDirectionPointer : DirectionPointer
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _player;

    private Vector3 _direction;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private void FixedUpdate()
    {
        _direction = (_enemy.transform.position - _player.position).normalized;

        CalculateRotationAngle(_direction);
        _image.enabled = true;
        ShowDirection(_direction);
    }
}
