using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using TMPro;

public class HintPopup : PopupBase
{
    [SerializeField]
    private TextMeshProUGUI subjectTMP;

    public override void InitializePopUp(TableBase newTable)
    {
        if (newTable != null)
        {
            List<TableBase> tableList = new();
            tableList.Add(newTable);
            InitializeHint(tableList);
        }
    }


    public void InitializeHint(List<TableBase> tablesToHint)
    {
        subjectTMP.text = GenerateHint(tablesToHint);
    }

    private string GenerateHint(List<TableBase> tablesToHint)
    {
        string myText = "";
        for (int i = 0; i < tablesToHint.Count; i++)
        {
            myText += "<b>" + tablesToHint[i].GetTitle() + ":</b>\n";
            myText += tablesToHint[i].Hint + "\n\n";
        }

        return myText;
    }
}
