using System;
using UnityEngine;

// [RequireComponent(typeof(AkGameObj))]
public class WwisePlayOneShot : MonoBehaviour
{
    public AK.Wwise.Event WwiseEvent;

    private void Start()
    {
        NullCheck();
        // Play();
    }

    private void NullCheck()
    {
        if (!WwiseEvent.IsValid())
        {
            throw new NullReferenceException("Wwise Event is not set on: " + gameObject.name);
        }
    }

    public void Play()
    {
        NullCheck();
        WwiseEvent.Post(gameObject);
    }
}