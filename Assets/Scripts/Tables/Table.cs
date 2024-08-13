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

    public override string ToString()
    {
        string result = $"\t<b>{title}</b>\n\n";

        int step = 1;
        int currentIndex = 1;

        if (Count > 6)
        {
            step = 36 / Count;
            currentIndex = 11;
        }
        int stepNum = step - 1;

        for (int i = 0; i < Count; i++)
        {
            result += "<b>" + currentIndex + (step > 1 ? " - " + (currentIndex + stepNum) : "") + "</b> - ";
            result += GetResult(i) + "\n";

            if (currentIndex % 10 == 6 - stepNum)
                currentIndex += 5 + stepNum;
            else
                currentIndex += step;
        }

        return result;
    }
}
