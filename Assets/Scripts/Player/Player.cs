using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] private float _movingSpeed = 5f;
    private Rigidbody2D _rigidbody;
    private float _minMovingSpeed = 0.1f;
    private bool _moving = false;
    private Vector2 inputVector = Vector2.zero;

    private void Awake()
    {
        Instance = this;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameInput.Instance.OnPlayerAttack += GameInput_OnPlayerAttack;
    }

    private void GameInput_OnPlayerAttack(object sender, System.EventArgs e)
    {
        ActiveWeapon.Instance.GetActiveWeapon().Attack();
    }
    private void Update()
    {
        inputVector = GameInput.Instance.GetMovementVector();
    }
    private void FixedUpdate()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {

        _rigidbody.MovePosition(_rigidbody.position + inputVector * (_movingSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > _minMovingSpeed || Mathf.Abs(inputVector.y) > _minMovingSpeed)
        {
            _moving = true;
        }
        else
        {
            _moving = false;
        }
    }
    public bool IsMoving()
    {
        return _moving;
    }
    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
}
