using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIAgent : IUnit
{
    #region  Ù–‘
    private BehaviorTree _behaviorTree;
    private Animator _animator;
    #endregion

    public AIAgent(GameObject obj, ExternalBehavior ai)
    {
        _animator = obj.GetComponent<Animator>();
        _behaviorTree = obj.AddComponent<BehaviorTree>();
        _behaviorTree.ExternalBehavior = ai;
        _behaviorTree.RestartWhenComplete = true;
        _behaviorTree.ResetValuesOnRestart = true;
    }
}
