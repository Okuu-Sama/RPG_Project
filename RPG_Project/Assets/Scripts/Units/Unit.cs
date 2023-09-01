using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    // Unit type = Humanoid, Undead, ...
    protected string unitType;
    protected string unitElement;

    public string unitName;
    public int unitLevel;

    /*public UnitStat Strenght;
    public UnitStat Dexterity;
    public UnitStat Intelligence;
    public UnitStat Speed;
    public UnitStat Defence;*/

    public int maxHP;
    public int currentHP;
    public int defence;
    
}
