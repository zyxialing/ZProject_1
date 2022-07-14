using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstacneAI : MonoBehaviour
{
    public string path;
    ZBoxTrigger boxTrigger;
    List<ZBoxTrigger> _zBoxTriggers;
    GameObject obj;
    private void Awake()
    {
        boxTrigger = GetComponent<ZBoxTrigger>();
    }

    public void Update()
    {
        _zBoxTriggers =  ZTriggerManager.Instance.GetTriggersByDistance(boxTrigger, 30, _zBoxTriggers,true);
        if (_zBoxTriggers.Count > 0)
        {
            if (obj == null)
            {
                obj = PrefabUtils.Instance(path,transform);
                obj.transform.localPosition = Vector3.zero;
                obj.transform.localRotation = Quaternion.identity;
                obj.transform.localScale = Vector3.one;
                TestAI ai = obj.GetComponent<TestAI>();
                ai.isAI = true;
                ZBoxTrigger zBoxTrigger = obj.GetComponent<ZBoxTrigger>();
                zBoxTrigger.triggerType = ZTriggerType.UnitTrigger;
                zBoxTrigger.triggerCamp = boxTrigger.triggerCamp;
            }
        }
        else
        {
            if (obj != null)
            {
                Destroy(obj);
                obj = null;
            }
        }
    }
}
