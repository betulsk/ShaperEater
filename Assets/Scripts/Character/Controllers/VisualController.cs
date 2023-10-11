using DG.Tweening;
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
    [SerializeField] private float _duration;

    private void Awake()
    {
        GetVisuals();
    }

    private void Start()
    {
        GameManager.Instance.OnPhaseChanged += OnPhaseChanged;
    }

    private void OnPhaseChanged(EPhase phase)
    {
        if (phase is EPhase.GamePhase)
        {
            TryChangeVisual(ETriggerObject.Circle_Collectible);
            DOTween.Complete(_currentVisual);
            _currentVisual.transform
                .DOShakePosition(_duration, vibrato: 2, randomness: 5)
                .SetLink(_currentVisual.gameObject);
        }
        if (phase is EPhase.EndGamePhase)
        {
            GameManager.Instance.OnPhaseChanged -= OnPhaseChanged;
        }
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
