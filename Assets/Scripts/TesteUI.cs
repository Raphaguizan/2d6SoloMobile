using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Game.Util;
using NaughtyAttributes;

public class TesteUI : MonoBehaviour
{
    [SerializeField]
    private TableBase testTable;
    [SerializeField]
    private TableBase testEventoInesperadoTable;

    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CallTable()
    {
        string myText = testTable.GetResult();
        if (myText.Contains('#'))
        {
            myText = myText.Replace("#", "");
            if(Utils.FiftyFifty())
                myText += ":\n\n" + testEventoInesperadoTable.GetResult();
        }
        textMeshProUGUI.text = myText;
    }

    [Button]
    public void Teste2Rolls()
    {
        Debug.Log(testTable.GetResult(4));
    }
}
