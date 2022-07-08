using BehaviorDesigner.Runtime.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[TaskCategory("Game")]
[TaskDescription("AI ID")]
public class Z_Fight : BaseAction
{
    private TaskStatus taskStatus;
    private Animator _animator;
    private ZBoxTrigger _boxTrigger;
    private TestAI _testAI;
    private HitData _hitData;
    private bool isCD = true;
    public override void OnAwake()
    {
        _animator = GetComponent<Animator>();
        _boxTrigger = GetComponent<ZBoxTrigger>();
        _testAI = GetComponent<TestAI>();
    }
    public override void OnStart()
    {
        if (!_testAI.isAI)
        {
            LoopEva.loopEva.mapSpeed = 0f;
        }
        isCD = false;
        _time = 9999f;
        //anims = _animator.GetCurrentAnimatorClipInfo(0);
        taskStatus = TaskStatus.Running;
    }
    List<ZBoxTrigger> zBoxTriggers;
    public override TaskStatus OnUpdate()
    {
        RecordTime();
        zBoxTriggers = ZTriggerManager.Instance.GetTriggersByDistance(_boxTrigger, _testAI.heroAttr.GetAttackRange(),true);
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
        if (!isCD && _time >= _testAI.heroAttr.GetAttackInterval())
        {
            _testAI.Play(Const_BattleAnim_Name.anim_attack1, _testAI.heroAttr.GetAttackSpeed(), ProgressBack,0.5f, FightCallBack, true);
            isCD = true;
        }
    }

    private void ProgressBack()
    {
        if (_testAI.isAI)
        {
            Debug.Log("xxxxxxxxxxxxxx");
        }
    }
    private void FightCallBack()
    {
        _time = 0;
        isCD = false;
        if (!isCD && _time >= _testAI.heroAttr.GetAttackInterval())
        {
            _hitData = new HitData(1);
            if (_testAI.heroAttr.GetCriticalHitAnim()&&Random.Range(0,10)<5)
            {
                _testAI.Play(Const_BattleAnim_Name.anim_attack1, _testAI.heroAttr.GetAttackSpeed(), ProgressBack, 0.5f, FightCallBack, true);
            }
            else
            {
                _hitData.isCriticalHit = true;
                _testAI.Play(Const_BattleAnim_Name.anim_attack2, _testAI.heroAttr.GetAttackSpeed(), ProgressBack, 0.5f, FightCallBack, true);
            }
            isCD = true;
        }
        else
        {
            _testAI.Play(Const_BattleAnim_Name.anim_idle);
        }
    }

}
