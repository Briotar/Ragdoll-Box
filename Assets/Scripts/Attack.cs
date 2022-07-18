using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Joint _hand;
    [SerializeField] private Transform _arm;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Collider _collider;

    private Rigidbody _ConnectedArm;
    private Vector3 _firstPosition;
    private float _lerpSpeed = 0.15f;

    private bool _canAttack = true;

    private void Start()
    {
        _ConnectedArm = _hand.connectedBody;
        _firstPosition = _hand.transform.localPosition;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if(_canAttack)
            {
                _collider.enabled = true;

                SetHandPosition(_hand.transform.position, _playerInput.WorldPosition);

                StartCoroutine(Attacking());
                StartCoroutine(AttackCooldown());
            }
            else
            {
                _collider.enabled = false;

                SetHandLocalPosition(_hand.transform.localPosition, _firstPosition);
            }
        }
        else
        {
            _collider.enabled = false;

            SetHandLocalPosition(_hand.transform.localPosition, _firstPosition);
        }
    }

    private void SetHandPosition(Vector3 handPosition, Vector3 settingPosition)
    {
        SetHandRotation(settingPosition);

        _hand.connectedBody = null;
        _hand.transform.position = Vector3.Lerp(handPosition, settingPosition, _lerpSpeed);
        _hand.connectedBody = _ConnectedArm;
    }

    private void SetHandLocalPosition(Vector3 handLocalPosition, Vector3 settingPosition)
    {
        _hand.connectedBody = null;
        _hand.transform.localPosition = Vector3.Lerp(handLocalPosition, settingPosition, _lerpSpeed);
        _hand.connectedBody = _ConnectedArm;
    }

    private void SetHandRotation(Vector3 settingPosition)
    {
        Vector2 armToSettingPoint = new Vector2(settingPosition.x - _arm.position.x, settingPosition.y - _arm.position.y);
        float angle = Vector2.Angle(new Vector2(0f, 1f), armToSettingPoint);
        _arm.eulerAngles = new Vector3(_arm.eulerAngles.x, _arm.eulerAngles.y, angle);
    }

    private IEnumerator Attacking()
    {
        yield return new WaitForSeconds(0.4f);

        _canAttack = false;
    }

    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(2f);

        _canAttack = true;
    }
}
