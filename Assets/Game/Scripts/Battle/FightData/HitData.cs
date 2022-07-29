using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitData 
{
    /// <summary>
    /// 伤害负为受伤，正为回复，0为miss
    /// </summary>
    public int hurt = 0;
    /// <summary>
    /// 是否是暴击
    /// </summary>
    public bool isCriticalHit = false;
    /// <summary>
    /// 是否眩晕
    /// </summary>
    /// <param name="hurt"></param>
    public bool isDizzy = false;

    public HitData(int hurt)
    {
        this.hurt = hurt;
        this.isCriticalHit = false;
        this.isDizzy = false;
    }
}
