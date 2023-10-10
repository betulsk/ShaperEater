using System;
using UnityEngine;

public class TriggerObjectController : MonoBehaviour
{
    public Action<TriggerObject> OnHitTriggerObject;

    private void OnTriggerEnter(Collider other)
    {
        OnHitTriggerObject?.Invoke(other.GetComponent<TriggerObject>());
    }
}
