using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PropData
{
    public int count;
    public List<StaticProp> staticProps;
    public List<DynamicProp> dynamicProps;
    public PropData(int count = 0)
    {
        this.count = count;
    }
}

public class StaticProp
{

}

public class DynamicProp
{

}