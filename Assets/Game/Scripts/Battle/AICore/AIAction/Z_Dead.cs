using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[TaskCategory("Game")]
[TaskDescription("AI ID")]
public class Z_Dead : BaseAction
{
    private TaskStatus taskStatus;
    private TestAI _testAI;
    private ZBoxTrigger _boxTrigger;
    private bool _readyClear = false;
    public override void OnAwake()
    {
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
        taskStatus = TaskStatus.Running;
        _boxTrigger.enabled = false;
        _readyClear = false;
        _testAI.Play(Const_BattleAnim_Name.anim_dead,1f,null,1f,endCallBack);
    }

    public override TaskStatus OnUpdate()
    {
        RecordTime();
        return taskStatus;
    }
    public override void DealTimeEvent()
    {
        if (_readyClear)
        {
            if (_time > 3f)
            {
                taskStatus = TaskStatus.Success;
                _testAI.Clear();
            }
        }
    }

    private void endCallBack()
    {
        _time = 0;
        _readyClear = true;
        if (!_testAI.isAI)
        {
            ZLogUtil.LogError("游戏失败，游戏结束！");
            EventManager.Instance.Dispatch(Event_Battle_Dead.AutoCreate());
        }
        else
        {
            Statistics.Instance.SetBattleStage();
        }
    }

}
