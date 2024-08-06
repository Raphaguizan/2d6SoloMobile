using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupSimpleList : PopupBase
{
    public override void InitializePopUp(TableBase newTable = null)
    {
        base.InitializePopUp(newTable);

        contentText.text = newTable.GetResult();
    }
}
