using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonsterPopup : PopupBase
{
    [SerializeField]
    private TableBase bodyTable;
    [SerializeField]
    private TableBase headTable;
    [SerializeField]
    private TableBase locomotionTable;
    [SerializeField]
    private TableBase apendiceTable;
    [SerializeField]
    private TableBase attackTable;
    [SerializeField]
    private TableBase defenceTable;
    [SerializeField]
    private TableBase inteligenceTable;
    [SerializeField]
    private TableBase treatsTable;
    [SerializeField]
    private TableBase powersTable;

    [SerializeField]
    private TextMeshProUGUI bodyField;
    [SerializeField]
    private TextMeshProUGUI headField;
    [SerializeField]
    private TextMeshProUGUI locomotionField;
    [SerializeField]
    private TextMeshProUGUI apendiceField;
    [SerializeField]
    private TextMeshProUGUI attackField;
    [SerializeField]
    private TextMeshProUGUI defenceField;
    [SerializeField]
    private TextMeshProUGUI inteligenceField;
    [SerializeField]
    private TextMeshProUGUI treatsField;
    [SerializeField]
    private TextMeshProUGUI powersField;

    public override void InitializePopUp(TableBase newTable)
    {
        bodyField.text = bodyTable.GetResult();
        headField.text = headTable.GetResult();
        locomotionField.text = locomotionTable.GetResult();
        apendiceField.text = apendiceTable.GetResult();
        attackField.text = attackTable.GetResult();
        defenceField.text = defenceTable.GetResult();
        inteligenceField.text = inteligenceTable.GetResult();
        treatsField.text = treatsTable.GetResult();
        powersField.text = powersTable.GetResult();
    }
}
