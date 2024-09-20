using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SEs
{
    bow,
    magic
}

public class SeManager : UnitySingleton<SeManager>
{
    [SerializeField] private AudioClip se_bow_hit;
    [SerializeField] private AudioClip se_magic_hit;

    private AudioSource audioPlayer;
    private string SE_VOLUME_SAVE_KEY = "SE_VOLUME";

    protected override void Awake()
    {
        base.Awake();
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.volume = LoadSeValue();
    }

    private void Update()
    {
    }

    public void SaveSeValue(float value)
    {
        audioPlayer.volume = value;
        PlayerPrefs.SetFloat(SE_VOLUME_SAVE_KEY, value);
    }

    public float LoadSeValue()
    {
        return PlayerPrefs.GetFloat(SE_VOLUME_SAVE_KEY);
    }

    public void EnemyHitted(SEs ses)
    {
        switch (ses)
        {
            case SEs.bow:
                audioPlayer.PlayOneShot(se_bow_hit);
                break;
            case SEs.magic:
                audioPlayer.PlayOneShot(se_magic_hit);
                break;
            default:
                break;
        }
    }
}
