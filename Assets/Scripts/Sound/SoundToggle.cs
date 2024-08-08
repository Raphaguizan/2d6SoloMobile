using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToggle : ToggleConfig
{
    private void Awake()
    {
        saveName = SoundManager.SFXSaveName;
    }
    protected override void Action(bool val)
    {
        base.Action(val);
        SoundManager.VolumeSFX(val ? 1 : 0);
    }
}
