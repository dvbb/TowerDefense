using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFX : MonoBehaviour
{
    private void EnemyHit(Transform textSpawnPosition, float demage)
    {
        GameObject newInstance = DamageTextManager.Instance.pooler.GetInstanceFromPool();
        TextMeshProUGUI demageText = newInstance.GetComponent<UI_DamageText>().text;
        demageText.text = demage.ToString();

        //newInstance.transform.SetParent(textSpawnPosition);
        newInstance.transform.position = textSpawnPosition.position;
        newInstance.SetActive(true);
    }

    private void OnEnable()
    {
        Bullet.OnEnemyHit += EnemyHit;
    }

    private void OnDisable()
    {
        Bullet.OnEnemyHit -= EnemyHit;
    }
}
