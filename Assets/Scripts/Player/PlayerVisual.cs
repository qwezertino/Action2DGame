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
    }
}
