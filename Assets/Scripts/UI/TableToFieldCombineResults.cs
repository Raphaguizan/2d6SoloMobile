using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableToFieldCombineResults : TableToField
{

    [SerializeField]
    private TableBase secondTable;

    [SerializeField]
    private string combineString = " ";

    protected override string GetResult()
    {
        return myTable.GetResult() + combineString + secondTable.GetResult();
    }
}
