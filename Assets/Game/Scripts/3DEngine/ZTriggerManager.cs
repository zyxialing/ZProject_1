using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZTriggerManager : Singleton<ZTriggerManager>
{
    private Dictionary<ZTriggerType, List<ZBoxTrigger>> _dicTriggers;
    private ZTriggerManager()
    {
        _dicTriggers = new Dictionary<ZTriggerType, List<ZBoxTrigger>>();
        List<ZBoxTrigger> unitTriggerList = new List<ZBoxTrigger>();
        List<ZBoxTrigger> noneUnitTriggerList = new List<ZBoxTrigger>();
        _dicTriggers.Add(ZTriggerType.UnitTrigger, unitTriggerList);
        _dicTriggers.Add(ZTriggerType.NoneUnitTrigger, noneUnitTriggerList);
        _tempList1 = new List<ZBoxTrigger>();
        _tempList2 = new List<ZBoxTrigger>();
    }
    public void AddZTrigger(ZBoxTrigger zTrigger)
    {
            if (!_dicTriggers[zTrigger.triggerType].Contains(zTrigger))
            {
                _dicTriggers[zTrigger.triggerType].Add(zTrigger);
            }
    }
    public void RemoveZTrigger(ZBoxTrigger zTrigger)
    {
        if (_dicTriggers[zTrigger.triggerType].Contains(zTrigger))
        {
            _dicTriggers[zTrigger.triggerType].Remove(zTrigger);
        }
    }

    private List<ZBoxTrigger> _tempList1;
    private List<ZBoxTrigger> _tempList2;
    /// <summary>
    /// 返回org目标distance内的所有UnitTrigger类型的ZBoxTrigger：用于范围目标检查
    /// </summary>
    /// <param name="org"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public List<ZBoxTrigger> GetTriggersByDistance(ZBoxTrigger org,float distance)
    {
        _tempList1.Clear();
        List<ZBoxTrigger> triggers = _dicTriggers[ZTriggerType.UnitTrigger];
        for (int i = 0; i < triggers.Count; i++)
        {
          if(triggers[i]!= org && triggers[i].GetDistance(org) <= distance)
            {
                _tempList1.Add(triggers[i]);
            }
        }
        return _tempList1;
    }
    /// <summary>
    /// 返回产生碰撞的ZBoxtrigger,用于伤害技能检查
    /// </summary>
    /// <param name="nUTrigger"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public List<ZBoxTrigger> TriggerEnterByRange(ZBoxTrigger nUTrigger,float distance)
    {
        List<ZBoxTrigger> list = GetTriggersByDistance(nUTrigger, distance);
        _tempList2.Clear();
        for (int i = 0; i < list.Count; i++)
        {
           if(ZPhysics.CheckBox(list[i], nUTrigger))
            {
                _tempList2.Add(list[i]);
            }
        }
        return _tempList2;
    }
}
