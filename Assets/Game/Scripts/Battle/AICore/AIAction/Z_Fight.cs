using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[TaskCategory("Game")]
[TaskDescription("AI ID")]
public class Z_Fight : BaseAction
{
    private TaskStatus taskStatus;
    private Animator _animator;
    private ZBoxTrigger _boxTrigger;
    public override void OnAwake()
    {
        _animator = GetComponent<Animator>();
    }
    public override void OnStart()
    {
        _time = 0;
        LoopEva.loopEva.mapSpeed = 0f;
        _animator.SetInteger("state", 2);
        taskStatus = TaskStatus.Running;
    }
    List<ZBoxTrigger> zBoxTriggers;
    public override TaskStatus OnUpdate()
    {
        zBoxTriggers = ZTriggerManager.Instance.GetTriggersByDistance(_boxTrigger, 2f);
        if (zBoxTriggers.Count > 0)
        {
            return TaskStatus.Running;
        }
        else
        {
            return TaskStatus.Success;
        }
    }

}
