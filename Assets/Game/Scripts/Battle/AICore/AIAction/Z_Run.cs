using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[TaskCategory("Game")]
[TaskDescription("AI ID")]
public class Z_Run : BaseAction
{
    private Animator _animator;
    private ZBoxTrigger _boxTrigger;
    public override void OnAwake()
    {
        _animator = GetComponent<Animator>();
        _boxTrigger = GetComponent<ZBoxTrigger>();
    }
    public override void OnStart()
    {
        _animator.SetInteger("state", 1);
        LoopEva.loopEva.mapSpeed = 0.1f;
    }
    List<ZBoxTrigger> zBoxTriggers;
    public override TaskStatus OnUpdate()
    {
        zBoxTriggers = ZTriggerManager.Instance.GetTriggersByDistance(_boxTrigger, 1f);
        if (zBoxTriggers.Count > 0)
        {
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Running;
        }
    }
}
