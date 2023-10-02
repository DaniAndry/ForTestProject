
using UnityEngine;

public class EnemyDieTransition : Transition
{
    [SerializeField] protected Enemy Enemy;

    private void OnEnable()
    {
        Enemy.OnEnemyDie += EnemyDie;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDie -= EnemyDie;
    }

    private void EnemyDie()
    {
        NeedTransit = true;
    }
}
