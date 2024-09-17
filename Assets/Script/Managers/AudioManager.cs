using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SEs
{
    bow,
    magic
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioClip se_bow_hit;
    [SerializeField] private AudioClip se_magic_hit;

    private AudioSource audioPlayer;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        audioPlayer = GetComponent<AudioSource>();
    }

    private void Update()
    {
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
