using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[TaskCategory("Game")]
[TaskDescription("AI ID")]
public class Z_Birth : BaseAction
{
    private TaskStatus taskStatus;
    public bool isEnterLevel = false;

    private Animator _animator;
    public override void OnAwake()
    {
        _animator = GetComponent<Animator>();
    }
    public override void OnStart()
    {
        _time = 0;
        if (isEnterLevel)
        {
            taskStatus = TaskStatus.Success;
        }
        else
        {
            taskStatus = TaskStatus.Running;
            _animator.SetInteger("state", 0);
            LoopEva.loopEva.mapSpeed = 0f;
            isEnterLevel = true;
        }

    }

    public override TaskStatus OnUpdate()
    {
        RecordTime();
        return taskStatus;
    }

    public override void DealTimeEvent()
    {
        if (_time > 3f)
        {
            taskStatus = TaskStatus.Success;
        }
    }
}
