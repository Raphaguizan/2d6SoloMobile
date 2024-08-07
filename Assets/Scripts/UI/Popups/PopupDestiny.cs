using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Game.Util;

public class PopupDestiny : PopupBase
{
    [SerializeField]
    private TableBase unexpectedEvents;
    public override void InitializePopUp(TableBase newTable = null)
    {
        base.InitializePopUp(newTable);

        string myText = myTable.GetResult();
        if (myText.Contains('&'))
        {
            myText = myText.Replace("&", "");
            if (Utils.FiftyFifty())
                myText += ":\n\nEVENTO INESPERADO\n" + unexpectedEvents.GetResult();
        }
        contentText.text = myText;
    }
}
