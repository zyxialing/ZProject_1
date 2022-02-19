using BehaviorDesigner.Runtime.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[TaskCategory("Game")]
[TaskDescription("AI ID")]
public class Z_IsAlive: Conditional
{
    private int health = 100;

    public override void OnStart()
    {
        StopAllCoroutines();
        StartCoroutine(testAction());
    }

    private IEnumerator testAction()
    {
        yield return new WaitForSeconds(30);
        health = 100;
    }

    public override TaskStatus OnUpdate()
    {
        if (health <= 0)
        {
            return TaskStatus.Failure;
        }
        else
        {
            return TaskStatus.Success;
        }
    }

    public override void OnEnd()
    {
        health = 100;
    }

    public override void OnReset()
    {
        health = 0;
    }
}
