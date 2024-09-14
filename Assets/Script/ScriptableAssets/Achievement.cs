using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Achievement")]
public class Achievement : ScriptableObject
{
    public string Id;
    public string Title;
    public int ProgressToUnlock;
    public int GoldReward;
    public Sprite Sprite;
}
