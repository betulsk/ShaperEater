using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Dictionary<ETriggerObject, ECollectibleType> _triggerObjTypeToCollectibleType;

    [SerializeField] private VisualController _visualController;

    public VisualController VisualController => _visualController;

    [SerializeField] private List<ECollectibleType> _visualTypes;
    [SerializeField] private List<ETriggerObject> _triggerObjTypes;
    public Dictionary<ETriggerObject, ECollectibleType> TriggerObjTypeToCollectibleType => _triggerObjTypeToCollectibleType;

    private void Awake()
    {
        SetTriggerObjToCollectibleDic();
    }

    private void SetTriggerObjToCollectibleDic()
    {
        _triggerObjTypeToCollectibleType = new Dictionary<ETriggerObject, ECollectibleType>();
        for (int i = 0; i < _visualTypes.Count; i++)
        {
            _triggerObjTypeToCollectibleType.Add(_triggerObjTypes[i], _visualTypes[i]);
        }
    }

    public ECollectibleType GetCollectibleType(ETriggerObject triggerObj)
    {
        return _triggerObjTypeToCollectibleType[triggerObj];
    }

}
