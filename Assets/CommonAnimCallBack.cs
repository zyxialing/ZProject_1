using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonAnimCallBack : MonoBehaviour
{
    private animCallBack animAttack1;
    private animCallBack animAttack2;
    private animCallBack animDead;
    private animCallBack animBirth;

    public delegate void animCallBack();

    public void SetCallBack(string name, animCallBack callback)
    {
        switch (name)
        {
            case Const_BattleAnim_Name.anim_attack1:
                animAttack1 = callback;
                break;
            case Const_BattleAnim_Name.anim_attack2:
                animAttack2 = callback;
                break;
            case Const_BattleAnim_Name.anim_dead:
                animDead = callback;
                break;
            case Const_BattleAnim_Name.anim_birth:
                animBirth = callback;
                break;
        }
    }
    #region 动画回调
    public void anim_attack1CallBack()
    {
        animAttack1?.Invoke();
    }

    public void anim_attack2CallBack()
    {
        animAttack2?.Invoke();
    }

    public void anim_deadCallBack()
    {
        animDead?.Invoke();
    }
    public void anim_birthCallBack()
    {
        animBirth?.Invoke();
    }
    #endregion
}
