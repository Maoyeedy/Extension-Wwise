using System;
using UnityEngine;

// [RequireComponent(typeof(AkGameObj))]
[RequireComponent(typeof(Collider))]
public class WwiseTriggerVolume : MonoBehaviour
{
    public AK.Wwise.Event WwiseEvent;
    public string TagName = "Player";

    private void Start()
    {
        if (!WwiseEvent.IsValid())
        {
            throw new NullReferenceException("Wwise Event is not set on: " + gameObject.name);
        }
        // Debug.Log(WwiseEvent.Name + ": attached to " + gameObject.name);

        var col = gameObject.GetComponent<Collider>();
        if (col.isTrigger == false)
        {
            Debug.LogWarning("The collider on " + gameObject.name + " is not set to trigger. Setting it to trigger.");
            col.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagName))
        {
            WwiseEvent.Post(gameObject);
        }
    }
}