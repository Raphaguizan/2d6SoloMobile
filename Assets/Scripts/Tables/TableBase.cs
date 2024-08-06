using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBase : ScriptableObject, ITable
{
    [SerializeField]
    protected string hint;

    public string Hint => hint;

    public virtual string GetTitle()
    {
        return "";
    }

    public virtual string GetResult()
    {
        return "";
    }
    public virtual string GetResult(int index)
    {
        return "";
    }
    public virtual string RollMinorTable(int index = -1)
    {
        return GetResult();
    }

    #region update objectName
    protected string lastTitleName = "";
    protected virtual void Reset()
    {
        lastTitleName = this.name;
    }
    protected virtual void OnValidate()
    {
        lastTitleName = this.name;
    }
    #endregion
}
