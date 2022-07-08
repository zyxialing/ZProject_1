using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[TaskCategory("Game")]
[TaskDescription("AI ID")]
public class Z_MapSpeed : Action
{

    public override TaskStatus OnUpdate()
    {
        LoopEva.loopEva.mapSpeed = 0f;
        return TaskStatus.Success;
    }

}
