using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAI : MonoBehaviour
{
    void Start()
    {
        AIUtils.SafeGetExternalBehavior("Assets/Game/AssetDynamic/AI/ai1001", (ai) =>
        {
            AIAgent aIAgent = new AIAgent(gameObject, ai);
        });
    }

    // Update is called once per frame
    //void Update()
    //{
    //    List<ZBoxTrigger> zBoxTriggers =  ZTriggerManager.Instance.TriggerEnterByRange(GetComponent<ZBoxTrigger>(), 10f);
    //    if (zBoxTriggers.Count > 0)
    //    {
    //        Debug.Log("∏¯”Î…À∫¶");
    //        gameObject.SetActive(false);
    //    }
    //}
}
