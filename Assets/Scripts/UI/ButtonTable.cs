using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTable : MonoBehaviour
{
    [SerializeField]
    private TableBase table;

    private PopupBase mypopup;
    public void OpenPopup()
    {
        mypopup = PopupManager.OpenPopUp(typeof(PopupBase));
        mypopup.InitializePopUp(table);
    }
}
