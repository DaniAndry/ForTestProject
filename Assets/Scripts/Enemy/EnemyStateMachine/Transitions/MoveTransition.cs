using UnityEngine;

public class MoveTransition : Transition
{
    [SerializeField] private float _transitionChaseRange;
    [SerializeField] private float _transitionMisiingRange;

    private void Update()
    {
        if (Target != null && Vector2.Distance(transform.position, Target.transform.position) > _transitionMisiingRange
            && Vector2.Distance(transform.position, Target.transform.position) < _transitionChaseRange)
        {
            NeedTransit = true;
        }
    }
}