using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AIUtils.SafeGetExternalBehavior("Assets/Game/AssetDynamic/AI/ai1001", (ai) => {
            AIAgent aIAgent = new AIAgent(gameObject, ai);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
