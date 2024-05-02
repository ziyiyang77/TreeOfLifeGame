using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fademusic : MonoBehaviour
{
    public void playfadeMusic()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
