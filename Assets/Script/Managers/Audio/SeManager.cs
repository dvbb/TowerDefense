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
    private AudioClip se_bow_hit;
    private AudioClip se_magic_hit;

    private AudioSource audioPlayer;
    private string SE_VOLUME_SAVE_KEY = "SE_VOLUME";

    protected override void Awake()
    {
        base.Awake();
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.volume = LoadSeValue();
        InitSEs();
    }

    private void InitSEs()
    {
        se_bow_hit = Resources.Load<AudioClip>("Audio/SEs/bow_hit");
        se_magic_hit = Resources.Load<AudioClip>("Audio/SEs/Magic_Hit");
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

    public void PlayEffect(string name, bool isLoop = false)
    {
        AudioClip clip = Resources.Load<AudioClip>("Audio/EFs/" + name);
        //audioSource.PlayOneShot(clip);
        AudioSource.PlayClipAtPoint(clip, transform.position);
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
