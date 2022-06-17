using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[TaskCategory("Game")]
[TaskDescription("AI ID")]
public class Z_Birth : BaseAction
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
        if (_testAI.heroAttr.IsEnterGame)
        {
            _time = 3f;
        }
        else
        {
            _time = 0f;
        }
    }

    public override TaskStatus OnUpdate()
    {
        RecordTime();
        return taskStatus;
    }

    public override void DealTimeEvent()
    {
        if (_time >= 3f)
        {
            _testAI.heroAttr.IsEnterGame = true;
            taskStatus = TaskStatus.Failure;
        }
        else
        {
            taskStatus = TaskStatus.Running;
        }
    }
}
