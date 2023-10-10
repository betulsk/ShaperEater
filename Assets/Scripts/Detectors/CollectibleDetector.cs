using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleDetector : BaseDetector
{
    [SerializeField] private VisualController _visualController;
    public override void HitCustomActions()
    {
        _visualController.TryChangeVisual(LastTriggerObject.TriggerObjectType);
        base.HitCustomActions();
    }
}
