using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute : BaseAttribute
{
    private List<RawBonus> _rawBonusList;
    private List<FinalBonus> _finalBonusList;

    private int _finalValue;

    public Attribute(int startingValue) : base(startingValue)
    {
        _rawBonusList = new List<RawBonus>();
        _finalBonusList = new List<FinalBonus>();
        _finalValue = BaseValue;
    }

    public void AddRawBonus(RawBonus rawBonus)
    {
        _rawBonusList.Add(rawBonus);
    }

    public void AddFinalBonus(FinalBonus finalBonus)
    {
        _finalBonusList.Add(finalBonus);
    }

    public void RemoveRawBonus(RawBonus rawBonus)
    {
        int indexOfBonus = _rawBonusList.IndexOf(rawBonus);
        if (indexOfBonus >= 0)
        {
            var tempList = _rawBonusList.GetRange(indexOfBonus, 1);
            _rawBonusList.RemoveRange(indexOfBonus, 1);
        }
    }

    public void RemoveFinalBonus(FinalBonus finalBonus)
    {
        int indexOfBonus = _finalBonusList.IndexOf(finalBonus);
        if (indexOfBonus >= 0)
        {
            var tempList = _finalBonusList.GetRange(indexOfBonus, 1);
            _finalBonusList.RemoveRange(indexOfBonus, 1);
        }
    }

    public int CalculateValue()
    {
        _finalValue = BaseValue;

        int rawBonusValue = 0;
        float rawBonusMultiplier = 0;

        foreach(var rawBonus in _rawBonusList)
        {
            rawBonusValue += rawBonus.BaseValue;
            rawBonusMultiplier += rawBonus.BaseMultiplier;
        }

        _finalValue += rawBonusValue;
        _finalValue *= Mathf.RoundToInt(1f + rawBonusMultiplier);

        int finalBonusValue = 0;
        float finalBonusMultiplier = 0;

        foreach(var finalBonus in _finalBonusList)
        {
            finalBonusValue += finalBonus.BaseValue;
            finalBonusMultiplier += finalBonus.BaseMultiplier;
        }

        _finalValue += finalBonusValue;
        _finalValue *= Mathf.RoundToInt(1 + finalBonusMultiplier);

        return _finalValue;
    }

    public int FinalValue { get => CalculateValue();  }
}
