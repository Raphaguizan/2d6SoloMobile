using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITable
{
    public string GetResult();
    public string GetResult(int index);
    public string RollMinorTable(int index = -1);
}
