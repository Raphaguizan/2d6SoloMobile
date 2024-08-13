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
        string result = $"\t<b>{GetTitle()}</b>\n\n";

        int step = 1;
        int currentIndex = 1;
        
        if (Count() > 6)
        {
            step = 36 / Count();
            currentIndex = 11;
        }
        int stepNum = step - 1;

        for (int i = 0; i < Count(); i++) 
        {
            result += "<b>" + currentIndex + (step > 1 ? " - "+(currentIndex+ stepNum) : "" ) + "</b> - ";
            result += myTable.GetResult(i)+"\n";

            if (currentIndex % 10 == 6 - stepNum)
                currentIndex += 5 + stepNum;
            else
                currentIndex += step;
        }

        return result;
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
