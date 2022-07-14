using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ZBoxTrigger : MonoBehaviour
{
    [SerializeField]
    private Vector3 center;
    [SerializeField]
    private Vector3 size;
    [HideInInspector]
    public TestAI testAI;
    public ZTriggerType triggerType;
    public ZTriggerCamp triggerCamp;
    public Vector3 Size { get => size; set => size = value; }
    public Vector3 Center { get => transform.position+center; set => center = value; }
    private void Awake()
    {
        testAI = GetComponent<TestAI>();
    }
    private void OnEnable()
    {
        ZTriggerManager.Instance.AddZTrigger(this);
    }
    private void OnDisable()
    {
        ZTriggerManager.Instance.RemoveZTrigger(this);
    }
    public float GetDistance(ZBoxTrigger trigger)
    {
        return Vector3.Distance(Center, trigger.Center);
    }







































































    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Center, Size);
    }
}
