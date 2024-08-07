using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonTable : MonoBehaviour
{
    [SerializeField]
    private TableBase table;
    [SerializeField]
    private PopupType typeToOpen;
    [SerializeField]
    private TextMeshProUGUI myText;

    private PopupBase mypopup;

    private void Start()
    {
        UpdateTitle();
    }

    public void OpenPopup()
    {
        mypopup = PopupManager.OpenPopUp(typeToOpen);
        mypopup.InitializePopUp(table);
    }

    public void ButtonSetup(TableBase newTable, PopupType newType = PopupType.Simple)
    {
        table = newTable;
        typeToOpen = newType;
        UpdateTitle();
    }

    private void UpdateTitle()
    {
        if (table != null)
            myText.text = table?.GetTitle();
    }
}
