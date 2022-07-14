using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZTriggerManager : Singleton<ZTriggerManager>
{
    private Dictionary<ZTriggerType, List<ZBoxTrigger>> _dicTriggers;
    private ZTriggerManager()
    {
        _dicTriggers = new Dictionary<ZTriggerType, List<ZBoxTrigger>>();
    }
    public void AddZTrigger(ZBoxTrigger zTrigger)
    {
        if (_dicTriggers.ContainsKey(zTrigger.triggerType))
        {
            if (!_dicTriggers[zTrigger.triggerType].Contains(zTrigger))
            {
                _dicTriggers[zTrigger.triggerType].Add(zTrigger);
            }
        }
        else
        {
            List<ZBoxTrigger> list = new List<ZBoxTrigger>();
            list.Add(zTrigger);
            _dicTriggers.Add(zTrigger.triggerType, list);
        }


    }
    public void RemoveZTrigger(ZBoxTrigger zTrigger)
    {
        if (_dicTriggers.ContainsKey(zTrigger.triggerType))
        {
            if (_dicTriggers[zTrigger.triggerType].Contains(zTrigger))
            {
                _dicTriggers[zTrigger.triggerType].Remove(zTrigger);
            }
        }
        else
        {
            List<ZBoxTrigger> list = new List<ZBoxTrigger>();
            _dicTriggers.Add(zTrigger.triggerType, list);
        }
    }

    public List<ZBoxTrigger> GetListByType(ZTriggerType triggerType)
    {
        if (_dicTriggers.ContainsKey(triggerType))
        {
            return _dicTriggers[triggerType];
        }
        else
        {
            List<ZBoxTrigger> list = new List<ZBoxTrigger>();
            _dicTriggers.Add(triggerType, list);
            return list;
        }
     }


    /// <summary>
    /// 返回org目标distance内的所有UnitTrigger类型的ZBoxTrigger：用于范围目标检查
    /// </summary>
    /// <param name="org"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public List<ZBoxTrigger> GetTriggersByDistance(ZBoxTrigger org,float distance,List<ZBoxTrigger> list, bool ignoreSelfCamp)
    {
        if (list == null)
        {
            list = new List<ZBoxTrigger>();
        }
        list.Clear();
        List<ZBoxTrigger> triggers = GetListByType(org.triggerType);
        for (int i = 0; i < triggers.Count; i++)
        {
          if(      triggers[i].enabled 
                && triggers[i]!= org
                && (ignoreSelfCamp?triggers[i].triggerCamp!= org.triggerCamp:true)
                && triggers[i].GetDistance(org) <= distance
                )
            {
                list.Add(triggers[i]);
            }
        }
        return list;
    }
    /// <summary>
    /// 返回产生碰撞的ZBoxtrigger,用于伤害技能检查
    /// </summary>
    /// <param name="nUTrigger"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public List<ZBoxTrigger> TriggerEnterByRange(ZBoxTrigger nUTrigger,float distance, List<ZBoxTrigger> list, List<ZBoxTrigger> list2, bool ignoreSelfCamp)
    {
        if (list2 == null)
        {
            list2 = new List<ZBoxTrigger>();
        }
        list2.Clear();
        GetTriggersByDistance(nUTrigger, distance, list, ignoreSelfCamp);
        for (int i = 0; i < list.Count; i++)
        {
           if(ZPhysics.CheckBox(list[i], nUTrigger))
            {
                list2.Add(list[i]);
            }
        }
        return list2;
    }
}
