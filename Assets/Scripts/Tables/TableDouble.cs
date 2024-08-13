using System.Collections.Generic;
using System.Linq;
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

    private string connectionWord = "";

    public override int Count()
    {
        return myTables.Count;
    }

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

    public void SetConnectionWord(string newConnectionWord)
    {
        connectionWord = newConnectionWord;
    }

    public override string RollMinorTable(int index = -1)
    {
        return myTables[lastTableIndex].Title + (connectionWord.Length > 0 ?"\n\n":"") + connectionWord + ":\n\n" + MinorTableResult(index);
    }

    private string MinorTableResult(int index = -1)
    {
        if(index == -1)
            return myTables[lastTableIndex].GetResult();
        return myTables[lastTableIndex].GetResult(index);
    }

    public override string ToString()
    {
        string result = $"\t<b>{GetTitle()}</b>\n\n";

        for (int i = 0; i < myTables.Count; i++)
        {
            result += myTables[i].ToString()+"\n";
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
