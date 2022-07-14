using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitData 
{
    public int hurt = 0;
    public bool isCriticalHit = false;

    public HitData(int hurt)
    {
        this.hurt = hurt;
        this.isCriticalHit = false;
    }
}
