using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioSource footstepSource;

    [Header("Footsteps")]
    public List<AudioClip> footsteps;


    public void PlayFootstep()
    {
        if (!footstepSource.isPlaying)
        {
            AudioClip clip = footsteps[Random.Range(0, footsteps.Count)];
            footstepSource.clip = clip;
            footstepSource.pitch = 1.5f;
            footstepSource.Play();
        }
    }

}
