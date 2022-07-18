using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private Vector3 _hitDirection;
    private float _hitForse = 20f;

    private Enemy _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Enemy>(out _enemy))
        {
            _hitDirection = (new Vector3(0f, 1f, 0f) + _playerInput.Direction).normalized + Vector3.up;

            _enemy.ApplyDamage(_hitForse, _hitDirection);
        }
    }
}
