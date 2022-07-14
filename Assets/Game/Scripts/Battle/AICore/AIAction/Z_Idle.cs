using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[TaskCategory("Game")]
[TaskDescription("AI ID")]
public class Z_Idle : BaseAction
{
    private Animator _animator;
    private ZBoxTrigger _boxTrigger;
    private TestAI _testAI;
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
        _testAI.Play(Const_BattleAnim_Name.anim_idle);
    }
    List<ZBoxTrigger> zBoxTriggers;
    public override TaskStatus OnUpdate()
    {
        zBoxTriggers = ZTriggerManager.Instance.GetTriggersByDistance(_boxTrigger, _testAI.heroAttr.GetAttackRange(), zBoxTriggers, true);
        if (zBoxTriggers.Count > 0)
        {
            Owner.SendEvent(Const_BattleEvent.event_fight_fight);
        }
        return TaskStatus.Running;
    }
}
