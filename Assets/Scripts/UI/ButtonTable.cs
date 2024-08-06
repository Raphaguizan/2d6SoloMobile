using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTable : MonoBehaviour
{
    [SerializeField]
    private TableBase table;
    [SerializeField]
    private PopupType typeToOpen;

    private PopupBase mypopup;
    public void OpenPopup()
    {
        mypopup = PopupManager.OpenPopUp(typeToOpen);
        mypopup.InitializePopUp(table);
    }
}
