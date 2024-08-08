using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Game.Util;

public class SoundManager : Game.Util.Singleton<SoundManager>
{
    [SerializeField]
    private AudioMixer audioMixer;

    public static string SFXSaveName = "SFXVolume";
    public static string MusicSaveName = "MusicVolume";

    private void Start()
    {
        if (PlayerPrefs.HasKey(SFXSaveName))
        {
            VolumeSFX(PlayerPrefs.GetInt(SFXSaveName));
            VolumeMusic(PlayerPrefs.GetFloat(MusicSaveName));
        }
    }

    public static void VolumeSFX(int value)
    {
        Instance.audioMixer.SetFloat(SFXSaveName, Utils.Remap(value, 0, 1, -80, 0));
    }

    public static void VolumeMusic(float value)
    {
        Instance.audioMixer.SetFloat(MusicSaveName, Utils.Remap(value, 0, 1, -80, 0));
    }
}
