using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SEs
{
    bow,
    magic
}

public class SeManager : MonoBehaviour
{
    public static SeManager Instance;

    [SerializeField] private AudioClip se_bow_hit;
    [SerializeField] private AudioClip se_magic_hit;

    private AudioSource audioPlayer;
    private string SE_VOLUME_SAVE_KEY = "SE_VOLUME";

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        audioPlayer = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
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
