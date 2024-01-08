using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehTree;

public class CheckEnemyInAttack : Node
{
    private Transform _transform;
    private Animator _animator;

    public CheckEnemyInAttack(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            state = NodeState.failure;
            return state;
        }

        Transform target = (Transform)t;
        if (Vector3.Distance(_transform.position, target.position) <= AIBT.attackRange)
        {
            _animator.SetBool("Attacking", true);
            _animator.SetBool("Walking", false);

            state = NodeState.succes;
            return state;
        }

        state = NodeState.failure;
        return state;
    }

}