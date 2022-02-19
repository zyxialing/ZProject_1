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

    public override TaskStatus OnUpdate()
    {
        RecordTime();
        return taskStatus;
    }
    int k = 0;
    bool complete = true;
    public override void DealTimeEvent()
    {
        AnimatorStateInfo animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if (_time >= animatorStateInfo.length*0.48f && complete)
        {
            complete = false;
            k++;
            ZLogUtil.LogError("xxxxxxxxxxx"+ k);
        }
        if (!complete && _time >= animatorStateInfo.length)
        {
            _time = 0;
            complete = true;
        }
        //ZLogUtil.Log(Mathf.RoundToInt(animatorStateInfo.normalizedTime*20));
    }

}
