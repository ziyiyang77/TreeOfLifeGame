using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doormusic : MonoBehaviour
{
    public AudioSource openSound; // 第一个音频源
    public AudioSource closeSound; // 第二个音频源

    // 动画事件：开门时调用
    private void PlayOpenSound()
    {
        if (openSound != null)
        {
            openSound.Play();
        }
    }

    // 动画事件：关门时调用
    private void PlayCloseSound()
    {
        if (closeSound != null)
        {
            closeSound.Play();
        }
    }
}
