using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _value;

    public event Action<int> ScoreChanged;

    public void Add()
    {
        _value++;
        ScoreChanged?.Invoke(_value);
    }

    public void Reset()
    {
        _value = 0;
        ScoreChanged?.Invoke(_value);
    }
}
