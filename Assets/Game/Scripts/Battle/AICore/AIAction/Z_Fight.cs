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
        LoopEva.loopEva.mapSpeed = 0f;
        _animator.Play(Const_BattleAnim.anim_attack1,0,0);
        //anims = _animator.GetCurrentAnimatorClipInfo(0);
        taskStatus = TaskStatus.Running;
    }
    List<ZBoxTrigger> zBoxTriggers;
    public override TaskStatus OnUpdate()
    {
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

}
