using System;
using UnityEngine;
using TMPro;

public class HPBarView : MonoBehaviour
{
    [SerializeField] private Enemy _stickman;

    private int indexInList;
    private TMP_Text _text;
    private string _percent = "%";

    public event Action<int> StickmanDied;

    private void Awake()
    {
        _text = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _stickman.HealthChanged += (float currentHealth) =>
        {
            OnHealthChaged(currentHealth);
        };

        _stickman.Died += () =>
        {
            OnDied();
        };
    }

    private void OnDisable()
    {
        _stickman.HealthChanged -= (float currentHealth) =>
        {
            OnHealthChaged(currentHealth);
        };

        _stickman.Died -= () =>
        {
            OnDied();
        };
    }

    private void OnHealthChaged(float currentHealth)
    {
        _text.text = currentHealth.ToString() + _percent;
    }

    private void OnDied()
    {
        gameObject.SetActive(false);
        StickmanDied.Invoke(indexInList);
    }

    public void SetIndex(int index)
    {
        indexInList = index;
    }
}
