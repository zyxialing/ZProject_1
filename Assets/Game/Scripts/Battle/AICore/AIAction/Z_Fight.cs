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
            _testAI.unitMono.speed = 0f;
            //LoopEva.loopEva.mapSpeed = 1F;
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
        zBoxTriggers = ZTriggerManager.Instance.GetTriggersByDistance(_boxTrigger, _testAI.heroAttr.GetAttackRange(), zBoxTriggers, true);
        //if (!_testAI.isAI)
        //{
        //    Debug.Log(zBoxTriggers.Count);
        //}
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
            Attack();
        }
    }

    private void ProgressBack()
    {
        if (_hitData != null)
        {
            if (zBoxTriggers != null && zBoxTriggers.Count > 0)
            {
                foreach (var item in zBoxTriggers)
                {
                    item.testAI.BeHurt(_hitData);
                }
            }
        }
        if (!_testAI.isAI)
        {
           
        }
    }
    private void FightCallBack()
    {
        _time = 0f;
        isCD = false;
        if (!isCD && _time >= _testAI.heroAttr.GetAttackInterval())
        {
            Attack();
        }
        else
        {
            _testAI.Play(Const_BattleAnim_Name.anim_idle);
        }
    }

    private void Attack()
    {
        var weight = Random.Range(1, 101);
        if(weight <= _testAI.heroAttr.GetCriticalHitProbability())
        {
            _hitData = new HitData(-50);
            _hitData.isCriticalHit = true;
            _hitData.isDizzy = true;
        }
        else
        {
            _hitData = new HitData(-5);
        }
        if (_testAI.heroAttr.GetCriticalHitAnim()&&_hitData.isCriticalHit)
        {
            _testAI.Play(Const_BattleAnim_Name.anim_attack2, _testAI.heroAttr.GetAttackSpeed(), ProgressBack,_testAI.heroAttr.GetAttackProgressBack(), FightCallBack, true);
        }
        else
        {
            _testAI.Play(Const_BattleAnim_Name.anim_attack1, _testAI.heroAttr.GetAttackSpeed(), ProgressBack,_testAI.heroAttr.GetAttackProgressBack(), FightCallBack, true);
        }
        isCD = true;
    }
}
