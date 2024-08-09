using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;

public class PopupBase : MonoBehaviour
{
    [SerializeField, Expandable]
    protected TableBase myTable;
    [SerializeField]
    protected PopupType myType;
    [SerializeField]
    protected TextMeshProUGUI titleText;
    [SerializeField]
    protected TextMeshProUGUI contentText;

    [Header("Hint")]
    [SerializeField]
    protected ButtonOpenHint hintPopupButton;
    [SerializeField]
    protected List<TableBase> hintTables;


    public PopupType MyType => myType;
    public virtual void InitializePopUp(TableBase newTable)
    {
        if (newTable == null)
            return;

        myTable = newTable;

        titleText.text = myTable.GetTitle();

        if(hintTables.Count == 0)
            hintTables.Add(newTable);

        InitializeHint();
    }

    private void OnEnable()
    {
        InitializeHint();
    }

    protected virtual void InitializeHint()
    {
        if (hintTables.Count > 0)
            hintPopupButton?.SetHint(hintTables);
    }

    public virtual void ClosePopup()
    {
        hintTables.Clear();
        gameObject.SetActive(false);
        PopupManager.PlayCloseSound();
    }
}
