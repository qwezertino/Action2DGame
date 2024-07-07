using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private const string IS_MOVING = "IsMoving";
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool isMoving = Player.Instance.IsMoving();
        _animator.SetBool(IS_MOVING, isMoving);
        AdjustPlayerFacingDirection();
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = GameInput.Instance.GetMousePosition();
        Vector3 playerScreenPosition = Player.Instance.GetPlayerScreenPosition();

        Vector3 direction = (mousePos - playerScreenPosition).normalized;

        _animator.SetFloat(HORIZONTAL, direction.x); // Left direction
        _animator.SetFloat(VERTICAL, direction.y); // Left direction
        // if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && direction.x > 0)
        // {
        //     _spriteRenderer.flipX = true;
        // }
        // if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        // {
        //     // Facing left or right
        //     if (direction.x < 0)
        //     {
        //         // Facing left
        //         _animator.SetInteger(DIRECTION, 1); // Left direction
        //         _spriteRenderer.flipX = false;
        //     }
        //     else
        //     {
        //         // Facing right
        //         _animator.SetInteger(DIRECTION, 1); // Right direction
        //         _spriteRenderer.flipX = true;
        //     }
        // }
        // else
        // {
        //     // Facing up or down
        //     _spriteRenderer.flipX = false;
        //     if (direction.y < 0)
        //     {
        //         // Facing down
        //         _animator.SetInteger(DIRECTION, 2); // Down direction
        //     }
        //     else
        //     {
        //         // Facing up
        //         _animator.SetInteger(DIRECTION, 0); // Up direction
        //     }
        // }
    }
}
