using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfigManager : Singleton<GameConfigManager>
{
    [SerializeField] private GameConfig _gameConfig;

    public GameConfig GameConfig => _gameConfig;

    public int GetTotalMissionCount()
    {
        return GameConfig.MissionDatas.Count;
    }

    public MissionData GetMissionCount(ECollectibleType collectibleType)
    {
        foreach (var item in GameConfig.MissionDatas)
        {
            if (item.TargetCollectible == collectibleType)
            {
                return item;
            }
        }
        return new MissionData();
    }
}
