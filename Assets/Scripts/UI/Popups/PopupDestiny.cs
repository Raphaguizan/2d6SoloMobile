using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Game.Util;

public class PopupDestiny : PopupBase
{
    [SerializeField]
    private TableBase unexpectedEvents;
    [SerializeField]
    private TableBase interventionsEvents;
    public override void InitializePopUp(TableBase newTable = null)
    {
        base.InitializePopUp(newTable);

        string myText = myTable.GetResult();
        if (myText.Contains('@'))
        {
            myText = myText.Replace("@", "");
            if (Utils.FiftyFifty())
                if(Utils.FiftyFifty())
                    myText += ":\n\nEVENTO INESPERADO\n" + unexpectedEvents.GetResult();
                else
                    myText += ":\n\nINTERVENÇÃO INESPERADA\n" + interventionsEvents.GetResult();
        }
        contentText.text = myText;
    }
}
