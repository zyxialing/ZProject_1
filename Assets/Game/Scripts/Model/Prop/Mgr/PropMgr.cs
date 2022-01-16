using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropMgr : IPropMgr
{
    List<PropData> propDatas;
    public PropMgr()
    {
        propDatas = new List<PropData>();

    }
    public List<PropData> GetAllPropData()
    {
        return propDatas;
    }

    public PropData GetPropDataByIndex(int index)
    {
        if(propDatas.Count<= index)
        {
            return null;
        }
        else
        {
            return propDatas[index];
        }
    }
}
