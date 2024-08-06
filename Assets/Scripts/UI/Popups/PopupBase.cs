using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupBase : MonoBehaviour
{
    [SerializeField]
    protected TableBase myTable;
    [SerializeField]
    protected PopupType myType;
    [SerializeField]
    protected TextMeshProUGUI titleText;
    [SerializeField]
    protected TextMeshProUGUI contentText;


    public PopupType MyType => myType;
    public virtual void InitializePopUp(TableBase newTable)
    {
        if (newTable == null)
            return;

        myTable = newTable;

        titleText.text = newTable.GetTitle();
    }

    public virtual void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}
