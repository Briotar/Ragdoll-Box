using System.Collections;
using UnityEngine;

public class PlayerAttacker : Attacker
{
    [SerializeField] private PlayerInput _playerInput;

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Attack(_playerInput.WorldPosition);
        }
        else
        {
            AttackEnding();
        }
    }
}
