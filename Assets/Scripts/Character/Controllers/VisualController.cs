using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VisualController : MonoBehaviour
{
    private Dictionary<ECollectibleType, GameObject> _collectibleTypeToVisualGO;
    private Dictionary<ETriggerObject, ECollectibleType> _triggerObjTypeToCollectibleType;
    private GameObject _currentVisual;
    [SerializeField] private Transform _visualsParentTransform;
    [SerializeField] private ECollectibleType _initVisualType;
    [SerializeField] private List<ECollectibleType> _visualTypes;
    [SerializeField] private List<ETriggerObject> _triggerObjTypes;

    private void Awake()
    {
        GetVisuals();
        SetDictionary();
        TryChangeVisual(ETriggerObject.Circle_Collectible);
    }

    private void GetVisuals()
    {
        var collectibleList = Enum.GetValues(typeof(ECollectibleType)).Cast<ECollectibleType>().ToList();
        int count = 1;
        _collectibleTypeToVisualGO = new Dictionary<ECollectibleType, GameObject>();
        foreach (Transform visualTransform in _visualsParentTransform)
        {
            _collectibleTypeToVisualGO.Add(collectibleList[count], visualTransform.gameObject);
            count++;
        }
    }

    private void SetDictionary()
    {
        _triggerObjTypeToCollectibleType = new Dictionary<ETriggerObject, ECollectibleType>();
        for (int i = 0; i < _visualTypes.Count; i++)
        {
            _triggerObjTypeToCollectibleType.Add(_triggerObjTypes[i], _visualTypes[i]);
        }
    }

    public void TryChangeVisual(ETriggerObject triggerObjType)
    {
        ECollectibleType collectibleType = _triggerObjTypeToCollectibleType[triggerObjType];
        if (_currentVisual != null)
        {
            _currentVisual.SetActive(false);
        }
        _collectibleTypeToVisualGO[collectibleType].SetActive(true);
        _currentVisual = _collectibleTypeToVisualGO[collectibleType];
    }
}
