using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    public static BgmManager Instance;

    private AudioSource bgmPlayer;
    private string BGM_VOLUME_SAVE_KEY = "BGM_VOLUME";

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        bgmPlayer = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
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
