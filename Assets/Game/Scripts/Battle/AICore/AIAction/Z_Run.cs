using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[TaskCategory("Game")]
[TaskDescription("AI ID")]
public class Z_Run : BaseAction
{
    private Animator _animator;
    private ZBoxTrigger _boxTrigger;
    public override void OnAwake()
    {
        _animator = GetComponent<Animator>();
        _boxTrigger = GetComponent<ZBoxTrigger>();
    }
    public override void OnStart()
    {
        LoopEva.loopEva.mapSpeed = 0.1f;
        _animator.Play(Const_BattleAnim.anim_run, 0, 0);
    }
    List<ZBoxTrigger> zBoxTriggers;
    public override TaskStatus OnUpdate()
    {
        zBoxTriggers = ZTriggerManager.Instance.GetTriggersByDistance(_boxTrigger, 2f);
        if (zBoxTriggers.Count > 0)
        {
            Owner.SendEvent(Const_BattleEvent.event_fight_fight);
        }
        return TaskStatus.Running;
    }
}
