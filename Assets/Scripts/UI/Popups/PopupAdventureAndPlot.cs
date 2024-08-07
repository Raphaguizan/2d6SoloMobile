using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupAdventureAndPlot : PopupBase
{
    [SerializeField]
    private ScrollRect scrowView;
    public override void InitializePopUp(TableBase newTable)
    {
        base.InitializePopUp(newTable);

        (myTable as TableDouble).SetConnectionWord("Reviravolta");
        string myText = myTable.GetResult();
        contentText.text = myText;
        scrowView.verticalNormalizedPosition = 1;
    }
}
