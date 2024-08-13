using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Game.Util;
using System.Linq;

public class HintPopup : PopupBase
{
    [SerializeField]
    private Transform contentTransform;
    [SerializeField]
    private ScrollRect scrollView;
    [SerializeField]
    private TextMeshProUGUI subjectTMP;

    private List<GameObject> auxsTextmesh = new();

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
        PlaceText(GenerateHint(tablesToHint));
        StartCoroutine(WaitToFit());
    }

    private IEnumerator WaitToFit()
    {
        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        contentTransform.GetComponent<ContentSizeFitter>().enabled = true;
        yield return new WaitForEndOfFrame();
        scrollView.verticalNormalizedPosition = 1f;
    }

    private void PlaceText(string text)
    {
        Debug.Log(text.Length);
        Debug.Log(text);
        int chunkSize = CalculateChunkSize(text);
        var myTexts = text.Split(chunkSize);
        Debug.Log("List Count: "+myTexts.Count);
        
        subjectTMP.text = myTexts[0];
        for (int i = 1; i < myTexts.Count; i++) 
        {
            GameObject newTMP = Instantiate(subjectTMP.gameObject, contentTransform);
            auxsTextmesh.Add(newTMP);
            newTMP.GetComponent<TextMeshProUGUI>().text = myTexts[i];
        }
        myTexts.Clear();
        contentTransform.GetComponent<ContentSizeFitter>().enabled=false;
    }

    private int CalculateChunkSize(string text)
    {
        int limit = 20500;
        if (text.Length > limit)
        {
            char currentChar = '#';
            limit++;
            while (currentChar != '\n')
            {
                limit--;
                currentChar = text[limit];
            }
        }
        return limit;
    }

    public override void ClosePopup()
    {
        for (int i = 0; i < auxsTextmesh.Count; i++)
        {
            Destroy(auxsTextmesh[i]);
        }
        auxsTextmesh.Clear();
        base.ClosePopup();
    }

    private string GenerateHint(List<TableBase> tablesToHint)
    {
        string myText = "";
        for (int i = 0; i < tablesToHint.Count; i++)
        {
            myText += "<b>" + tablesToHint[i].GetTitle() + ":</b>\n";
            myText += tablesToHint[i].Hint + "\n\n";
        }

        myText += "\n\t<u><b> Tabelas Completas </b></u>\n\n";
        for (int i = 0; i < tablesToHint.Count; i++)
        {
            myText += tablesToHint[i].ToString()+"\n";
        }

        return myText;
    }
}
