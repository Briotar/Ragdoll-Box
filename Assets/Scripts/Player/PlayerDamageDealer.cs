using UnityEngine;

public class PlayerDamageDealer : DamageDealer
{
    [SerializeField] private PlayerInput _playerInput;

    private Damageble _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Damageble>(out _enemy))
        {
            if (other.gameObject != _playerInput.gameObject)
                Damage(_playerInput.Direction, _enemy);
        }
    }
}
