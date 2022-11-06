using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    [SerializeField] private ChipChecker[] chipCheckers;

    private const int ConstChipAmount = 15;
    private int _tempAmount;

    public void CheckCountChip()
    {
        _tempAmount = 0;
        foreach(ChipChecker item in chipCheckers)
        {
            _tempAmount += item.ChipCheck();
        }
        if (ConstChipAmount == _tempAmount)
        {
            Win();
        }
    }

    private void Win()
    {
        Application.Quit();
    }
}
