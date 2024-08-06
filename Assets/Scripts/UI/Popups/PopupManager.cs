using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PopupManager : Game.Util.Singleton<PopupManager>
{
    [SerializeField]
    private List<GameObject> popupsPrefabs = new();
    [SerializeField]
    private Transform popupContent;

    private List<GameObject> myPopups = new();

    public static PopupBase OpenPopUp(PopupType popupType)
    {

        GameObject popup = Instance.GetPopupObjByType(Instance.myPopups, popupType);
        if (popup == null)
            popup = Instance.InstantiatePopup(popupType);
        else
            popup.SetActive(true);

        return popup.GetComponent<PopupBase>();
    }

    private GameObject InstantiatePopup(PopupType popupType)
    {
        GameObject popup = GetPopupObjByType(popupsPrefabs, popupType);

        GameObject newPopup = Instantiate(popup, popupContent);
        myPopups.Add(newPopup);
        return newPopup;
    }

    private GameObject GetPopupObjByType(List<GameObject> list, PopupType popupType)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var myPopup = list[i].GetComponent<PopupBase>();
            if (myPopup.MyType == popupType)
                return list[i];
        }
        return null;
    }
}
