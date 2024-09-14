using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private AchievementCard achievementCardPrefab;
    [SerializeField] private Transform achievementPanelContainer;
    [SerializeField] private Achievement[] achievements;


    private void Start()
    {
        LoadAchievementCard();
    }

    private void Update()
    {

    }

    private void LoadAchievementCard()
    {
        for (int i = 0; i < achievements.Length; i++)
        {
            AchievementCard card = Instantiate(achievementCardPrefab, achievementPanelContainer);
            card.SetupAchievement(achievements[i]);
        }
    }
}