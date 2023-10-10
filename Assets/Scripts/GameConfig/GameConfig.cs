using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig",
    menuName = "GameConfig/Create a Game Config",
    order = 1)]
public class GameConfig : ScriptableObject
{
    [SerializeField] public List<MissionData> MissionDatas;
}

[Serializable]
public struct MissionData
{
    [SerializeField] public ECollectibleType TargetCollectible;
    [SerializeField] public int TargetCount;
    [SerializeField] public Sprite MissionImage;
    [SerializeField] public Color MissionColor;
}
