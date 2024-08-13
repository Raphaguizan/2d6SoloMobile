using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Tables/Simple", fileName ="NewTable")]
public class TableSimple : TableBase
{
    [SerializeField]
    private Table myTable;

    public override int Count()
    {
        return myTable.Count;
    }
    public override string GetTitle()
    {
        return myTable.Title;
    }

    public override string GetResult()
    {
        return ValidateOutPut(myTable.GetResult());
    }
    public override string GetResult(int index)
    {
        return ValidateOutPut(myTable.GetResult(index));
    }

    public override string RollMinorTable(int index = -1)
    {
        return GetResult();
    }

    private string ValidateOutPut(string enter, bool recursive = true)
    {
        if (!enter.Contains('#'))
        {
            return enter;
        }

        if (!recursive)
        {
            return ValidateOutPut(myTable.GetResult(), false);
        }

        string resp = "";
        resp += ValidateOutPut(myTable.GetResult(), false);
        resp += " (E) ";
        resp += ValidateOutPut(myTable.GetResult(), false);

        return resp;
    }

    public override string ToString()
    {
        return myTable.ToString();
    }

    [ContextMenu("Print")]
    public void Print()
    {
        Debug.Log(ToString());
    }

    #region update objectName
    protected override void Reset()
    {
        lastTitleName = this.name;
        //myTable.SetNewTitle(lastTitleName);
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
