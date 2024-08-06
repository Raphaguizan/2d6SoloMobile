using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSucessAndFail : PopupBase
{
    [SerializeField, Expandable]
    private TableBase NegativeConsequences;
    [SerializeField]
    private ScrollRect scrowView;
    public override void InitializePopUp(TableBase newTable)
    {
        base.InitializePopUp(newTable);

        string myText = myTable.GetResult();
        int consequenceQty = 0;

        if (myText.Contains("Sucesso Parcial!"))
            consequenceQty = 1;
        else if (myText.Contains("Falha!"))
            consequenceQty = 2;
        else if (myText.Contains("Falha Crítica!"))
            consequenceQty = 3;

        contentText.text = myText + NegativeString(consequenceQty);
        scrowView.verticalNormalizedPosition = 1;
    }

    private string NegativeString(int qty)
    {
        if (qty == 0)
            return "";

        string resp = "\n\nCONSEQUÊNCIAS NEGATIVAS\n\n";
        List<int> listIndex = new();
        for (int i = 0; i < qty; i++)
        {
            int index = -1;
            do
            {
                index = Random.Range(0, NegativeConsequences.Count());
            } while (listIndex.Contains(index));
            listIndex.Add(index);
            resp += (i+1)+" - "+NegativeConsequences.GetResult(index)+"\n\n";
        }
        return resp;
    }
}
