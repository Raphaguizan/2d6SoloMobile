using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;
using NaughtyAttributes;

public class PagesManager : Singleton<PagesManager>
{
    [SerializeField]
    private GameObject homePage;

    private Stack<GameObject> pagesStack = new();

    private void Start()
    {
        OpenPage(homePage);
    }


    public static void OpenPage(GameObject page)
    {
        if(Instance.pagesStack.Count > 0)
            Instance.pagesStack.Peek().SetActive(false);

        page.SetActive(true);
        Instance.pagesStack.Push(page);
    }

    public static void ReturnPage()
    {
        Instance.pagesStack.Pop().SetActive(false);
        Instance.pagesStack.Peek().SetActive(true);
    }
}
