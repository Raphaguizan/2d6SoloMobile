using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TableToField : MonoBehaviour
{
    [SerializeField]
    protected TableBase myTable;
    protected TextMeshProUGUI m_TextMeshProUGUI;


    private void Awake()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        m_TextMeshProUGUI.text = GetResult();
    }

    protected virtual string GetResult()
    {
        return myTable.GetResult();
    }
}
