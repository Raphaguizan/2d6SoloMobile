using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderConfig : MonoBehaviour
{
    [SerializeField]
    protected Slider mySlider;

    [SerializeField]
    protected string saveName = "Save";

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey(saveName))
            mySlider.value = PlayerPrefs.GetFloat(saveName);
        mySlider.onValueChanged.AddListener(Action);
    }

    protected virtual void Action(float val)
    {
        PlayerPrefs.SetFloat(saveName, val);
    }

    private void OnDisable()
    {
        mySlider.onValueChanged.RemoveListener(Action);
    }
}
