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

    public static PopupBase OpenPopUp(Type popupType = null)
    {
        if (popupType == null)
            popupType = typeof(PopupBase);

        GameObject popup = Instance.GetPopupObjByType(Instance.myPopups, popupType);
        if (popup == null)
            popup = Instance.InstantiatePopup(popupType);
        else
            popup.SetActive(true);

        return popup.GetComponent<PopupBase>();
    }

    private GameObject InstantiatePopup(Type popupType = null)
    {
        Debug.Log(popupType);
        GameObject popup = null;
        if (popupType == null) 
            popup = GetPopupObjByType(popupsPrefabs, typeof(PopupBase));
        else
            popup = GetPopupObjByType(popupsPrefabs, popupType);


        GameObject newPopup = Instantiate(popup, popupContent);
        myPopups.Add(newPopup);
        return newPopup;
    }

    private GameObject GetPopupObjByType(List<GameObject> list, Type popupType)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var myPopup = list[i].GetComponent<PopupBase>();
            if (myPopup.GetType() == popupType)
                return list[i];
        }
        return null;
    }
}
