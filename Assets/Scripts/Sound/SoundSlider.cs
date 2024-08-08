using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSlider : SliderConfig
{

    private void Awake()
    {
        saveName = SoundManager.MusicSaveName;
    }
    protected override void Action(float val)
    {
        base.Action(val);
        SoundManager.VolumeMusic(val);
    }
}
