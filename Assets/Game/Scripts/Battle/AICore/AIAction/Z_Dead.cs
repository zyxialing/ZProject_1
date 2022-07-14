using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[TaskCategory("Game")]
[TaskDescription("AI ID")]
public class Z_Dead : Action
{
    private TaskStatus taskStatus;
    private TestAI _testAI;
    private ZBoxTrigger _boxTrigger;
    public override void OnAwake()
    {
        _boxTrigger = GetComponent<ZBoxTrigger>();
        _testAI = GetComponent<TestAI>();
    }
    public override void OnStart()
    {
        if (!_testAI.isAI)
        {
            LoopEva.loopEva.mapSpeed = 0f;
        }
        taskStatus = TaskStatus.Running;
        Debug.Log("死亡");
        _boxTrigger.enabled = false;
        _testAI.Play(Const_BattleAnim_Name.anim_dead,1f,null,1f,endCallBack);
    }

    public override TaskStatus OnUpdate()
    {
        return taskStatus;
    }

    private void endCallBack()
    {
        taskStatus = TaskStatus.Success;
        _testAI.Clear();
    }

}
