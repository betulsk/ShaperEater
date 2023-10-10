using UnityEngine;

public class CollectibleDetector : MonoBehaviour
{
    [SerializeField] private ETriggerObject _targetTriggerObjType;
    [SerializeField] private TriggerObjectController _triggerObjectController;
    [SerializeField] private VisualController _visualController;

    private void Awake()
    {
        _triggerObjectController.OnHitTriggerObject += OnHitTriggerObject;
    }

    private void OnDestroy()
    {
        _triggerObjectController.OnHitTriggerObject -= OnHitTriggerObject;
    }

    private void OnHitTriggerObject(TriggerObject triggerObj)
    {
        if (triggerObj.TriggerObjectType == _targetTriggerObjType)
        {
            //_visualController.TryChangeVisual();
            Destroy(triggerObj.gameObject);
        }
    }
}
