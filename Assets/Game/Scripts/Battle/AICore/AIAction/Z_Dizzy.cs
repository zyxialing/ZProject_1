using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[TaskCategory("Game")]
[TaskDescription("AI ID")]
public class Z_Dizzy : BaseAction
{
    private TaskStatus taskStatus;
    private Animator _animator;
    private TestAI _testAI;
    public override void OnAwake()
    {
        _animator = GetComponent<Animator>();
        _testAI = GetComponent<TestAI>();
    }
    public override void OnStart()
    {
        ResetTime();
        _testAI.Play(Const_BattleAnim_Name.anim_dizzy);
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
        else
        {
            taskStatus = TaskStatus.Running;
        }
    }

    public override void ResetTime()
    {
        base.ResetTime();
        _testAI.CancelInvoke();
        _testAI.unitMono.PlayStateText("StateText/dizzy", 3f);
    }

}
