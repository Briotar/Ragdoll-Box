using System;
using UnityEngine;

public abstract class Damageble : MonoBehaviour
{
    public event Action<float> HealthCnaged;
}
