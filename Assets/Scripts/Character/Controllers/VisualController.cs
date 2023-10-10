using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VisualController : MonoBehaviour
{
    private Dictionary<ECollectibleType, GameObject> _collectibleTypeToVisualGO;
    private GameObject _currentVisual;

    [SerializeField] private Character _character;
    [SerializeField] private Transform _visualsParentTransform;

    private void Awake()
    {
        GetVisuals();
    }

    private void Start()
    {
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

    public void TryChangeVisual(ETriggerObject triggerObjType)
    {
        ECollectibleType collectibleType = _character.GetCollectibleType(triggerObjType);

        if (_currentVisual != null)
        {
            _currentVisual.SetActive(false);
        }
        _collectibleTypeToVisualGO[collectibleType].SetActive(true);
        _currentVisual = _collectibleTypeToVisualGO[collectibleType];
    }
}
