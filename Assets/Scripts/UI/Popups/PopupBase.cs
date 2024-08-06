using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupBase : MonoBehaviour
{
    [SerializeField]
    protected TableBase myTable;
    [SerializeField]
    protected TextMeshProUGUI titleText;
    [SerializeField]
    protected TextMeshProUGUI contentText;

    public virtual void InitializePopUp(TableBase newTable)
    {
        if (newTable == null)
            return;

        myTable = newTable;

        titleText.text = newTable.GetTitle();
    }

    public void ClosePopup()
    {
        gameObject.SetActive(false);
    }
}
