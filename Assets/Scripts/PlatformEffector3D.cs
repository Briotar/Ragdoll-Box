using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlatformEffector3D : MonoBehaviour
{
    [SerializeField] private Transform _checkPoint;
    [SerializeField] private LayerMask _mask;

    private Collider[] _colliders;
    private bool _enter;

    private Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        _colliders = Physics.OverlapBox(_checkPoint.position, transform.localScale, Quaternion.identity, _mask);

        if(_colliders.Length <= 0)
        {
            _collider.isTrigger = true;
        }
        else
        {
            if (!_enter)
                _collider.isTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Damageble>())
            _enter = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<Damageble>())
        {
            _enter = false;

            if (_colliders.Length > 0)
                _collider.isTrigger = false;
            else
                _collider.isTrigger = true;
        }
    }
}
