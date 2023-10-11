using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private Dictionary<ECollectibleType, int> _collectibleTypeToCount;

    [SerializeField] private Character _character;

    public static Action<ECollectibleType, int> OnDataUpdated;

    private void Awake()
    {
        _collectibleTypeToCount = new Dictionary<ECollectibleType, int>();
        var collectibleList = Enum.GetValues(typeof(ECollectibleType)).Cast<ECollectibleType>().ToArray();

        foreach (var item in collectibleList)
        {
            _collectibleTypeToCount.Add(item, 0);
        }
    }

    public void SaveCollectibles(ETriggerObject triggerObjType)
    {
        ECollectibleType collectibleType = _character.GetCollectibleType(triggerObjType);
        if (MissionManager.Instance.CurrentMission.TargetCollectibleType == collectibleType)
        {
            _collectibleTypeToCount[collectibleType]++;
            OnDataUpdated?.Invoke(collectibleType, _collectibleTypeToCount[collectibleType]);
        }
    }
}
