using System;
using System.Collections.Generic;
using Table;
using UnityEngine;

public class HeroAttr
{
    public int id;
    public int name;
    public int hp;
    public float attackRange = 2f;
    public float attackInterval = 2f;
    public float attackSpeed = 1f;

    public bool isEnterGame = false;

    public HeroAttr(excel_character character)
    {
        id = character.id;
        name = character.name;
        hp = character.hp;
        attackRange = character.attackRange;
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
        return attackInterval;
    }

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }
}