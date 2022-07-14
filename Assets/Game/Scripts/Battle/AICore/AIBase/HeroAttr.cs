using System;
using System.Collections.Generic;
using Table;
using UnityEngine;

public class HeroAttr
{
    public int id;
    public int name;
    public int hp;
    public int maxHp;
    public float attackRange = 2f;
    public float attackFrequency = 1f;
    public float attackProgressBack;
    public bool criticalHitAnim;
    public int criticalHitProbability;

    public bool isEnterGame = false;

    public HeroAttr(excel_character character)
    {
        id = character.id;
        name = character.name;
        hp = character.hp;
        maxHp = character.hp;
        attackFrequency = character.attackFrequency;
        criticalHitAnim = character.criticalHitAnim;
        attackRange = character.attackRange;
        attackProgressBack = character.attackProgressBack;
        criticalHitProbability = 50;
    }

    public int GetId()
    {
        return id;
    }

    public string GetName()
    {
        return name.ToString();
    }

    public int GetHp()
    {
        return hp;
    }

    public float GetAttackRange()
    {
        return attackRange;
    }

    public float GetAttackInterval()
    {
        float attackInterval = 3 - attackFrequency;
        if (attackInterval < 0)
        {
            attackInterval = 0;
        }
        return attackInterval;
    }

    public float GetAttackSpeed()
    {
        float attackSpeed =  attackFrequency - 2;
        if (attackSpeed < 1)
        {
            attackSpeed = 1;
        }
        return attackSpeed;
    }

    public bool GetCriticalHitAnim()
    {
        return criticalHitAnim;
    }

    public int GetCriticalHitProbability()
    {
        return criticalHitProbability;
    }

    public float GetAttackProgressBack()
    {
        return attackProgressBack;
    }

    public bool SetHp(int hurt)
    {
        hp += hurt;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        if (hp < 0)
        {
            hp = 0;
        }
        return hp == 0;
    }
}