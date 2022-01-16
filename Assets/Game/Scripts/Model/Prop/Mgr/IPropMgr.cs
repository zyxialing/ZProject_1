using System.Collections;
using System.Collections.Generic;

public interface IPropMgr
{
    List<PropData> GetAllPropData();

    PropData GetPropDataByIndex(int index);

}

