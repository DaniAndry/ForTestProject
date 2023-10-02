using UnityEngine;
using System.Collections;

public class DeathState : State
{
    [SerializeField] private GameObject _item;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play("Die");
        StartCoroutine(DisappearAfterDelay());
    }

    private IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(_item, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
