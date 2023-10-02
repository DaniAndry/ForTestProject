using UnityEngine;
using System.Collections.Generic;

public class PlayerMover : MonoBehaviour
{
    public static bool PointerDown = true;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Transform _weapon;

    private float _moveSpeed = 6f;

    private Rigidbody2D _rigidbody;
    private List<SpriteRenderer> _spriteRenderers = new List<SpriteRenderer>();
    private Vector2 _lastMovementDirection = Vector2.zero;
    private Quaternion _initialRotation;
    private bool _isFacingRight = true;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _initialRotation = transform.rotation;
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float moveX = _joystick.Horizontal;
        float moveY = _joystick.Vertical;
        float currentSpeed = PointerDown ? _moveSpeed : 0f;

        Vector2 movement = new Vector2(moveX, moveY);
        _rigidbody.velocity = movement.normalized * currentSpeed;

        if (movement != Vector2.zero)
        {
            _animator.Play("Run");
        }
        else
        {
            _animator.Play("Idle");
        }

        if (moveX > 0 && !_isFacingRight)
        {
            Flip();
        }
        else if (moveX < 0 && _isFacingRight)
        {
            Flip();
        }
    }


    private void Flip()
    {
        _isFacingRight = !_isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
