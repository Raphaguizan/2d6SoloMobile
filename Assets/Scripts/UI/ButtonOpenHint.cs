using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOpenHint : MonoBehaviour
{

    [SerializeField]
    private List<TableBase> tables;

    public void SetHint(List<TableBase> tables)
    {
        this.tables = tables;
    }

    public void OpenHint()
    {
        GameObject hintGO = PopupManager.OpenPopUp(PopupType.Hint).gameObject;
        PagesManager.PlayPageSound();
        hintGO.GetComponent<HintPopup>()?.InitializeHint(tables);
    }
}
