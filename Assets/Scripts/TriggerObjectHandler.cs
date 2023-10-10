using System;
using UnityEngine;

public class TriggerObjectHandler : MonoBehaviour
{
    public Action<ETriggerObject> OnHitTriggerObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnHitTriggerObject?.Invoke(collision.GetComponent<TriggerObject>().TriggerObjectType);
        Debug.Log("Here" + collision.gameObject.GetComponent<TriggerObject>().TriggerObjectType);
    }
}
