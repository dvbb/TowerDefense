using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextManager : MonoBehaviour
{
    public ObjectPooler pooler { get; private set; }
    public static DamageTextManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    private void Start()
    {
        pooler = GetComponent<ObjectPooler>();
    }
}
