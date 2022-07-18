using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private float _maxHealth = 100f;
    private float _currentHealth;

    private bool _canApplyDamage = true;

    public event Action<float> HealthChanged;
    public event Action Died;


    private void Start()
    {
        _currentHealth = _maxHealth;

        HealthChanged.Invoke(_currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DefeatZone>())
            Died.Invoke();
    }

    public void ApplyDamage(float hitForse, Vector3 hitDirection)
    {
        if(_canApplyDamage)
        {
            _canApplyDamage = false;
            StartCoroutine(CantApplyDamage());

            _currentHealth -= hitForse;

            if (_currentHealth <= 0)
                _currentHealth = 0;

            HealthChanged.Invoke(_currentHealth);

            var increaseHitForse = ((_maxHealth - _currentHealth) / 100f) * 2f;
            _rigidbody.velocity = hitDirection * (hitForse / 2f) * increaseHitForse;
        }
    }

    private IEnumerator CantApplyDamage()
    {
        yield return new WaitForSeconds(1f);

        _canApplyDamage = true;
    }
}
