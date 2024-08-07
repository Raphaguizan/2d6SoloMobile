using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPages : MonoBehaviour
{
    [SerializeField]
    private GameObject pageGameObject;


    public void OpenPage()
    {
        PagesManager.OpenPage(pageGameObject);
    }

    public void BackPage()
    {
        PagesManager.ReturnPage();
    }
}
