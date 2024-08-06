using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tables/Double", fileName = "NewDoubleTable")]
public class TableDouble : TableBase
{
    [SerializeField]
    private string tableTitle = "";
    [SerializeField]
    private List<Table> myTables = new();

    private int lastTableIndex = 0;

    public string TableTitle => tableTitle;

    public override string GetTitle()
    {
        return tableTitle;
    }

    public override string GetResult()
    {
        return GetResult(Random.Range(0, myTables.Count));
    }

    public override string GetResult(int index)
    {
        lastTableIndex = index;
        return RollMinorTable();
    }

    public override string RollMinorTable(int index = -1)
    {
        return myTables[lastTableIndex].Title + ": \n" + MinorTableResult(index);
    }

    private string MinorTableResult(int index = -1)
    {
        if(index == -1)
            return myTables[lastTableIndex].GetResult();
        return myTables[lastTableIndex].GetResult(index);
    }

    #region update objectName
    protected override void Reset()
    {
        lastTitleName = this.name;
        tableTitle = lastTitleName;
    }
    protected override void OnValidate()
    {
        if (!lastTitleName.Equals(TableTitle))
        {
            lastTitleName = this.name;
            tableTitle = lastTitleName;
        }
    }
    #endregion
}
