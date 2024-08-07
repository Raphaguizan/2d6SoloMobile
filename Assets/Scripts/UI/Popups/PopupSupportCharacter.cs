using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupSupportCharacter : PopupBase
{
    // Criação básica
    [Header("Tabelas")]
    [SerializeField]
    private TableBase genderTable;
    [SerializeField]
    private TableBase ageTable;
    [SerializeField]
    private TableBase commonRaceTable;
    [SerializeField]
    private TableBase exoticRaceTable;
    [SerializeField]
    private TableBase personalityTable;
    
    // Classe social
    [SerializeField]
    private TableBase pourSocialClassTable;
    [SerializeField]
    private TableBase mediumSocialClassTable;
    [SerializeField]
    private TableBase richSocialClassTable;

    // Aparência
    [SerializeField]
    private TableBase faceTable;
    [SerializeField]
    private TableBase eyesTable;
    [SerializeField]
    private TableBase noseTable;
    [SerializeField]
    private TableBase bodyTable;
    [SerializeField]
    private TableBase hairTable;
    [SerializeField]
    private TableBase colorsTable;

    // Nome
    [SerializeField]
    private TableBase namesTable;

    //// TextFields
    [Header("TextFields")]
    [SerializeField]
    private TextMeshProUGUI genderField;

    [SerializeField]
    private TextMeshProUGUI ageField;

    [SerializeField]
    private TextMeshProUGUI raceField;

    [SerializeField]
    private TextMeshProUGUI personalityField;

    [SerializeField]
    private TextMeshProUGUI socialClassField;
    [SerializeField]
    private TMP_Dropdown socialClassDropDown;

    [SerializeField]
    private TextMeshProUGUI faceField;

    [SerializeField]
    private TextMeshProUGUI eyesField;

    [SerializeField]
    private TextMeshProUGUI noseField;

    [SerializeField]
    private TextMeshProUGUI bodyField;

    [SerializeField]
    private TextMeshProUGUI hairField;

    [SerializeField]
    private TextMeshProUGUI colorsField;

    [SerializeField]
    private TextMeshProUGUI nameField;


    private Dictionary<int, string> socialClassDic = new();

    private void Start()
    {
        socialClassDropDown.onValueChanged.AddListener(AdjustSocialDropDown);
    }

    public override void InitializePopUp(TableBase newTable)
    {
        nameField.text = namesTable.GetResult();
        genderField.text = genderTable.GetResult();
        ageField.text = ageTable.GetResult();
        raceField.text = CalculateRace();
        personalityField.text = personalityTable.GetResult();
        faceField.text = faceTable.GetResult();
        eyesField.text = eyesTable.GetResult();
        noseField.text = noseTable.GetResult();
        bodyField.text = bodyTable.GetResult();
        hairField.text = hairTable.GetResult();
        colorsField.text = colorsTable.GetResult();

        InitializeSocialClass();
    }

    private string CalculateRace()
    {
        string resp = commonRaceTable.GetResult();
        if (resp.Contains('@'))
        {
            resp = exoticRaceTable.GetResult();
        }
        return resp;
    }

    private void InitializeSocialClass()
    {
        socialClassDic.Add(0, pourSocialClassTable.GetResult());
        socialClassDic.Add(1, mediumSocialClassTable.GetResult());
        socialClassDic.Add(2, richSocialClassTable.GetResult());

        AdjustSocialDropDown(0);
    }

    private void AdjustSocialDropDown(int index)
    {
        socialClassField.text = socialClassDic[index];
    }

    private void OnDestroy()
    {
        socialClassDropDown.onValueChanged.RemoveListener(AdjustSocialDropDown);
    }
}
