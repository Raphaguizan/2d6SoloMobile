using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupInjuries : PopupBase
{
    [SerializeField]
    private List<TableBase> injuries;
    [SerializeField]
    private Transform gridPivot;
    [SerializeField]
    private GameObject buttonPrefab;


    private List<GameObject> buttonsList = new();

    private void Start()
    {
        GenerateButtons();
    }

    public override void InitializePopUp(TableBase newTable = null)
    {
        if (newTable == null)
            return;

        myTable = newTable;
    }

    private void GenerateButtons()
    {
        for (int i = 0; i < injuries.Count; ++i)
        {
            GameObject newButton = Instantiate(buttonPrefab, gridPivot);
            newButton.GetComponent<ButtonTable>().ButtonSetup(injuries[i]);
        }
    }
}
