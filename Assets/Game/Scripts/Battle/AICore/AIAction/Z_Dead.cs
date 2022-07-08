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
    public override void OnAwake()
    {
        _testAI = GetComponent<TestAI>();
    }
    public override void OnStart()
    {
        if (!_testAI.isAI)
        {
            LoopEva.loopEva.mapSpeed = 0f;
        }
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
