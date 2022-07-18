using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<float> HealthCnaged;
    public event Action OnDied;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<DefeatZone>())
            OnDied.Invoke();
    }
}
