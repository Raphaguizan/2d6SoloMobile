using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;
using NaughtyAttributes;

public class PagesManager : Singleton<PagesManager>
{
    [SerializeField]
    private GameObject homePage;

    [Space, SerializeField]
    private AudioSource passPageSound;
    [SerializeField]
    private AudioSource backPageSound;

    private Stack<GameObject> pagesStack = new();

    private void Start()
    {
        OpenPage(homePage, false);
    }


    public static void OpenPage(GameObject page, bool sound = true)
    {
        if(Instance.pagesStack.Count > 0)
            Instance.pagesStack.Peek().SetActive(false);

        page.SetActive(true);
        Instance.pagesStack.Push(page);
        
        if(sound)
            Instance.passPageSound.Play();
    }

    public static void ReturnPage(bool sound = true)
    {
        Instance.pagesStack.Pop().SetActive(false);
        Instance.pagesStack.Peek().SetActive(true);

        if(sound)
            Instance.backPageSound.Play();
    }
}
