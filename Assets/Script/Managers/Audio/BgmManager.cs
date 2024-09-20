using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : UnitySingleton<BgmManager>
{
    private AudioSource bgmPlayer;
    private string BGM_VOLUME_SAVE_KEY = "BGM_VOLUME";

    protected override void Awake()
    {
        base.Awake();
        bgmPlayer = GetComponent<AudioSource>();
        bgmPlayer.volume = LoadBgmValue();
    }

    private void Update()
    {
    }

    public void SaveBgmValue(float value)
    {
        bgmPlayer.volume = value;
        PlayerPrefs.SetFloat(BGM_VOLUME_SAVE_KEY, value);
    }

    public float LoadBgmValue()
    {
        return PlayerPrefs.GetFloat(BGM_VOLUME_SAVE_KEY);
    }
}
