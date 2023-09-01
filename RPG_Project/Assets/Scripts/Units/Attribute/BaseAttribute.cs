using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttribute
{
    private int _baseValue;
    private float _baseMultiplier;

    public BaseAttribute(int value, float multiplier = 0)
    {
        _baseValue = value;
        _baseMultiplier = multiplier;
    }

    public float BaseMultiplier { get => _baseMultiplier;}
    public int BaseValue { get => _baseValue;}
}
