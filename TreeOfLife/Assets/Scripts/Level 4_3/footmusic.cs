using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footmusic : MonoBehaviour
{
    public AudioSource foot1; // 第一个音频源
    public AudioSource foot2; // 第二个音频源
    public AudioSource foot3;
    public AudioSource foot4;
    // 动画事件：开门时调用
    private void PlayOpenSound1()
    {
        if (foot1 != null)
        {
            foot1.Play();
        }
    }
    private void PlayOpenSound2()
    {
        if (foot2 != null)
        {
            foot2.Play();
        }
    }
    private void PlayOpenSound3()
    {
        if (foot3 != null)
        {
            foot3.Play();
        }
    }
    private void PlayOpenSound4()
    {
        if (foot4 != null)
        {
            foot4.Play();
        }
    }
}
