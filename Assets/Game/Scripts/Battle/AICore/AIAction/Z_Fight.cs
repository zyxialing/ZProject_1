using BehaviorDesigner.Runtime.Tasks;
using System;
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
    private TestAI _testAI;
    private CommonAnimCallBack _commonAnimCallBack;
    private bool isCD = true;
    public override void OnAwake()
    {
        _animator = GetComponent<Animator>();
        _boxTrigger = GetComponent<ZBoxTrigger>();
        _testAI = GetComponent<TestAI>();
    }
    public override void OnStart()
    {
        LoopEva.loopEva.mapSpeed = 0f;
        _testAI.Play(Const_BattleAnim.anim_attack1,fightCallBack,0.5f,0.05f);
        isCD = true;
        //anims = _animator.GetCurrentAnimatorClipInfo(0);
        taskStatus = TaskStatus.Running;
    }
    List<ZBoxTrigger> zBoxTriggers;
    public override TaskStatus OnUpdate()
    {
        RecordTime();
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

    public override void DealTimeEvent()
    {
        if (!isCD && _time > 2f)
        {
            _testAI.Play(Const_BattleAnim.anim_attack1, fightCallBack, 0.5f, 0.05f);
            isCD = true;
        }
    }

    private void fightCallBack()
    {
        Debug.Log("xxxxxxxxxxxxxx");
        _testAI.Play(Const_BattleAnim.anim_idle);
        _time = 0;
        isCD = false;
    }

}
