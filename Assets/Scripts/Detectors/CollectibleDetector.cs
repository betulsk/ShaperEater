using UnityEngine;

public class CollectibleDetector : BaseDetector
{
    [SerializeField] private VisualController _visualController;
    [SerializeField] private InventoryController _inventoryController;

    public override void HitCustomActions()
    {
        _visualController.TryChangeVisual(LastTriggerObject.TriggerObjectType);
        _inventoryController.SaveCollectibles(LastTriggerObject.TriggerObjectType);
        base.HitCustomActions();
    }
}
