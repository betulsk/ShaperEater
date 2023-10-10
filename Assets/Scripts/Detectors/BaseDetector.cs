using UnityEngine;

public class BaseDetector : MonoBehaviour
{
    [SerializeField] private ETriggerObject _targetTriggerObjType;
    [SerializeField] private TriggerObjectController _triggerObjectController;
    public TriggerObject LastTriggerObject;

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
            LastTriggerObject = triggerObj;
            HitCustomActions();
        }
    }

    public virtual void HitCustomActions()
    {
        if (LastTriggerObject.TriggerObjectType != ETriggerObject.Obstacle)
        {
            Destroy(LastTriggerObject.gameObject);
        }
    }
}
