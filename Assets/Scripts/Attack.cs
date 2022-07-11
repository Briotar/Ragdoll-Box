using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Joint _hand;
    [SerializeField] private PlayerInput _playerInput;

    private bool _canAttack;

    private void Start()
    {
        _canAttack = true;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
             _hand.transform.position = _playerInput.WorldPosition;
        }
    }
}
