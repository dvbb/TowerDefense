using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : UnitySingleton<BgmManager>
{
    private AudioSource audioPlayer;
    private string BGM_VOLUME_SAVE_KEY = "BGM_VOLUME";

    protected override void Awake()
    {
        base.Awake();
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.volume = LoadBgmValue();
    }

    private void Update()
    {
    }

    public void PlayBgm(string name, bool isLoop = true)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/BGM/" + name);
        audioPlayer.clip = clip;
        audioPlayer.loop = isLoop;
        audioPlayer.Play();
    }

    public void SaveBgmValue(float value)
    {
        audioPlayer.volume = value;
        PlayerPrefs.SetFloat(BGM_VOLUME_SAVE_KEY, value);
    }

    public float LoadBgmValue()
    {
        return PlayerPrefs.GetFloat(BGM_VOLUME_SAVE_KEY);
    }
}
