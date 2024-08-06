using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Table
{
    [SerializeField]
    private string title = "";
    [SerializeField]
    private List<string> results = new();
    
    public string Title => title;
    public int Count => results.Count;

    public void SetNewTitle(string newTitle)
    {
        title = newTitle;
    }

    public string GetResult()
    {
        return GetResult(Random.Range(0, results.Count));
    }

    public string GetResult(int index)
    {
        return results[index];
    }
}
