using UnityEngine;

public class AttackState : State
{
    [SerializeField] private float _delay;
    [SerializeField] private int _damage;

    private Animator _animator;
    private float _lastAttackTime;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player target)
    {
        target.ApplyDamage(_damage);

        _animator.Play("Attack");
    }
}