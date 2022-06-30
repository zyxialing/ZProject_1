using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineUtils
{
    public static Coroutine InvokeStart(MonoBehaviour initiator, IEnumerator routine)
    {
      return initiator.StartCoroutine(routine);
    }
    public static Coroutine InvokeStart(MonoBehaviour initiator, string methodName, object arg = null)
    {
        return initiator.StartCoroutine(methodName,arg);
    }

}
