using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doormusic : MonoBehaviour
{
    public AudioSource openSound; // ��һ����ƵԴ
    public AudioSource closeSound; // �ڶ�����ƵԴ

    // �����¼�������ʱ����
    private void PlayOpenSound()
    {
        if (openSound != null)
        {
            openSound.Play();
        }
    }

    // �����¼�������ʱ����
    private void PlayCloseSound()
    {
        if (closeSound != null)
        {
            closeSound.Play();
        }
    }
}
