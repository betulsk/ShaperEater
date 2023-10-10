using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : Singleton<MissionManager>
{
    [SerializeField] private MissionUIWidget _missionUIWidget;
    private void Awake()
    {
        InventoryController.OnDataUpdated += OnDataUpdated;
    }

    private void OnDestroy()
    {
        InventoryController.OnDataUpdated -= OnDataUpdated;
    }

    private void OnDataUpdated(ECollectibleType collectibleType, int collectedCollectibleCount)
    {
        
    }
}
