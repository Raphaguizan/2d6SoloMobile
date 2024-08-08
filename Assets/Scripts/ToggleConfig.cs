using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleConfig : MonoBehaviour
{
    [SerializeField]
    protected Toggle myToggle;

    [SerializeField]
    protected string saveName = "Save";

    private void OnEnable()
    {
        if(PlayerPrefs.HasKey(saveName))
            myToggle.isOn = PlayerPrefs.GetInt(saveName) == 1;
        myToggle.onValueChanged.AddListener(Action);
    }

    protected virtual void Action(bool val)
    {
        PlayerPrefs.SetInt(saveName, val?1:0);
    }

    private void OnDisable()
    {
        myToggle.onValueChanged.RemoveListener(Action);
    }
}
