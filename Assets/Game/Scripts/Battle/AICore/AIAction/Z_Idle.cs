using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[TaskCategory("Game")]
[TaskDescription("AI ID")]
public class Z_Idle : BaseAction
{
    private Animator _animator;
    public override void OnAwake()
    {
        _animator = GetComponent<Animator>();
    }
    public override void OnStart()
    {

    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.Running;
    }
}
