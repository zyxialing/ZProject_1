using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[TaskCategory("Game")]
[TaskDescription("AI ID")]
public class Z_Dead : Action
{
    private TaskStatus taskStatus;
    public override void OnStart()
    {
        taskStatus = TaskStatus.Running;
        StartCoroutine(IdelAnim());
    }

    public override TaskStatus OnUpdate()
    {
        return taskStatus;
    }

    private IEnumerator IdelAnim()
    {
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("Idel播放中...");
            yield return new WaitForSeconds(1f);
        }
        taskStatus = TaskStatus.Failure;
    }

}
