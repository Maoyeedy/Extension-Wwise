using System;
using UnityEngine;

// [RequireComponent(typeof(AkGameObj))]
public class AudioManager : MonoBehaviour
{
    public WwisePlayOneShot[] WwisePlayOneShots;

    private void Update()
    {
        // press 0 to 9 to play the corresponding sound
        for (var i = 0; i < WwisePlayOneShots.Length; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                WwisePlayOneShots[i].Play();
            }
        }
    }
}