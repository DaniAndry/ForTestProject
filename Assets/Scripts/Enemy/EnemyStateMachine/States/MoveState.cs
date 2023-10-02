using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float _speed;

    private bool _isfacingRight = true;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
        _animator.Play("Run");
        Flip();
    }

    private void Flip()
    {
        Vector2 moveDirection = (Target.transform.position - transform.position).normalized;

        if ((moveDirection.x > 0 && !_isfacingRight) || (moveDirection.x < 0 && _isfacingRight))
        {
            _isfacingRight = !_isfacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
