using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float _hitForse = 20f;
    [SerializeField] private ParticleSystem _hitEffect;

    private Vector3 _hitDirection;

    protected void Damage(Vector3 direction, Damageble enemy)
    {
        PlayHitEffect();

        _hitDirection = (new Vector3(0f, 1f, 0f) + direction).normalized + Vector3.up;

        var damageble = enemy.GetComponent<Damageble>();
        damageble.ApplyDamage(_hitForse, _hitDirection);
    }

    private void PlayHitEffect()
    {
        _hitEffect.transform.position = gameObject.transform.position;
        _hitEffect.Play();
    }
}
