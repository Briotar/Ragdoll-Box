using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _maxHealth = 10f;
    [SerializeField] private float _currentHealth = 10f;

    public void ApplyDamage(float hitForse)
    {
        Debug.Log(hitForse);
        _currentHealth -= hitForse;
        Debug.Log(_currentHealth);

        if (_currentHealth <= 0)
            Debug.Log("Смерть!");

        _rigidbody.velocity = Vector3.up * hitForse * (_maxHealth - _currentHealth + 1f);
    }
}
