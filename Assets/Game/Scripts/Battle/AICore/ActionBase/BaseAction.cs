using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[TaskCategory("Game")]
[TaskDescription("AI ID")]
public class BaseAction : Action
{
    protected float _time = 0;

    public virtual void RecordTime()
    {
        _time += Time.deltaTime;
        DealTimeEvent();
    }

    public virtual void DealTimeEvent()
    {

    }


}
