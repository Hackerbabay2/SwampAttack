using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AtackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _lastAtackTime;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_lastAtackTime <= 0)
        {
            Atack(Target);
            _lastAtackTime = _delay;
        }
        _lastAtackTime -= Time.deltaTime;
    }

    private void Atack(Player target)
    {
        _animator.Play("Attack");
        target.ApplyDamage(_damage);
    }
}
