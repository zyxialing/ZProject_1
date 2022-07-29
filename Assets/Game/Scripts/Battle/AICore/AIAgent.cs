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

    public void SendEvent(string eventName)
    {
        _behaviorTree.SendEvent(eventName);
        switch (eventName)
        {
            case Const_BattleEvent.event_fight_dizzy:
                ResetTime<Z_Dizzy>();
                break;
        }
    }

    public void ResetTime<T>() where T : BaseAction
    {
        _behaviorTree.FindTask<T>().ResetTime();
    }
}
