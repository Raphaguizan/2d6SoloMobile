using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Tables/Simple", fileName ="NewTable")]
public class TableSimple : TableBase
{
    [SerializeField]
    private Table myTable;

    public override string GetResult()
    {
        return myTable.GetResult();
    }
    public override string GetResult(int index)
    {
        return myTable.GetResult(index);
    }

    public override string RollMinorTable(int index = -1)
    {
        return GetResult();
    }

    #region update objectName
    protected override void Reset()
    {
        lastTitleName = this.name;
        myTable.SetNewTitle(lastTitleName);
    }
    protected override void OnValidate()
    {
        if (!lastTitleName.Equals(myTable.Title))
        {
            lastTitleName = this.name;
            myTable.SetNewTitle(lastTitleName);
        }
    }
    #endregion
}
