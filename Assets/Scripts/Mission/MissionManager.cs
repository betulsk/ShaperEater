using System;
using System.Collections.Generic;
using UnityEngine;

public struct CurrenctMission
{
    [SerializeField] public ECollectibleType TargetCollectibleType;
    [SerializeField] public int TargetCount;
    [SerializeField] public Sprite MissionImage;
    [SerializeField] public Color MissionColor;
}

public class MissionManager : Singleton<MissionManager>
{
    private List<MissionData> _missions;
    private int _count;

    public CurrenctMission CurrentMission;
    public Action OnMissionSelected;

    private void Awake()
    {
        InventoryController.OnDataUpdated += OnDataUpdated;
        _missions = new List<MissionData>();
        _missions = GameConfigManager.Instance.GameConfig.MissionDatas;
        ChooseMission();
    }

    private void OnDestroy()
    {
        InventoryController.OnDataUpdated -= OnDataUpdated;
    }

    private void ChooseMission()
    {
        CurrentMission = new CurrenctMission();
        CurrentMission.TargetCollectibleType = _missions[_count].TargetCollectible;
        CurrentMission.TargetCount = _missions[_count].TargetCount;
        CurrentMission.MissionImage = _missions[_count].MissionImage;
        CurrentMission.MissionColor = _missions[_count].MissionColor;
        OnMissionSelected?.Invoke();
    }

    private void OnDataUpdated(ECollectibleType collectibleType, int collectedCollectibleCount)
    {
        if (collectibleType == CurrentMission.TargetCollectibleType && collectedCollectibleCount >= CurrentMission.TargetCount)
        {
            _count++;
            ChooseMission();
        }
    }
}
