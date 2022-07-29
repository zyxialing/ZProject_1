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
        if (!_testAI.isAI)
        {
           _testAI.unitMono.speed = 0f;
            //LoopEva.loopEva.mapSpeed = 1F;
        }
        _testAI.Play(Const_BattleAnim_Name.anim_birth);
        if (_testAI.heroAttr.isEnterGame)
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
            _testAI.heroAttr.isEnterGame = true;
            taskStatus = TaskStatus.Failure;
        }
        else
        {
            taskStatus = TaskStatus.Running;
        }
    }
}
