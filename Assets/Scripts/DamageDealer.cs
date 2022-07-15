using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _hitForse = 2f;

    private Enemy _enemy;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Enemy>(out _enemy))
        {
            _enemy.ApplyDamage(_hitForse);
        }
    }
}
