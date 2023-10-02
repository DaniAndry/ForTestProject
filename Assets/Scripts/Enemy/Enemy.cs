using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    private int _reward = 1;

    [SerializeField] private Player _target;
    private int _currentHealth;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction OnEnemyDie;

    public Player Target => _target;
    public int Reward => _reward;

    private Animator _animator;

    private void Start()
    {
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            OnEnemyDie?.Invoke();
        }
    }

    public void Init(Player target)
    {
        _target = target;
    }
}